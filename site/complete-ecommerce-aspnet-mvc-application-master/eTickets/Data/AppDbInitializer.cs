using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Event
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Event 1",
                            Logo = "http://dotnethow.net/images/events/event-1.jpeg",
                            Description = "This is the description of the first event"
                        },
                        new Event()
                        {
                            Name = "Event 2",
                            Logo = "http://dotnethow.net/images/events/event-2.jpeg",
                            Description = "This is the description of the first event"
                        },
                        new Event()
                        {
                            Name = "Event 3",
                            Logo = "http://dotnethow.net/images/events/event-3.jpeg",
                            Description = "This is the description of the first event"
                        },
                        new Event()
                        {
                            Name = "Event 4",
                            Logo = "http://dotnethow.net/images/events/event-4.jpeg",
                            Description = "This is the description of the first event"
                        },
                        new Event()
                        {
                            Name = "Event 5",
                            Logo = "http://dotnethow.net/images/events/event-5.jpeg",
                            Description = "This is the description of the first event"
                        },
                    });
                    context.SaveChanges();
                }
                //Members
                if (!context.Members.Any())
                {
                    context.Members.AddRange(new List<Member>()
                    {
                        new Member()
                        {
                            FullName = "Member 1",
                            Bio = "This is the Bio of the first member",
                            ProfilePictureURL = "http://dotnethow.net/images/members/member-1.jpeg"

                        },
                        new Member()
                        {
                            FullName = "Member 2",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/members/member-2.jpeg"
                        },
                        new Member()
                        {
                            FullName = "Member 3",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/members/member-3.jpeg"
                        },
                        new Member()
                        {
                            FullName = "Member 4",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/members/member-4.jpeg"
                        },
                        new Member()
                        {
                            FullName = "Member 5",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/members/member-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Genres
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new List<Genre>()
                    {
                        new Genre()
                        {
                            FullName = "Genre 1",
                            Bio = "This is the Bio of the first member",
                            ProfilePictureURL = "http://dotnethow.net/images/genres/genre-1.jpeg"

                        },
                        new Genre()
                        {
                            FullName = "Genre 2",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/genres/genre-2.jpeg"
                        },
                        new Genre()
                        {
                            FullName = "Genre 3",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/genres/genre-3.jpeg"
                        },
                        new Genre()
                        {
                            FullName = "Genre 4",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/genres/genre-4.jpeg"
                        },
                        new Genre()
                        {
                            FullName = "Genre 5",
                            Bio = "This is the Bio of the second member",
                            ProfilePictureURL = "http://dotnethow.net/images/genres/genre-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Towns
                if (!context.Towns.Any())
                {
                    context.Towns.AddRange(new List<Town>()
                    {
                        new Town()
                        {
                            Name = "Life",
                            Description = "This is the Life town description",
                            Price = 2500,
                            ImageURL = "http://dotnethow.net/images/towns/town-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            StartTime = new TimeSpan(21, 0, 0),
                            EventId = 3,
                            GenreId = 3,
                            TownCategory = TownCategory.Documentary
                        },
                        new Town()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 2500,
                            ImageURL = "http://dotnethow.net/images/towns/town-1.jpeg",
                            StartDate = DateTime.Now,
                            StartTime = new TimeSpan(21, 0, 0),
                            EventId = 1,
                            GenreId = 1,
                            TownCategory = TownCategory.Action
                        },
                        new Town()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost town description",
                            Price = 2300,
                            ImageURL = "http://dotnethow.net/images/towns/town-4.jpeg",
                            StartDate = DateTime.Now,
                            StartTime = new TimeSpan(19, 0, 0),
                            EventId = 4,
                            GenreId = 4,
                            TownCategory = TownCategory.Horror
                        },
                        new Town()
                        {
                            Name = "Race",
                            Description = "This is the Race town description",
                            Price = 2000,
                            ImageURL = "http://dotnethow.net/images/towns/town-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            StartTime = new TimeSpan(20, 0, 0),
                            EventId = 1,
                            GenreId = 2,
                            TownCategory = TownCategory.Documentary
                        },
                        new Town()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob town description",
                            Price = 2200,
                            ImageURL = "http://dotnethow.net/images/towns/town-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            StartTime = new TimeSpan(18, 0, 0),
                            EventId = 1,
                            GenreId = 3,
                            TownCategory = TownCategory.Cartoon
                        },
                        new Town()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles town description",
                            Price = 1800,
                            ImageURL = "http://dotnethow.net/images/towns/town-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            StartTime = new TimeSpan(20, 0, 0),
                            EventId = 1,
                            GenreId = 5,
                            TownCategory = TownCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Members & Towns
                if (!context.Members_Towns.Any())
                {
                    context.Members_Towns.AddRange(new List<Member_Town>()
                    {
                        new Member_Town()
                        {
                            MemberId = 1,
                            TownId = 1
                        },
                        new Member_Town()
                        {
                            MemberId = 3,
                            TownId = 1
                        },

                         new Member_Town()
                        {
                            MemberId = 1,
                            TownId = 2
                        },
                         new Member_Town()
                        {
                            MemberId = 4,
                            TownId = 2
                        },

                        new Member_Town()
                        {
                            MemberId = 1,
                            TownId = 3
                        },
                        new Member_Town()
                        {
                            MemberId = 2,
                            TownId = 3
                        },
                        new Member_Town()
                        {
                            MemberId = 5,
                            TownId = 3
                        },


                        new Member_Town()
                        {
                            MemberId = 2,
                            TownId = 4
                        },
                        new Member_Town()
                        {
                            MemberId = 3,
                            TownId = 4
                        },
                        new Member_Town()
                        {
                            MemberId = 4,
                            TownId = 4
                        },


                        new Member_Town()
                        {
                            MemberId = 2,
                            TownId = 5
                        },
                        new Member_Town()
                        {
                            MemberId = 3,
                            TownId = 5
                        },
                        new Member_Town()
                        {
                            MemberId = 4,
                            TownId = 5
                        },
                        new Member_Town()
                        {
                            MemberId = 5,
                            TownId = 5
                        },


                        new Member_Town()
                        {
                            MemberId = 3,
                            TownId = 6
                        },
                        new Member_Town()
                        {
                            MemberId = 4,
                            TownId = 6
                        },
                        new Member_Town()
                        {
                            MemberId = 5,
                            TownId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
