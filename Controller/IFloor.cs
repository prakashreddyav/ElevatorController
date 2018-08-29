using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IFloor
    {
        int FloorId { get; set; }
        string FloorName { get; set; }
        bool IsFloorSelected { get; set; }
        void Initialize();
        void SelectFloor();
    }
}
