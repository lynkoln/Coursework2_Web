﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Pages.ParkingSlots
{
    public class DetailsModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public DetailsModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }
        public object fullname;
        public object GetFullName(int z)
        {
            var item = (from x in _context.Customer
                        where (x.CustomerID == z)
                        select x.FirstName + " " + x.LastName).Single();
            fullname = item;
            return fullname;
        }
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
    }
}
