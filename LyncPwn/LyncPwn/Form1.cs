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

            _lyncClient.StateChanged += new EventHandler<ClientStateChangedEventArgs>(_lyncClient_StateChanged);
            
            _lyncClient.Self.Contact.ContactInformationChanged += new EventHandler<ContactInformationChangedEventArgs>(Contact_ContactInformationChanged);

            //move mouse around on startup to change link status to available
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor = Cursors.Default;
            
        }

        void Contact_ContactInformationChanged(object sender, ContactInformationChangedEventArgs e)
        {
            string returnValue = string.Empty;
            StringBuilder sb = new StringBuilder();
            Boolean raiseUpdate = false;
            if (e.ChangedContactInformation.Contains(ContactInformationType.Availability))
            {
                //get actual contactModel availability (Will be int value within OCOM availaiblity ranges)
                ContactAvailability availEnum = (ContactAvailability)((Contact)sender).GetContactInformation(ContactInformationType.Availability);
                string activityString = (string)((Contact)sender).GetContactInformation(ContactInformationType.Activity);
                sb.Append(availEnum.ToString() + " " + activityString);
                raiseUpdate = true;
            }

            if (raiseUpdate)
            {
                returnValue = "Updated availability for "
                + ((Contact)sender).GetContactInformation(ContactInformationType.DisplayName).ToString()
                + System.Environment.NewLine
                + sb.ToString();
            }
            
            Dictionary<PublishableContactInformationType, object> publishState = new Dictionary<PublishableContactInformationType, object>();
            publishState.Add(PublishableContactInformationType.Availability, ContactAvailability.Free);

            _lyncClient.Self.BeginPublishContactInformation(publishState, publishState_callback, null);    


        }

        void _lyncClient_StateChanged(object sender, ClientStateChangedEventArgs e)
        {
            
        }

        void publishState_callback(IAsyncResult asresult)
        {
            lblSatus.Text = "Updated Status " + DateTime.Now.ToString();
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
            if (!cbxSendResponse.Checked)
                return;

            secondFire = !secondFire;
            if (secondFire)
                return;

            switch (messageIndex)
            {
                case 0:
                    instantMessageModality.BeginSendMessage(txtResponse1.Text, StartConversationCallback, null);
                    messageIndex++;
                    break;
                case 1: 
                    instantMessageModality.BeginSendMessage(txtResponse2.Text, StartConversationCallback, null);
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
            
            ((InstantMessageModality)sender).BeginSendMessage(e.Text + " - i hear ya", StartConversationCallback, null);

        }

        #region callback
        // This callback method appears as a parameter in the StartConversaton method.
        private void StartConversationCallback(IAsyncResult asyncop)
        {
            
            
        }
        #endregion


    }
}
