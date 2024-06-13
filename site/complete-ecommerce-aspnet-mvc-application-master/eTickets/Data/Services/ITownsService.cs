using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface ITownsService:IEntityBaseRepository<Town>
    {
        Task<Town> GetTownByIdAsync(int id);
        Task<NewTownDropdownsVM> GetNewTownDropdownsValues();
        Task AddNewTownAsync(NewTownVM data);
        Task UpdateTownAsync(NewTownVM data);
    }
}
