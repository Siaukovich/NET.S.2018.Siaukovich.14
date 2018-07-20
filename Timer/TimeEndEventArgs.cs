using System;

namespace Timer
{
    /// <summary>
    /// Argiments for TimeEnd event in TimerEverntPublisher.
    /// </summary>
    public class TimeEndEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes instance of TimeEndEventArgs class.
        /// </summary>
        public TimeEndEventArgs()
        {
            this.EventTime = DateTime.Now;
        }
        
        /// <summary>
        /// Time when event have happend.
        /// </summary>
        public DateTime EventTime { get; }
    }
}