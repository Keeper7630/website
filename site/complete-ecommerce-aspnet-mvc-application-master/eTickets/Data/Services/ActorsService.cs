using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MembersService : EntityBaseRepository<Member>, IMembersService
    {
        public MembersService(AppDbContext context) : base(context) { }
    }
}
