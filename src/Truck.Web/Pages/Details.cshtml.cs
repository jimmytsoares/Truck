using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Truck.Core.Entities;
using Truck.Core.Interfaces;
using Truck.Infrastructure.Data;

namespace Truck.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ITruckRepository _repository;

        public DetailsModel(ITruckRepository repository)
        {
            _repository = repository;
        }

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
            return Page();
        }
    }
}
