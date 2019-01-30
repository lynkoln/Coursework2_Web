using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public int ReceiptNo { get; set; }
        [Required]
        public DateTime TimeOfPayment { get; set; }
        
        public decimal Total { get; set; }
        
        public int ParkingID { get; set; }
        public int Period {get;set;}
       
        public virtual ParkingSlot ParkingSlot { get; set; }
        public virtual Pricing Pricing { get; set; }

       



    }
}