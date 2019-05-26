namespace RemotingEvents.Server
{
    using System;
    using System.Windows.Forms;
    using System.Threading;

    /// <summary>
    /// Defines the <see cref="frm_Main" />
    /// </summary>
    public partial class frm_Main : Form
    {
        /// <summary>
        /// Defines the server
        /// </summary>
        RemotingServer server;

        /// <summary>
        /// The SetBoxText
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        private delegate void SetBoxText(string Message);

        /// <summary>
        /// Initializes a new instance of the <see cref="frm_Main"/> class.
        /// </summary>
        public frm_Main()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The bttn_StartServer_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void bttn_StartServer_Click(object sender, EventArgs e)
        {
            try
            {
                server = new RemotingServer();
                server.StartServer(15000);
                server.MessageArrived += new Common.MessageArrivedEvent(server_MessageArrived);
                SetTextBox("Server Started");
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The server_MessageArrived
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        void server_MessageArrived(string Message)
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
        /// The bttn_StopServer_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void bttn_StopServer_Click(object sender, EventArgs e)
        {
            try
            {
                server.StopServer();
                server = null;
                SetTextBox("Server Stopped");
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
                lock (this)
                {

                    if (tbx_Messages.InvokeRequired)
                    {


                        // .BeginInvoke: Executes asynchronously,
                        this.BeginInvoke(new SetBoxText(SetTextBox), new object[] { Message });
                        return;
                    }
                    else
                        tbx_Messages.AppendText(Message + "\r\n");
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }


        /// <summary>
        /// The frm_Main_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void frm_Main_Load(object sender, EventArgs e)
        {
        }
    }
}
