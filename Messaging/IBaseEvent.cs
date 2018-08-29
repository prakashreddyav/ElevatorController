using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IBaseEvent
    {
        EventType eventType { get; set; }
        DateTime OriginTime { get; set; }
        string PayLoad { get; set; }
    }
}
