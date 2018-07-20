using System;

namespace Timer
{
    /// <summary>
    /// Arguments for TimeEnd event in TimerEventPublisher.
    /// </summary>
    public class TimeEndEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEndEventArgs"/> class. 
        /// </summary>
        /// <param name="message">
        /// Message to all subscribers.
        /// </param>
        public TimeEndEventArgs(string message)
        {
            this.EventTime = DateTime.Now;
            this.Message = message;
        }
        
        /// <summary>
        /// Gets time when event have happened.
        /// </summary>
        public DateTime EventTime { get; }

        /// <summary>
        /// Gets the message from publisher.
        /// </summary>
        public string Message { get; }
    }
}