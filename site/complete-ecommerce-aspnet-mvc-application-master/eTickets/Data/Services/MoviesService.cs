using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class TownsService : EntityBaseRepository<Town>, ITownsService
    {
        private readonly AppDbContext _context;
        public TownsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewTownAsync(NewTownVM data)
        {
            var newTown = new Town()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                EventId = data.EventId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                TownCategory = data.TownCategory,
                GenreId = data.GenreId
            };
            await _context.Towns.AddAsync(newTown);
            await _context.SaveChangesAsync();

            //Add Town Members
            foreach (var memberId in data.MemberIds)
            {
                var newMemberTown = new Member_Town()
                {
                    TownId = newTown.Id,
                    MemberId = memberId
                };
                await _context.Members_Towns.AddAsync(newMemberTown);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Town> GetTownByIdAsync(int id)
        {
            var townDetails = await _context.Towns
                .Include(c => c.Event)
                .Include(p => p.Genre)
                .Include(am => am.Members_Towns).ThenInclude(a => a.Member)
                .FirstOrDefaultAsync(n => n.Id == id);

            return townDetails;
        }

        public async Task<NewTownDropdownsVM> GetNewTownDropdownsValues()
        {
            var response = new NewTownDropdownsVM()
            {
                Members = await _context.Members.OrderBy(n => n.FullName).ToListAsync(),
                Events = await _context.Events.OrderBy(n => n.Name).ToListAsync(),
                Genres = await _context.Genres.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateTownAsync(NewTownVM data)
        {
            var dbTown = await _context.Towns.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbTown != null)
            {
                dbTown.Name = data.Name;
                dbTown.Description = data.Description;
                dbTown.Price = data.Price;
                dbTown.ImageURL = data.ImageURL;
                dbTown.EventId = data.EventId;
                dbTown.StartDate = data.StartDate;
                dbTown.EndDate = data.EndDate;
                dbTown.TownCategory = data.TownCategory;
                dbTown.GenreId = data.GenreId;
                await _context.SaveChangesAsync();
            }

            //Remove existing members
            var existingMembersDb = _context.Members_Towns.Where(n => n.TownId == data.Id).ToList();
            _context.Members_Towns.RemoveRange(existingMembersDb);
            await _context.SaveChangesAsync();

            //Add Town Members
            foreach (var memberId in data.MemberIds)
            {
                var newMemberTown = new Member_Town()
                {
                    TownId = data.Id,
                    MemberId = memberId
                };
                await _context.Members_Towns.AddAsync(newMemberTown);
            }
            await _context.SaveChangesAsync();
        }
    }
}
