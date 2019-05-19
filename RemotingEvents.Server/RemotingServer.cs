namespace RemotingEvents.Server
{
    using RemotingEvents.Common;
    using System;
    using System.Collections;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;

    /// <summary>
    /// Defines the <see cref="RemotingServer" />
    /// </summary>
    public class RemotingServer : MarshalByRefObject, IServerObject
    {
        /// <summary>
        /// Defines the serverChannel
        /// </summary>
        private TcpServerChannel serverChannel;

        /// <summary>
        /// Defines the tcpPort
        /// </summary>
        private int tcpPort;

        /// <summary>
        /// Defines the internalRef
        /// </summary>
        private ObjRef internalRef;

        /// <summary>
        /// Defines the serverActive
        /// </summary>
        private bool serverActive = false;

        /// <summary>
        /// Defines the serverURI
        /// </summary>
        private static string serverURI = "serverExample.Rem";

        /// <summary>
        /// Defines the MessageArrived
        /// </summary>
        public event MessageArrivedEvent MessageArrived;

        /// <summary>
        /// The PublishMessage
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        public void PublishMessage(string Message)
        {
            try
            {
                SafeInvokeMessageArrived(Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The StartServer
        /// </summary>
        /// <param name="port">The port<see cref="int"/></param>
        public void StartServer(int port)
        {
            try
            {
                if (serverActive)
                    return;

                Hashtable props = new Hashtable();
                props["port"] = port;
                props["name"] = serverURI;

                //Set up for remoting events properly
                BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

                serverChannel = new TcpServerChannel(props, serverProv);

                try
                {
                    ChannelServices.RegisterChannel(serverChannel, false);
                    internalRef = RemotingServices.Marshal(this, props["name"].ToString());
                    serverActive = true;
                }
                catch (RemotingException re)
                {
                    //Could not start the server because of a remoting exception
                    ErrorLogger.ErrorLog(re);

                }
                catch (Exception ex)
                {
                    //Could not start the server because of some other exception
                    ErrorLogger.ErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The StopServer
        /// </summary>
        public void StopServer()
        {
            try
            {
                if (!serverActive)
                    return;

                RemotingServices.Unmarshal(internalRef);

                try
                {
                    ChannelServices.UnregisterChannel(serverChannel);
                }
                catch (Exception ex)
                {
                    ErrorLogger.ErrorLog(ex);
                }
            }
            catch(Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }

        /// <summary>
        /// The SafeInvokeMessageArrived
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        private void SafeInvokeMessageArrived(string Message)
        {
            try {
                if (!serverActive)
                    return;

                if (MessageArrived == null)
                    return;         //No Listeners

                MessageArrivedEvent listener = null;
                Delegate[] dels = MessageArrived.GetInvocationList();

                foreach (Delegate del in dels)
                {
                    try
                    {
                        listener = (MessageArrivedEvent)del;
                        listener.Invoke(Message);
                    }
                    catch (Exception ex)
                    {
                        //Could not reach the destination, so remove it
                        //from the list
                        MessageArrived -= listener;
                        ErrorLogger.ErrorLog(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }

            }
    }
}
