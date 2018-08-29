using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Elevator : IElevator,IMessageSubscriber
    {
        private IMessageInitializer messageInitializer;
        private IMessagePublisher messagePublisher;
        private int nextFloor;
        public Elevator(IMessageInitializer _messgageInitializer, IMessagePublisher _messagePublisher, string channelName, int elevatorId, string elevatorName)
        {
            messageInitializer = _messgageInitializer;
            messagePublisher = _messagePublisher;
            ChannelName = channelName;
            ElevatorId = elevatorId;
            ElevatorName = elevatorName;
            SelectedInFloors = new List<int>();
            SelectedOutFloors = new List<int>();
            Initialize();
        }

        public string ChannelName { get; set; }
        public int ElevatorId { get; set; }
        public string ElevatorName { get; set; }
        public List<int> SelectedInFloors { get; set; }
        public List<int> SelectedOutFloors { get; set; }
        public ElevatorState State { get; set; }
        public int CurrentFloor { get; set; }
        public void Initialize()
        {
            messageInitializer.Initialize();
            //one building can be considered as one group
            messageInitializer.AddSubscription(ChannelName);
            CurrentFloor = 0;
            nextFloor = 0;
            State = ElevatorState.Idle;
        }

        public void OnEventReceived(IBaseEvent baseEvent, EventType eventType)
        {
            switch (eventType)
            {
                case EventType.FloorSelected:
                    onfloorSelected(baseEvent.PayLoad);
                    break;
                case EventType.FloorReached:
                    onfloorReached(baseEvent.PayLoad);
                    break;
            }
        }

        private void onfloorReached(string payLoad)
        {
            int floorid = 0;
            //todo: parse the payload and set the floor id
            SelectedOutFloors = SelectedOutFloors.Distinct().ToList();
            SelectedOutFloors.Remove(floorid);
            SetNextFloor();
        }

        public void SelectFloorInLift(int floorId)
        {
            SelectedInFloors = SelectedInFloors.Distinct().ToList();
            SelectedInFloors.Add(floorId);
            SetNextFloor();
        }

        private void SetNextFloor()
        {
            //based on the in floor list and out floor list set the next floor
            //and the lift starts moving towards that.
            //Set the elevator state
        }

        private void onfloorSelected(string payload)
        {
            int floorid=0;
            //todo: parse the payload and set the floor id
            SelectedOutFloors = SelectedOutFloors.Distinct().ToList();
            SelectedOutFloors.Add(floorid);
            SetNextFloor();
        }

        private void onFloorStop(int floorId)
        {
            IBaseEvent baseEvent = new PublishEvent(EventType.FloorReached, DateTime.Now, floorId.ToString());
            messagePublisher.Publish(ChannelName, baseEvent);
        }
    }
}
