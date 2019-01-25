using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public virtual PositionDiscount PositionDiscount { get; set; }

        public ICollection<ParkingSlot> ParkingID { get; set; }

        public ICollection<Payment> PaymentID { get; set; }

    }
}