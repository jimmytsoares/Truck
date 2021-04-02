using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Truck.Core.Entities;
using Truck.Core.Interfaces;
using Truck.Infrastructure.Data;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckRepository _repository;

        public TrucksController(ITruckRepository truckRepository)
        {
            _repository = truckRepository;
        }

        /// <summary>
        /// Return all the trucks in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Entities.Truck>>> GetTrucks()
        {
            return Ok(await _repository.GetAllTrucksAsync());
        }

        // GET: api/Trucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Entities.Truck>> GetTruck(long id)
        {
            var truck = await _repository.GetTruckAsync(id);

            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        // PUT: api/Trucks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruck(long id, Core.Dto.PutTruck truck)
        {
            try
            {
                if (id != truck.TruckId)
                {
                    return BadRequest();
                }

                await _repository.EditTruck(truck);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // POST: api/Trucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Core.Entities.Truck>> PostTruck(Core.Dto.PostTruck truck)
        {
            try
            {
                var newTruck = await _repository.NewTruck(truck);

                return CreatedAtAction("GetTruck", new { id = newTruck.TruckId }, newTruck);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // DELETE: api/Trucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(long id)
        {
            var truck = await _repository.GetTruckAsync(id);
            if (truck == null)
            {
                return NotFound();
            }

            await _repository.DeleteTruck(truck);

            return NoContent();
        }
    }
}
