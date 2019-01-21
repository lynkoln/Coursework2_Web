using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.PositionDiscounts
{
    public class IndexModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public IndexModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IList<PositionDiscount> PositionDiscount { get;set; }

        public async Task OnGetAsync()
        {
            PositionDiscount = await _context.PositionDiscount.ToListAsync();
        }
    }
}
