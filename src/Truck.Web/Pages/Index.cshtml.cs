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
    public class IndexModel : PageModel
    {
        private readonly ITruckRepository _repository;

        public IndexModel(ITruckRepository repository)
        {
            _repository = repository;
        }

        public IList<Core.Entities.Truck> Trucks { get;set; }

        public async Task OnGetAsync()
        {
            Trucks = (await _repository.GetAllTrucksAsync()).ToList();
        }
    }
}
