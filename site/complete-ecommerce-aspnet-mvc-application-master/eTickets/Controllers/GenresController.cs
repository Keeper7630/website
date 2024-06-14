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
    public class GenresController : Controller
    {
        private readonly IGenresService _service;

        public GenresController(IGenresService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allGenres = await _service.GetAllAsync();
            return View(allGenres);
        }

        //GET: genres/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);
        }

        //GET: genres/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);

            await _service.AddAsync(genre);
            return RedirectToAction(nameof(Index));
        }

        //GET: genres/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);

            if(id == genre.Id)
            {
                await _service.UpdateAsync(id, genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        //GET: genres/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);
            if (genreDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
