using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MembersController : Controller
    {
        private readonly IMembersService _service;

        public MembersController(IMembersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            await _service.AddAsync(member);
            return RedirectToAction(nameof(Index));
        }

        //Get: Members/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var memberDetails = await _service.GetByIdAsync(id);

            if (memberDetails == null) return View("NotFound");
            return View(memberDetails);
        }

        //Get: Members/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var memberDetails = await _service.GetByIdAsync(id);
            if (memberDetails == null) return View("NotFound");
            return View(memberDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            await _service.UpdateAsync(id, member);
            return RedirectToAction(nameof(Index));
        }

        //Get: Members/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var memberDetails = await _service.GetByIdAsync(id);
            if (memberDetails == null) return View("NotFound");
            return View(memberDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberDetails = await _service.GetByIdAsync(id);
            if (memberDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
