using System;
using Timer;

namespace TimerConsoleApp
{
    public class Subscriber
    {
        /// <summary>
        /// Subscribers unique id.
        /// </summary>
        private readonly int _id;
        
        /// <summary>
        /// Time when event to which this subscriber subscribed have happened.
        /// </summary>
        private DateTime? _eventTime;
        
        /// <summary>
        /// Initializes new subscriber instance.
        /// </summary>
        /// <param name="id"></param>
        public Subscriber(int id) => this._id = id;

        /// <summary>
        /// Registeres this subsriber to passed publisher's TimeEnd event.
        /// </summary>
        /// <param name="publisher">
        /// Publisher to which TimeEnd event this subscriber will register.
        /// </param>
        public void Register(TimerEventPublisher publisher) => publisher.TimeEnd += HandleTimeEndEvent;

        /// <summary>
        /// Unregisteres this subsriber from passed publisher's TimeEnd event.
        /// </summary>
        /// <param name="publisher">
        /// Publisher from which TimeEnd event this subscriber will unregister.
        /// </param>
        public void Unregister(TimerEventPublisher publisher) => publisher.TimeEnd -= HandleTimeEndEvent;

        /// <summary>
        /// Get status of this subscriber as string.
        /// </summary>
        /// <returns>
        /// This subscriber's status.
        /// </returns>
        public string GetEventStatus()
        {
            if (_eventTime != null)
            {
                return $"Event have happend in subscriber #{this._id} at {this._eventTime}";
            }
            
            return $"Event have NOT happend in subscriber #{this._id}";
        }

        /// <summary>
        /// Handler for TimeEnd event.
        /// </summary>
        /// <param name="sender">
        /// Object that coused an event.
        /// </param>
        /// <param name="eventArgs">
        /// Event's arguments.
        /// </param>
        private void HandleTimeEndEvent(object sender, TimeEndEventArgs eventArgs) => this._eventTime = eventArgs.EventTime;
    }
}