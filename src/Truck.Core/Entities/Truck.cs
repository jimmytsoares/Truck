using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;

namespace Truck.Core.Entities
{
    public class Truck
    {        
        public long TruckId { get; set; }
        public TruckModel Model { get; set; }
        public ushort ProductionYear { get; set; }
        public ushort ModelYear { get; set; }

        public static Truck CheckPost(PostTruck newTruck)
        {
            if (newTruck.ProductionYear != DateTime.Now.Year)
                throw new ArgumentException("The production year must be the same as the current year");

            if (newTruck.ModelYear != DateTime.Now.Year && newTruck.ModelYear != DateTime.Now.Year + 1)
                throw new ArgumentException("The mode year must be the same as the current year or next year");

            return new Truck
            {
                Model = newTruck.Model,
                ProductionYear = newTruck.ProductionYear,
                ModelYear = newTruck.ModelYear
            };
        }

        public static Truck CheckPut(PutTruck editTruck)
        {
            if (editTruck.ModelYear != DateTime.Now.Year || editTruck.ModelYear != DateTime.Now.Year + 1)
                throw new ArgumentException("The mode year must be the same as the current year or next year");

            return new Truck
            {
                TruckId = editTruck.TruckId,
                Model = editTruck.Model,
                ModelYear = editTruck.ModelYear
            };
        }
    }

    public enum TruckModel
    {
        FH,
        FM
    }
}
