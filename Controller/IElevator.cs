using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IElevator
    {
        ElevatorState State { get; set; }
        int ElevatorId { get; set; }
        string ElevatorName { get; set; }
        List<int> SelectedInFloors { get; set; }
        List<int> SelectedOutFloors { get; set; }
        int CurrentFloor { get; set; }
        void Initialize();
        void SelectFloorInLift(int floorId);

    }
}
