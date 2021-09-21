using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheHotelApp.Models;

namespace TheHotelApp.Models
{
    public class BookingAddModel
    {
        public Booking Book { get; set; }
        public  List<Room>  LstRoom { get; set; }
        public List<Customer> LstCustomers { get; set; }
        public List<RoomType> LstRoomTypes { get; set; }
        public List<Payment> LstPayments { get; set; }
    }
    public class BookingEditModel
    {
        public Booking Book { get; set; }
        public List<SelectListItem> LstRoom { get; set; }
        public List<SelectListItem> LstCustomers { get; set; }
        public List<SelectListItem> LstRoomTypes { get; set; }
        public List<SelectListItem> LstPayments { get; set; }
    }
    public class Booking
    {
        public string ID { get; set; }
        [Required]
        public string AgreementNumber { get; set; }

        public string RoomID { get; set; }
        public virtual Room Room { get; set; }
        public string CustomerID { get; set; }
        public virtual Customer Customers { get; set; }
        public string TypeID { get; set; }
        public virtual RoomType RoomTypes { get; set; }
        [Required]
        public string ApplicantName { get; set; }
        
        public string Address { get; set; }

        [Required]
        [DisplayName("Rental Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RentalDate { get; set; }
        [DisplayName("Rental Period")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        [DataType(DataType.Time)]
        public string RentalPeriod{ get; set;}
        [Required]
        [DisplayName("Appliacation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ApplicationDate { get; set; }
        public String ChiefGuests { get; set; }
        public String SpeciaGuests { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        public String Subject { get; set; }
        public bool Completed { get; set; }
        public string PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual Payment Payments { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}