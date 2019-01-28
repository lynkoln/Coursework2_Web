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
    public class IndexModel : PageModel
    {
        private readonly ParkingSystem.Models.ParkingSystemContext _context;

        public IndexModel(ParkingSystem.Models.ParkingSystemContext context)
        {
            _context = context;
        }
        public object fullname { get; set; }

         public object GetFullName(int z)
        {
            var item = (from x in _context.Customer
                        where (x.CustomerID == z)
                        select x.FirstName+" "+x.LastName).Single();
            fullname = item;
            return fullname;
        }
        public IList<ParkingSlot> ParkingSlot { get;set; }

        public async Task OnGetAsync(int? id)
        {
            
            ParkingSlot = await _context.ParkingSlot.ToListAsync();
        }
    }
}
