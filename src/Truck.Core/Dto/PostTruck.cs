using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Entities;

namespace Truck.Core.Dto
{
    public class PostTruck
    {
        public TruckModel Model { get; set; }

        [Display(Name = "Production Year")]
        public ushort ProductionYear { get; set; }

        [Display(Name = "Model Year")]
        [Handlers.StrictYear]
        public ushort ModelYear { get; set; }
    }
}
