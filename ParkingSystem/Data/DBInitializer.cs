using ParkingSystem.Models;
using System;
using System.Linq;

namespace ParkingSystem.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ParkingSystemContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{FirstName="Bob",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="Adam",LastName="Alexander",PhoneNo="4478569874",Email=""},
            new Customer{FirstName="Cecil",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="Derek",LastName="Alexander",PhoneNo="4478569874",Email=""},
            new Customer{FirstName="Edvin",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="Fred",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="George",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="Harry",LastName="Alexander",PhoneNo="4478569874",Email="bob@email.com"},
            new Customer{FirstName="Iana",LastName="Alexander",PhoneNo="4478569874",Email=""}

            };
            foreach (Customer s in customers)
            {
                context.Customer.Add(s);
            }
            context.SaveChanges();

            var parkingslots = new ParkingSlot[]
            {
            new ParkingSlot{Plate="HN11 AQW", TimeIn=DateTime.Parse("2005-09-01 12:13"), TimeOut=DateTime.Parse("2005-09-01 15:13"), },
            new ParkingSlot{Plate="ES11 AQW", TimeIn=DateTime.Parse("2005-09-01 12:11"), TimeOut=DateTime.Parse("2005-09-01 16:13"), },
            new ParkingSlot{Plate="HN01 AQW", TimeIn=DateTime.Parse("2005-09-01 12:42"), TimeOut=DateTime.Parse("2005-09-01 17:13"), },
            new ParkingSlot{Plate="HN44 AQW", TimeIn=DateTime.Parse("2005-09-01 10:13"), TimeOut=DateTime.Parse("2005-09-01 18:13"), },
            new ParkingSlot{Plate="HN11 ZEE", TimeIn=DateTime.Parse("2005-09-01 12:56"), TimeOut=DateTime.Parse("2005-09-01 19:13"), },
            new ParkingSlot{Plate="HN11 DEE", TimeIn=DateTime.Parse("2005-09-01 11:13"), TimeOut=DateTime.Parse("2005-09-01 21:13"), }

            };
            foreach (ParkingSlot c in parkingslots)
            {
                context.ParkingSlot.Add(c);
            }
            context.SaveChanges();

            var positiondiscounts = new PositionDiscount[]
            {
            new PositionDiscount{Position="Student", Price=0.2f},
            new PositionDiscount{Position="Worker", Price=0.3f},
            new PositionDiscount{Position="Senior", Price=0.2f},
            new PositionDiscount{Position="Manager", Price=0.5f}

            };
            foreach (PositionDiscount e in positiondiscounts)
            {
                context.PositionDiscount.Add(e);
            }
            context.SaveChanges();

            var pricings = new Pricing[]
   {
            new Pricing{Period=1,Price=1.2f},
            new Pricing{Period=2,Price=2},
            new Pricing{Period=3,Price=3},
            new Pricing{Period=4,Price=3.8f},
            new Pricing{Period=5,Price=4.5f},
            new Pricing{Period=6,Price=5.2f}


   };
            foreach (Pricing e in pricings)
            {
                context.Pricing.Add(e);
            }
            context.SaveChanges();



    }
}