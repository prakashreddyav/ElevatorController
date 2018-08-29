using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Controller
{
    public class Controller : IController
    {
        private IMessageInitializer messageInitializer;
        private IMessagePublisher messagePublisher;
        private List<IElevator> elevators;
        private List<IFloor> Floors;
        public Controller()
        {
            //message initializer and message publisher will be resolved by unity container
            IMessageInitializer _messgageInitializer=null;
            IMessagePublisher _messagePublisher=null;
            
            messageInitializer = _messgageInitializer;
            messagePublisher = _messagePublisher;
        }
        public void Initialize(string elevatorxmlPath, string floorxmlPath)
        {
            int id=0;
            string name;
            string buildingName = "tower1";
            XmlDocument doc;
            XmlElement root;
            XmlNodeList nodes;

            //InitializingFloors
            doc = new XmlDocument();
            doc.Load(floorxmlPath);
            root = doc.DocumentElement;
            nodes = root.SelectNodes("Floor"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                id = 0;
                name = string.Empty;
                //set the id and name from xml elements
                Floors.Add(new Floor(messageInitializer, messagePublisher, buildingName, id, name));
            }

            //InitializingElevators
            doc = new XmlDocument();
            doc.Load(elevatorxmlPath);
            root = doc.DocumentElement;
            nodes = root.SelectNodes("Elevator"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                id = 0;
                name = string.Empty;
                //set the id and name from xml elements
                elevators.Add(new Elevator(messageInitializer, messagePublisher, buildingName, id, name));
            }
        }
    }
}
