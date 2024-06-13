using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewTownDropdownsVM
    {
        public NewTownDropdownsVM()
        {
            Genres = new List<Genre>();
            Events = new List<Event>();
            Members = new List<Member>();
        }

        public List<Genre> Genres { get; set; }
        public List<Event> Events { get; set; }
        public List<Member> Members { get; set; }
    }
}
