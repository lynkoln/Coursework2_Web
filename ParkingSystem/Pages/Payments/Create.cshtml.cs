using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.Payments
{
    public class CreateModel : PageModel
    {

        public SelectList ParkingSL { get; set; }

        public void ParkingDropdown(ParkingSystemContext _context, object selectedParking = null)
        {
            var customerQuery = from d in _context.ParkingSlot
                                orderby d.ParkingID
                                select new SelectListItem
                                {
                                    Text = d.Plate,
                                    Value = d.ParkingID.ToString()
                                }; ;

            ParkingSL = new SelectList(customerQuery, "Value", "Text", selectedParking);
        }

        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public CreateModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ParkingDropdown(_context);
            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Payment.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}