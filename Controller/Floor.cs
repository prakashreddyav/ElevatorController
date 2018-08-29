using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Floor:IFloor
    {

        private IMessageInitializer messageInitializer;
        private IMessagePublisher messagePublisher;
        public Floor(IMessageInitializer _messgageInitializer, IMessagePublisher _messagePublisher, string channelName, int floorId, string floorName)
        {
            messageInitializer = _messgageInitializer;
            messagePublisher = _messagePublisher;
            ChannelName = channelName;
            FloorId = floorId;
            FloorName = floorName;           
            Initialize();
        }

        public string ChannelName { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public bool IsFloorSelected { get; set; }
        public void Initialize()
        {
            messageInitializer.Initialize();
            //one building can be considered as one group
            messageInitializer.AddSubscription(ChannelName);
            IsFloorSelected = false;
        }

        public void OnEventReceived(IBaseEvent baseEvent, EventType eventType)
        {
            switch (eventType)
            {
                case EventType.FloorSelected:
                    //do nothing
                    break;
                case EventType.FloorReached:
                    onfloorReached(baseEvent.PayLoad);
                    break;
            }
        }

        private void onfloorReached(string payLoad)
        {
            IsFloorSelected = false;
        }

        public void SelectFloor()
        {
            if (!IsFloorSelected)
            {
                IsFloorSelected = true;
                IBaseEvent baseEvent = new PublishEvent(EventType.FloorSelected, DateTime.Now, FloorId.ToString());
                messagePublisher.Publish(ChannelName, baseEvent);
            }
        }
        
    }
}
