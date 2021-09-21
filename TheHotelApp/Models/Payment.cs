using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class Payment
    {
        public string PaymentID { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
