using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Extensibility;

namespace LyncPwn
{
    public partial class Form1 : Form
    {
        // These delegates are used call methods on the UI thread.
        private delegate void FocusWindowDelegate();
        private delegate void ResizeWindowDelegate(System.Drawing.Size resizeTo);
        private delegate void DockWindowDelegate(ConversationWindow _ConversationWindow);

        //This window will be docked to the form.
        
        Automation _Automation = LyncClient.GetAutomation();
        LyncClient _lyncClient = LyncClient.GetClient();
        List<Conversation> _activeConversations = new List<Conversation>();
        ConversationService _convServ;

        int messageIndex = 0;
        bool secondFire = true;

        public Form1()
        {
            InitializeComponent();
            initLync();
        }

        private void initLync()
        {
            
            // Create the major API objects.
            _lyncClient.ConversationManager.ConversationAdded += new EventHandler<ConversationManagerEventArgs>(ConversationManager_ConversationAdded);

            //testing
            //System.Threading.Thread.Sleep(6 * 60 * 1000);

            label1.Text = "moved cursor";

            //move mouse around on startup to change link status to available
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor = Cursors.Default;
            
        }

        void ConversationManager_ConversationAdded(object sender, ConversationManagerEventArgs e)
        {
            
            Conversation conv = e.Conversation;
            _convServ = new ConversationService(conv);
            _convServ.Start();
            _convServ.MessageRecived += new MessageRecived(_convServ_MessageRecived);

            _activeConversations.Add(conv);

            //Modality modality;
            //if (conv.Modalities.TryGetValue(ModalityTypes.InstantMessage, out modality))
            //{
            //    InstantMessageModality instMsg = ((InstantMessageModality)modality);
            //    instMsg.InstantMessageReceived += new EventHandler<MessageSentEventArgs>(Form1_InstantMessageReceived);
                
            //}

        }

        void _convServ_MessageRecived(string message, string participantName, InstantMessageModality instantMessageModality)
        {
            secondFire = !secondFire;
            if (secondFire)
                return;

            switch (messageIndex)
            {
                case 0:
                    instantMessageModality.BeginSendMessage("hi", StartConversationCallback, null);
                    messageIndex++;
                    break;
                case 1: 
                    instantMessageModality.BeginSendMessage("one second...brb...", StartConversationCallback, null);
                    messageIndex++;
                    break;
                default:
                    //unsubscribe, we don't want to let them figure out its a bot
                    _convServ.MessageRecived -= _convServ_MessageRecived;
                    break;
            }
        }

        void Form1_InstantMessageReceived(object sender, MessageSentEventArgs e)
        {
            MessageBox.Show(e.Text);
            ((InstantMessageModality)sender).BeginSendMessage(e.Text + " - i hear ya", StartConversationCallback, null);

        }

        #region callback
        // This callback method appears as a parameter in the StartConversaton method.
        private void StartConversationCallback(IAsyncResult asyncop)
        {
            MessageBox.Show("message sent");
            
        }
        #endregion


    }
}
