using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class PublishEvent : IBaseEvent
    {
        public PublishEvent(EventType _eventType, DateTime _originTime, string _payLoad)
        {
            eventType = _eventType;
            OriginTime = _originTime;
            PayLoad = _payLoad;
        }
        public EventType eventType { get; set; }
        public DateTime OriginTime { get; set; }
        public string PayLoad { get; set; }
    }
}
