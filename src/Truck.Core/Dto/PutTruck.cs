using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Entities;

namespace Truck.Core.Dto
{
    public class PutTruck
    {
        public long TruckId { get; set; }
        public TruckModel Model { get; set; }

        [Display(Name = "Model Year")]
        [Handlers.StrictYear]
        public ushort ModelYear { get; set; }
    }
}
