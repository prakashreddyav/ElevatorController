using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            IController controller = new Controller.Controller();
            controller.Initialize("Elevator.xml","Floor.xml");
            Console.WriteLine("Elevator Controller started...");
            Console.WriteLine("press any key to exit");
            Console.ReadLine();
        }
    }
}
