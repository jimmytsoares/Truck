using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;
using Truck.Core.Interfaces;
using Truck.Infrastructure.Data;

namespace Truck.Infrastructure.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckContext _context;
        public TruckRepository(TruckContext truckContext)
        {
            _context = truckContext;
        }

        public async Task DeleteTruck(Core.Entities.Truck truck)
        {
            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();            
        }

        public async Task EditTruck(PutTruck truck)
        {
            var originalTruck = await _context.Trucks.FindAsync(truck.TruckId);

            if (originalTruck == null)
                throw new ArgumentException("TruckId not found");

            var editTruck = Core.Entities.Truck.CheckPut(truck);

            originalTruck.ModelYear = editTruck.ModelYear;
            originalTruck.Model = editTruck.Model;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Core.Entities.Truck>> GetAllTrucksAsync()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Core.Entities.Truck> GetTruckAsync(long id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<Core.Entities.Truck> NewTruck(PostTruck truck)
        {
            var newTruck = Core.Entities.Truck.CheckPost(truck);

            await _context.AddAsync(newTruck);
            await _context.SaveChangesAsync();

            return newTruck;
        }
    }
}
