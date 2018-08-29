using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IMessagePublisher
    {
        void Publish(string ChannelName, IBaseEvent message);
    }
}
