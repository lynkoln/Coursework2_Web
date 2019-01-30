using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Models
{
    public class PositionDiscount
    {
        [Key]
        [Required]
        public int PositionID { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public float Price { get; set; }

        public ICollection<Customer> CustomerID { get; set; }
    }
}
