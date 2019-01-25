using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.Customers
{
    public class CreateModel : PageModel
    {
        public SelectList PositionSL { get; set; }

        public void PositionDropdown(ParkingSystemContext _context, object selectedPosition = null)
        {
            var positionQuery = from d in _context.PositionDiscount orderby d.Position select d;

            PositionSL = new SelectList(positionQuery, "Price", "Position", selectedPosition);
        }

        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public CreateModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PositionDropdown(_context);
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCustomer = new Customer();

            if (await TryUpdateModelAsync<Customer>(
                 emptyCustomer,
                 "customer",   // Prefix for form value.
                   c => c.CustomerID, c => c.FirstName, c => c.LastName, c => c.PhoneNo, c => c.Email, c => c.PositionDiscount))
            {
                _context.Customer.Add(emptyCustomer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PositionDropdown(_context, emptyCustomer.CustomerID);
            return Page();
        }
    }
}