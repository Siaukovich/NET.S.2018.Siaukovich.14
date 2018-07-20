using System;

namespace Timer
{
    /// <summary>
    /// Argiments for TimeEnd event in TimerEverntPublisher.
    /// </summary>
    public class TimeEndEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEndEventArgs"/> class. 
        /// </summary>
        public TimeEndEventArgs()
        {
            this.EventTime = DateTime.Now;
        }
        
        /// <summary>
        /// Gets time when event have happened.
        /// </summary>
        public DateTime EventTime { get; }
    }
}