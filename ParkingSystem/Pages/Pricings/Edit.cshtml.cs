using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.Pricings
{
    public class EditModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public EditModel(ParkingSystem.Models.ParkingSystemContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pricing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricingExists(Pricing.Period))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PricingExists(int id)
        {
            return _context.Pricing.Any(e => e.Period == id);
        }
    }
}
