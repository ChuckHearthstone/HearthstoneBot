using System;

namespace HearthstoneBot.Common
{
    public class ChildThreadExceptionOccuredEventArgs : EventArgs
    {
        public Exception Exception;
    }

    public class EventNotifyManager
    {

        private EventNotifyManager() { }

        public static EventNotifyManager Instance { get; } = new EventNotifyManager();

        /// <summary>
        /// When child thread encounter exception, it will not throw to main thread
        /// </summary>
        public event EventHandler<ChildThreadExceptionOccuredEventArgs> ChildThreadExceptionOccured;
        public void OnChildThreadExceptionOccured(ChildThreadExceptionOccuredEventArgs e)
        {
            ChildThreadExceptionOccured?.Invoke(this,e);
        }

    }
}
