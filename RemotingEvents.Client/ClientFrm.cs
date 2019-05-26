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
    /// Defines the <see cref="ClientFrm" />
    /// </summary>
    public partial class ClientFrm : Form
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
        private string serverURI = "tcp://localhost:15000/server";

        /// <summary>
        /// Defines the isconnected
        /// </summary>
        private bool isconnected = false;

        /// <summary>
        /// The SetBoxText
        /// </summary>
        private delegate void SetBoxText(string Message);

        /// <summary>
        /// Defines the username
        /// </summary>
        string username;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientFrm"/> class.
        /// </summary>
        /// <param name="username">The username<see cref="string"/></param>
        public ClientFrm(string username)
        {
            try
            {
                InitializeComponent();
                this.username = username; 
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
            catch (Exception ex)
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
            if (isconnected)
                return;

            try
            {
                remoteServer = (IServerObject)Activator.GetObject(typeof(IServerObject), serverURI);
                remoteServer.MessageArrived += new MessageArrivedEvent(eventProxy.LocallyHandleMessageArrived);

                remoteServer.PublishMessage("Client Connected");        //This is where it will break if we didn't connect

                //Now we have to attach the events...
                isconnected = true;
            }
            catch (Exception ex)
            {
                isconnected = false;
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
                if (!isconnected)
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
                if (!isconnected)
                    return;

                remoteServer.PublishMessage(username+" saye : "+ tbx_Input.Text);
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
                { // .BeginInvoke: Executes asynchronously,
                    SetBoxText set = new SetBoxText(SetTextBox);
                    this.BeginInvoke(set, new object[] { Message });
                    return;
                }
                else

                    tbx_Messages.AppendText(Message + "\r\n");
            }
            catch (Exception ex)
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
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
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
