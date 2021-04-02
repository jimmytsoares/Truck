using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Infrastructure.Data
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {

        }

        public TruckContext() : base()
        {

        }

        public DbSet<Truck.Core.Entities.Truck> Trucks { get; set; }
    }
}