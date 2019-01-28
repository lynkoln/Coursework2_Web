using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.ParkingSlots
{
    public class EditModel : PageModel
    {
        public SelectList CustomerSL { get; set; }

        public void CustomerDropdown(ParkingSystemContext _context, object selectedCustomer = null)
        {
            var customerQuery = from d in _context.Customer
                                orderby d.CustomerID
                                select new SelectListItem
                                {
                                    Text = d.FirstName + " " + d.LastName,
                                    Value = d.CustomerID.ToString()
                                }; ;

            CustomerSL = new SelectList(customerQuery, "Value", "Text", selectedCustomer);
        }
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public EditModel(ParkingSystem.Models.ParkingSystemContext context)
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
            CustomerDropdown(_context);
            ParkingSlot = await _context.ParkingSlot.FirstOrDefaultAsync(m => m.ParkingID == id);

            if (ParkingSlot == null)
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

           
            _context.Attach(ParkingSlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingSlotExists(ParkingSlot.ParkingID))
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

        private bool ParkingSlotExists(int id)
        {
            return _context.ParkingSlot.Any(e => e.ParkingID == id);
        }

    }
}
