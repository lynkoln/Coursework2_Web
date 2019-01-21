using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.PositionDiscounts
{
    public class EditModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public EditModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionDiscount PositionDiscount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PositionDiscount = await _context.PositionDiscount.FirstOrDefaultAsync(m => m.Position == id);

            if (PositionDiscount == null)
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

            _context.Attach(PositionDiscount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionDiscountExists(PositionDiscount.Position))
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

        private bool PositionDiscountExists(string id)
        {
            return _context.PositionDiscount.Any(e => e.Position == id);
        }
    }
}
