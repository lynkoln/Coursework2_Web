using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;


namespace ParkingSystem.Pages.Customers
{
    public class EditModel : PageModel
    {
        public SelectList PositionSL { get; set; }

        public void PositionDropdown (ParkingSystemContext _context, object selectedPosition = null)
        {
            var positionQuery = from d in _context.PositionDiscount orderby d.Position select d;

            PositionSL = new SelectList(positionQuery.AsNoTracking(), "Price","Position", selectedPosition);
        }

        private readonly ParkingSystem.Models.ParkingSystemContext _context;
      
        public EditModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

    

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PositionDropdown(_context);
            {

            }
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.Include(c => c.PositionDiscount).FirstOrDefaultAsync(m => m.CustomerID == id);



            if (Customer == null)
            {
                return NotFound();
            }
            // Select current PositionDiscount.
            PositionDropdown(_context, Customer.PositionDiscount);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customer.FindAsync(id);

            if (await TryUpdateModelAsync<Customer>(
                 customerToUpdate,
                 "customer",   // Prefix for form value.
                   c=> c.CustomerID, c=>c.FirstName, c=>c.LastName, c=>c.PhoneNo,c=>c.Email,c=>c.PositionDiscount))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PositionDropdown(_context, customerToUpdate.CustomerID);
            return Page();
        }
    }
}