using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Truck.Core.Entities;
using Truck.Core.Interfaces;
using Truck.Infrastructure.Data;

namespace Truck.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ITruckRepository _repository;

        public CreateModel(ITruckRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Core.Dto.PostTruck Truck { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Truck.ProductionYear == 0)
                Truck.ProductionYear = (ushort)DateTime.Now.Year;

            await _repository.NewTruck(Truck);

            return RedirectToPage("./Index");
        }
    }
}
