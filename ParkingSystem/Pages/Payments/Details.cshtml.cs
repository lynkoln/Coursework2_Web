using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.Payments
{
    public class DetailsModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public DetailsModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public Payment Payment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment = await _context.Payment.FirstOrDefaultAsync(m => m.ReceiptNo == id);

            if (Payment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
