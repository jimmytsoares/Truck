using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Core.Interfaces
{
    public interface ITruckRepository
    {
        /// <summary>
        /// Returns all trucks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Entities.Truck>> GetAllTrucksAsync();

        /// <summary>
        /// Return a single truck by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Entities.Truck> GetTruckAsync(long id);

        /// <summary>
        /// Add a new truck
        /// </summary>
        /// <param name="truck"></param>
        /// <returns></returns>
        Task<Entities.Truck> NewTruck(Dto.PostTruck truck);

        /// <summary>
        /// Edit a truck
        /// </summary>
        /// <param name="truck"></param>
        /// <returns></returns>
        Task EditTruck(Dto.PutTruck truck);

        /// <summary>
        /// Delete an existing truck
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTruck(Entities.Truck truck);
    }
}
