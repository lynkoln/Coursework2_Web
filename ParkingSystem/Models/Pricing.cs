using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class Pricing
    {
        [Key]
        [Required]
        public int Period { get; set; }
        [Required]
        public float Price { get; set; }


        public ICollection<Payment> PaymentID { get; set; }
    }
}