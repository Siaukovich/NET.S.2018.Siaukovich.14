using System;
using Timer;

namespace TimerConsoleApp
{
    public class Subscriber
    {
        /// <summary>
        /// Subscribers unique id.
        /// </summary>
        private readonly int id;
        
        /// <summary>
        /// Time when event to which this subscriber subscribed have happened.
        /// Set to null if event does not happened.
        /// </summary>
        private DateTime? eventTime;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscriber"/> class. 
        /// </summary>
        /// <param name="id">
        /// Unique id of the new subscriber.
        /// </param>
        public Subscriber(int id) => this.id = id;

        /// <summary>
        /// Registers this subscriber to passed publisher's TimeEnd event.
        /// </summary>
        /// <param name="publisher">
        /// Publisher to which TimeEnd event this subscriber will register.
        /// </param>
        public void Register(TimerEventPublisher publisher) => publisher.TimeEnd += this.HandleTimeEndEvent;

        /// <summary>
        /// Unregisters this subscriber from passed publisher's TimeEnd event.
        /// </summary>
        /// <param name="publisher">
        /// Publisher from which TimeEnd event this subscriber will unregister.
        /// </param>
        public void Unregister(TimerEventPublisher publisher) => publisher.TimeEnd -= this.HandleTimeEndEvent;

        /// <summary>
        /// Get status of this subscriber as string.
        /// </summary>
        /// <returns>
        /// This subscriber's status.
        /// </returns>
        public string GetEventStatus()
        {
            if (this.eventTime != null)
            {
                return $"Event have happend in subscriber #{this.id} at {this.eventTime}";
            }
            
            return $"Event have NOT happend in subscriber #{this.id}";
        }

        /// <summary>
        /// Handler for TimeEnd event.
        /// </summary>
        /// <param name="sender">
        /// Object that caused an event.
        /// </param>
        /// <param name="eventArgs">
        /// Event's arguments.
        /// </param>
        private void HandleTimeEndEvent(object sender, TimeEndEventArgs eventArgs) => this.eventTime = eventArgs.EventTime;
    }
}