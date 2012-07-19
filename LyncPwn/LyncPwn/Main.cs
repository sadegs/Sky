using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Extensibility;

namespace LyncPwn
{
    public partial class Main : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800
        }

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        // These delegates are used call methods on the UI thread.
        private delegate void FocusWindowDelegate();
        private delegate void ResizeWindowDelegate(System.Drawing.Size resizeTo);
        private delegate void DockWindowDelegate(ConversationWindow _ConversationWindow);

        //This window will be docked to the form.
        
        Automation _Automation = LyncClient.GetAutomation();
        LyncClient _lyncClient = LyncClient.GetClient();
        List<Conversation> _activeConversations = new List<Conversation>();
        ConversationService _convServ;

        Thread threadMouseMove;

        int messageIndex = 0;
        bool secondFire = true;

        public Main()
        {
            InitializeComponent();
            DoMouseClick();
            initLync();

            threadMouseMove = new Thread(DoMouseClickWithSleep);
            threadMouseMove.Start();
        }

        public void DoMouseClick()
        {
            //int x = 500, y = 500;
            //Cursor.Position = new System.Drawing.Point(x, y);
            //mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)0, (uint)0, (uint)0, (UIntPtr)0);
            //mouse_event(MOUSEEVENTF_LEFTUP, (uint)0, (uint)0, (uint)0, (UIntPtr)0);
            mouse_event((uint)MouseEventFlags.WHEEL, (uint)0, (uint)0, (uint)120, (UIntPtr)0);

        }
        
        public void DoMouseClickWithSleep()
        {
            while(true)
            {
                //check the time, if you only want to click/respond during 
                // office hours
                if (cbxAutoReply.Checked)
                {
                    TimeSpan start = new TimeSpan(
                        int.Parse(txtHrStart.Text),
                        int.Parse(txtMinStart.Text),
                        0); 
                    
                    TimeSpan end = new TimeSpan(
                        int.Parse(txtHrFinish.Text),
                        int.Parse(txtMinFinish.Text),
                        0); 

                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now > start) && (now < end))
                    {
                        sleepAndClick();
                    }
                    else
                    {
                        //just sleep for 10seconds
                        Thread.Sleep(1000 * 10);
                        
                    }
                }
                else  //else, just do it for all hours!
                {
                    sleepAndClick();
                }
            }
        }

        private void sleepAndClick()
        {
            //sleep for listed amount of time
            int sleepTime = 0;
            if (int.TryParse(txtMouseMin.Text, out sleepTime))
            {
                Thread.Sleep(sleepTime * 60 * 1000);
            }
            else
            {
                MessageBox.Show("Mouse Move Sleep Time not valid number of minutes");
                Thread.Sleep(1000);
            }

            DoMouseClick();
        }

        private void initLync()
        {
            
            // Create the major API objects.
            _lyncClient.ConversationManager.ConversationAdded += new EventHandler<ConversationManagerEventArgs>(ConversationManager_ConversationAdded);

            _lyncClient.StateChanged += new EventHandler<ClientStateChangedEventArgs>(_lyncClient_StateChanged);

            if (_lyncClient.Self == null)
            {
                MessageBox.Show("You're not logged in!.");
                    return;
            }
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

            writeMessage("simulate mouse click" + DateTime.Now.ToString());
            DoMouseClick();

            //_lyncClient.Self.BeginPublishContactInformation(publishState, publishState_callback, null);    


        }

        void _lyncClient_StateChanged(object sender, ClientStateChangedEventArgs e)
        {
            
        }

        private void writeMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblSatus.Text = msg;
                });
            }
            else
            {
                lblSatus.Text = msg;
            }
        
        }


        void publishState_callback(IAsyncResult asresult)
        {
            writeMessage("Updated Status " + DateTime.Now.ToString());
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

            _instMsgMod = instantMessageModality;

            switch (messageIndex)
            {
                case 0:
                    Thread tMsg1 = new Thread(sndMsg1);
                    tMsg1.Start();
                    messageIndex++;
                    break;
                case 1:
                    Thread tMsg2 = new Thread(sndMsg2);
                    tMsg2.Start();
                    messageIndex++;
                    break;
                default:
                    //unsubscribe, we don't want to let them figure out its a bot
                    _convServ.MessageRecived -= _convServ_MessageRecived;
                    break;
            }
        }

        InstantMessageModality _instMsgMod;
        private void sndMsg1()
        {
            Thread.Sleep(10 * 1000);
            if( _instMsgMod != null)
                _instMsgMod.BeginSendMessage(txtResponse1.Text, StartConversationCallback, null);
        }

        private void sndMsg2()
        {
            Thread.Sleep(15 * 1000);
            if(_instMsgMod!=null)
                _instMsgMod.BeginSendMessage(txtResponse2.Text, StartConversationCallback, null);
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

        private void cbxAutoReply_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutoReply.Checked)
            {
                txtHrStart.ReadOnly = txtMinStart.ReadOnly = txtHrFinish.ReadOnly = txtMinFinish.ReadOnly = false;



            }
            else
            {
                txtHrStart.ReadOnly = txtMinStart.ReadOnly = txtHrFinish.ReadOnly = txtMinFinish.ReadOnly = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//this code gets fired on every resize
            {                          
                //so we check if the form was minimized
                Hide();//hides the program on the taskbar
                notifyIcon1.Visible = true;//shows our tray icon
                notifyIcon1.ShowBalloonTip(1000, "Hello", "LyncPwn running in taskbar", ToolTipIcon.Info);
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             Show();//shows the program on taskbar
            this.WindowState = FormWindowState.Normal;//undoes the minimized state of the form
            notifyIcon1.Visible = false;//hides tray icon again
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadMouseMove.Abort();
        }


    }
}
