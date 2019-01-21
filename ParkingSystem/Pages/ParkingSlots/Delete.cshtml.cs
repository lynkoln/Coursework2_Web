using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.ParkingSlots
{
    public class DeleteModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public DeleteModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkingSlot ParkingSlot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingSlot = await _context.ParkingSlot.FirstOrDefaultAsync(m => m.ParkingID == id);

            if (ParkingSlot == null)
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

            ParkingSlot = await _context.ParkingSlot.FindAsync(id);

            if (ParkingSlot != null)
            {
                _context.ParkingSlot.Remove(ParkingSlot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
