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
    public class DeleteModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public DeleteModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pricing Pricing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pricing = await _context.Pricing.FirstOrDefaultAsync(m => m.Period == id);

            if (Pricing == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pricing = await _context.Pricing.FindAsync(id);

            if (Pricing != null)
            {
                _context.Pricing.Remove(Pricing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
