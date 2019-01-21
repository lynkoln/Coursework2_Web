using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.Pricings
{
    public class IndexModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public IndexModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IList<Pricing> Pricing { get;set; }

        public async Task OnGetAsync()
        {
            Pricing = await _context.Pricing.ToListAsync();
        }
    }
}
