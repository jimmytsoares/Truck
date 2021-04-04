using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Truck.Core.Entities;
using Truck.Core.Interfaces;
using Truck.Infrastructure.Data;

namespace Truck.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly ITruckRepository _repository;

        public EditModel(ITruckRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Core.Dto.PutTruck PutTruck { get; set; }
        [BindProperty]
        public Core.Entities.Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _repository.GetTruckAsync(id.Value);

            if (Truck == null)
            {
                return NotFound();
            }

            PutTruck = new Core.Dto.PutTruck
            {
                TruckId = Truck.TruckId,
                Model = Truck.Model,
                ModelYear = Truck.ModelYear
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(PutTruck.TruckId);
            }

            try
            {
                await _repository.EditTruck(PutTruck);

                return RedirectToPage("./Index");
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
    }
}
