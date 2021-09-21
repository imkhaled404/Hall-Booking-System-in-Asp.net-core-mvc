using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHotelApp.Models;
using TheHotelApp.Services;

namespace TheHotelApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IGenericHotelService<Customer> _hotelService;

        public CustomersController(IGenericHotelService<Customer> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }
        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _hotelService.GetItemByIdAsync(id);


            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,CustomerPhone,CustomerEmail,PrimaryAddress,PrimaryContact,OtherAddress,OtherContact")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _hotelService.GetItemByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerName,CustomerPhone,CustomerEmail,PrimaryAddress,PrimaryContact,OtherAddress,OtherContact")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.EditItemAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _hotelService.GetItemByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
