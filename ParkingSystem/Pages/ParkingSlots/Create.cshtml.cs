using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.ParkingSlots
{

    public class CreateModel : PageModel
    {
        public SelectList CustomerSL { get; set; }

        public void CustomerDropdown(ParkingSystemContext _context, object selectedCustomer = null)
        {
            var customerQuery = from d in _context.Customer orderby d.CustomerID
                                select new SelectListItem
                                {
                                   Text = d.FirstName +" "+ d.LastName ,
                                   Value = d.CustomerID.ToString()
                                }; ;

            CustomerSL = new SelectList(customerQuery, "Value","Text", selectedCustomer);
        }

        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public CreateModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CustomerDropdown(_context);
            return Page();
        }

        [BindProperty]
        public ParkingSlot ParkingSlot { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingSlot.Add(ParkingSlot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}