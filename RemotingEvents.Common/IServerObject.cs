namespace RemotingEvents.Common
{
    /// <summary>
    /// Defines the <see cref="IServerObject" />
    /// </summary>
    public interface IServerObject
    {
        /// <summary>
        /// Defines the MessageArrived
        /// </summary>
        event MessageArrivedEvent MessageArrived;

        /// <summary>
        /// The PublishMessage
        /// </summary>
        /// <param name="Message">The Message<see cref="string"/></param>
        void PublishMessage(string Message);
    }
}
