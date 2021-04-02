using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Entities;

namespace Truck.Core.Dto
{
    public class PostTruck
    {
        public TruckModel Model { get; set; }
        public ushort ProductionYear { get; set; }
        public ushort ModelYear { get; set; }
    }
}
