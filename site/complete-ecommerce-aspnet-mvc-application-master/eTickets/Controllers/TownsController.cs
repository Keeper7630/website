using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TownsController : Controller
    {
        private readonly ITownsService _service;

        public TownsController(ITownsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTowns = await _service.GetAllAsync(n => n.Event);
            return View(allTowns);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allTowns = await _service.GetAllAsync(n => n.Event);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allTowns.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allTowns);
        }

        //GET: Towns/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var townDetail = await _service.GetTownByIdAsync(id);
            return View(townDetail);
        }

        //GET: Towns/Create
        public async Task<IActionResult> Create()
        {
            var townDropdownsData = await _service.GetNewTownDropdownsValues();

            ViewBag.Events = new SelectList(townDropdownsData.Events, "Id", "Name");
            ViewBag.Genres = new SelectList(townDropdownsData.Genres, "Id", "FullName");
            ViewBag.Members = new SelectList(townDropdownsData.Members, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTownVM town)
        {
            if (!ModelState.IsValid)
            {
                var townDropdownsData = await _service.GetNewTownDropdownsValues();

                ViewBag.Events = new SelectList(townDropdownsData.Events, "Id", "Name");
                ViewBag.Genres = new SelectList(townDropdownsData.Genres, "Id", "FullName");
                ViewBag.Members = new SelectList(townDropdownsData.Members, "Id", "FullName");

                return View(town);
            }

            await _service.AddNewTownAsync(town);
            return RedirectToAction(nameof(Index));
        }


        //GET: Towns/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var townDetails = await _service.GetTownByIdAsync(id);
            if (townDetails == null) return View("NotFound");

            var response = new NewTownVM()
            {
                Id = townDetails.Id,
                Name = townDetails.Name,
                Description = townDetails.Description,
                Price = townDetails.Price,
                StartDate = townDetails.StartDate,
                StartTime = townDetails.StartTime,
                ImageURL = townDetails.ImageURL,
                TownCategory = townDetails.TownCategory,
                EventId = townDetails.EventId,
                GenreId = townDetails.GenreId,
                MemberIds = townDetails.Members_Towns.Select(n => n.MemberId).ToList(),
            };

            var townDropdownsData = await _service.GetNewTownDropdownsValues();
            ViewBag.Events = new SelectList(townDropdownsData.Events, "Id", "Name");
            ViewBag.Genres = new SelectList(townDropdownsData.Genres, "Id", "FullName");
            ViewBag.Members = new SelectList(townDropdownsData.Members, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewTownVM town)
        {
            if (id != town.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var townDropdownsData = await _service.GetNewTownDropdownsValues();

                ViewBag.Events = new SelectList(townDropdownsData.Events, "Id", "Name");
                ViewBag.Genres = new SelectList(townDropdownsData.Genres, "Id", "FullName");
                ViewBag.Members = new SelectList(townDropdownsData.Members, "Id", "FullName");

                return View(town);
            }

            await _service.UpdateTownAsync(town);
            return RedirectToAction(nameof(Index));
        }
    }
}