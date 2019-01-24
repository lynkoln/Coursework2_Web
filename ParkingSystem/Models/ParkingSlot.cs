using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class ParkingSlot
    {
        [Key]
        [Required]
        public int ParkingID { get; set; }
        [Required]
        public string Plate { get; set; }
        [Required]
        public DateTime TimeIn { get; set; }
        
        public DateTime? TimeOut { get; set; }


        public ICollection<Payment> PaymentID { get; set; }


    }
}