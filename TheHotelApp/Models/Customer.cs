using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.Models
{
    public class Customer
    {
        public string ID { get; set; }
        [Required]
        [DisplayName("Customer Name:")]
        public string CustomerName { get; set; }
        [Required]
        [DisplayName("Phone:")]
        public string CustomerPhone { get; set; }

        [Required]
        [DisplayName("Email:")]
        public string CustomerEmail { get; set; }


        [Required]
        [DisplayName("Primary Address:")]
        public string PrimaryAddress { get; set; }
        [Required]
        [DisplayName("Primary Contact:")]
        public string PrimaryContact { get; set; }

        [DisplayName("Other Address:")]
        public string OtherAddress { get; set; }
        [DisplayName("Other Contact:")]
        public string OtherContact { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
