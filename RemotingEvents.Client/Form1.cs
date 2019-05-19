namespace RemotingEvents.Client
{
    using RemotingEvents.Common;
    using System;
    using System.Collections;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Defines the remoteServer
        /// </summary>
        IServerObject remoteServer;

        /// <summary>
        /// Defines the eventProxy
        /// </summary>
        EventProxy eventProxy;

        /// <summary>
        /// Defines the tcpChan
        /// </summary>
        TcpChannel tcpChan;

        /// <summary>
        /// Defines the clientProv 
        /// </summary>
        BinaryClientFormatterSinkProvider clientProv;

        /// <summary>
        /// Defines the serverProv
        /// </summary>
        BinaryServerFormatterSinkProvider serverProv;

        /// <summary>
        /// Defines the serverURI
        /// </summary>
        private string serverURI = "tcp://localhost:15000/serverExample.Rem";

        /// <summary>
        /// Defines the connected
        /// </summary>
        private bool connected = false;

        /// <summary>
        /// The SetBoxText
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        private delegate void SetBoxText(string Message);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            try
            {
                InitializeComponent();

                clientProv = new BinaryClientFormatterSinkProvider();
                serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

                eventProxy = new EventProxy();
                eventProxy.MessageArrived += new MessageArrivedEvent(eventProxy_MessageArrived);

                Hashtable props = new Hashtable();
                props["name"] = "remotingClient";
                props["port"] = 0;      //First available port

                tcpChan = new TcpChannel(props, clientProv, serverProv);
                ChannelServices.RegisterChannel(tcpChan);

                RemotingConfiguration.RegisterWellKnownClientType(new WellKnownClientTypeEntry(typeof(IServerObject), serverURI));
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

            }
        }

        /// <summary>
        /// The eventProxy_MessageArrived
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        void eventProxy_MessageArrived(string Message)
        {
            try
            {
                SetTextBox(Message);
            }
            catch (Exception  ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The bttn_Connect_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void bttn_Connect_Click(object sender, EventArgs e)
        {
            if (connected)
                return;

            try
            {
                remoteServer = (IServerObject)Activator.GetObject(typeof(IServerObject), serverURI);
                remoteServer.PublishMessage("Client Connected");        //This is where it will break if we didn't connect

                //Now we have to attach the events...
                remoteServer.MessageArrived += new MessageArrivedEvent(eventProxy.LocallyHandleMessageArrived);
                connected = true;
            }
            catch (Exception ex)
            {
                connected = false;
                SetTextBox("Could not connect: " + ex.Message);
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The bttn_Disconnect_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void bttn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connected)
                    return;

                //First remove the event
                remoteServer.MessageArrived -= eventProxy.LocallyHandleMessageArrived;

                //Now we can close it out
                ChannelServices.UnregisterChannel(tcpChan);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The bttn_Send_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void bttn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connected)
                    return;

                remoteServer.PublishMessage(tbx_Input.Text);
                tbx_Input.Text = "";
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The SetTextBox
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        private void SetTextBox(string Message)
        {
            try
            {
                if (tbx_Messages.InvokeRequired)
                {
                    //IN CASE THE MESSAGE COME FROM ANOTHER CLIENT 
                    this.BeginInvoke(new SetBoxText(SetTextBox), new object[] { Message });
                    return;
                }
                else
                    //IN CASE THE THIS IS SENDER 
                    tbx_Messages.AppendText(Message + "\r\n");
            }
            catch(Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The button1_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click(object sender, EventArgs e)
        {try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
