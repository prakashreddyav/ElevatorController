using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IMessageSubscriber
    {
        string ChannelName { get; set; }
        /// <summary>
        /// This method will be called when a message is published into the queue
        /// </summary>
        /// <param name="message"></param>
        void OnEventReceived(IBaseEvent baseEvent, EventType eventType);
    }
}

