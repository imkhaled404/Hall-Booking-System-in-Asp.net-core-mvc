using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHotelApp.Models;

namespace TheHotelApp.Controllers
{

    public class BookingsController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public BookingsController(Data.ApplicationDbContext Context)
        {
            _context = Context;
        }

        public IActionResult AllCreate()
        {

            return View();
        }
        // GET: BookingsController
        public async Task<ActionResult> Index()
        {
            List<Booking> Temp = await _context.Bookings.ToListAsync();
            List<Booking> ViewModel = new List<Booking>();
            foreach (var item in Temp)
            {
                item.Room = await _context.Rooms.FindAsync(item.RoomID);
                item.Customers = await _context.Customers.FindAsync(item.CustomerID);
                ViewModel.Add(item);
            }
            return View(ViewModel);
        }

        // GET: BookingsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingsController/Create
        public async Task<ActionResult> Create()
        {
            BookingAddModel Model = new BookingAddModel();
            Model.LstRoomTypes = await _context.RoomTypes.ToListAsync();
            Model.LstCustomers = await _context.Customers.ToListAsync();
            Model.LstRoom = await _context.Rooms.ToListAsync();
            Model.LstPayments = await _context.Payments.ToListAsync();
            return View(Model);
        }

        // POST: BookingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingAddModel model)
        {
            try
            {
                await _context.Bookings.AddAsync(model.Book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var x = ex;
                return View();
            }
        }

        // GET: BookingsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            BookingEditModel model = new BookingEditModel();
            model.Book = await _context.Bookings.FindAsync(id);
            model.LstCustomers = await _context.Customers.
                Select(e => new SelectListItem { Text = e.CustomerName.ToString(), Value = e.ID }).ToListAsync();
            model.LstPayments = await _context.Payments.
                Select(e => new SelectListItem { Text = e.PaymentType.ToString(), Value = e.PaymentID }).ToListAsync();
            model.LstRoomTypes = await _context.RoomTypes.
                Select(e => new SelectListItem { Text = e.Name.ToString(), Value = e.ID }).ToListAsync();
            model.LstRoom = await _context.Rooms.
                Select(e => new SelectListItem
                {
                    Text = e.Number.ToString(),
                    Value = e.ID
                }).ToListAsync();
            int roomIndex = model.LstRoom.FindIndex(e => e.Value == model.Book.RoomID);
            int Customer = model.LstCustomers.FindIndex(e => e.Value == model.Book.CustomerID);
            int Payment = model.LstPayments.FindIndex(e => e.Value == model.Book.PaymentID);
            int RoomType = model.LstRoomTypes.FindIndex(e => e.Value == model.Book.TypeID);
            if (roomIndex > 0)
            {
                model.LstRoom[roomIndex].Selected = true; }
            if (Customer > 0)
                {
                    model.LstCustomers[Customer].Selected = true;
                }
             if (Payment > 0) { model.LstPayments[Payment].Selected = true; }
                if (RoomType > 0) { model.LstRoomTypes[RoomType].Selected = true; }

                return View(model);
            }

            // POST: BookingsController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(BookingEditModel model)
            {
                
                _context.Entry(model.Book).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: BookingsController/Delete/5
            public async Task<ActionResult> Delete(string id)
            {
                var x = await _context.Bookings.FindAsync(id);
                _context.Remove(x);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
