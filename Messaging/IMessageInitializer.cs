using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IMessageInitializer
    {
        //Initializes Subscriber and publisher
        void Initialize();
        void AddSubscription(string channelName);
        void RemoveSubscription(string channelName);
    }
}
