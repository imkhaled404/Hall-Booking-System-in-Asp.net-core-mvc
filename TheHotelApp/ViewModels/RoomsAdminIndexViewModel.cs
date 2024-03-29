﻿using TheHotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHotelApp.ViewModels
{
    public class RoomsAdminIndexViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
