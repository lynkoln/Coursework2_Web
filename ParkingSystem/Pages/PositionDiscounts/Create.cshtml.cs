﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.PositionDiscounts
{
    public class CreateModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public CreateModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PositionDiscount PositionDiscount { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PositionDiscount.Add(PositionDiscount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}