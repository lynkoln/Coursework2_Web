using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Models;

namespace ParkingSystem.Models
{
    public class ParkingSystemContext : DbContext
    {
        public ParkingSystemContext (DbContextOptions<ParkingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingSystem.Models.ParkingSlot> ParkingSlot { get; set; }
        public DbSet<ParkingSystem.Models.Payment> Payment { get; set; }
        public DbSet<ParkingSystem.Models.Admin> Admin { get; set; }
        public DbSet<ParkingSystem.Models.Customer> Customer { get; set; }
        public DbSet<ParkingSystem.Models.PositionDiscount> PositionDiscount { get; set; }
        public DbSet<ParkingSystem.Models.Pricing> Pricing { get; set; }

    }
}
