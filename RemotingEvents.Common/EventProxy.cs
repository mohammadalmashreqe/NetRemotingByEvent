namespace RemotingEvents.Common
{
    using System;

    /// <summary>
    /// Defines the <see cref="EventProxy" />
    /// </summary>
    public class EventProxy : MarshalByRefObject
    {
        /// <summary>
        /// Defines the MessageArrived
        /// </summary>
        public event MessageArrivedEvent MessageArrived;

        /// <summary>
        /// The InitializeLifetimeService
        /// </summary>
        /// <returns>The <see cref="object"/></returns>
        public override object InitializeLifetimeService()
        {
            try
            {
                return null;            //Returning null holds the object alive until it is explicitly destroyed
            }
            catch(Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return null;
            }
        }

        /// <summary>
        /// The LocallyHandleMessageArrived
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        public void LocallyHandleMessageArrived(string Message)
        {
            try
            {
                MessageArrived?.Invoke(Message);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
            }
        }
    }
}
