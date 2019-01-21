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
    public class DeleteModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public DeleteModel(ParkingSystem.Models.ParkingSystemContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PositionDiscount = await _context.PositionDiscount.FindAsync(id);

            if (PositionDiscount != null)
            {
                _context.PositionDiscount.Remove(PositionDiscount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
