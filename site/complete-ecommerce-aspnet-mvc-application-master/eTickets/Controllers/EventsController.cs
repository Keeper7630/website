using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync();
            return View(allEvents);
        }


        //Get: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Event events)
        {
            if (!ModelState.IsValid) return View(events);
            await _service.AddAsync(events);
            return RedirectToAction(nameof(Index));
        }

        //Get: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        //Get: Events/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Event events)
        {
            if (!ModelState.IsValid) return View(events);
            await _service.UpdateAsync(id, events);
            return RedirectToAction(nameof(Index));
        }

        //Get: Events/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
