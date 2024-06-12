using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Member_Town
    {
        public int TownId { get; set; }
        public Town Town { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
