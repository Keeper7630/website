using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member_Town>().HasKey(am => new
            {
                am.MemberId,
                am.TownId
            });

            modelBuilder.Entity<Member_Town>().HasOne(m => m.Town).WithMany(am => am.Members_Towns).HasForeignKey(m => m.TownId);
            modelBuilder.Entity<Member_Town>().HasOne(m => m.Member).WithMany(am => am.Members_Towns).HasForeignKey(m => m.MemberId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Member_Town> Members_Towns { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
