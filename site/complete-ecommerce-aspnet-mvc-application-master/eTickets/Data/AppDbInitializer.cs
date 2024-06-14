using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
                            Name = "Концерт",
                            Logo = "https://i.postimg.cc/9MwW1pY6/image.jpg",
                            Description = "Публичное исполнение музыкальных произведений по определённой, заранее составленной, программе."
                        },
                        new Event()
                        {
                            Name = "Акустический концерт",
                            Logo = "https://i.postimg.cc/Qt73cMXs/image.jpg",
                            Description = "Концерт, в котором звучит только музыка, которую можно воспроизвести с помощью акустических инструментов или живого голоса."
                        },
                        new Event()
                        {
                            Name = "Фестиваль",
                            Logo = "https://i.postimg.cc/52PbVG7c/image.jpg",
                            Description = "Мероприятие, ориентированное на проведение различных музыкальных выступлений и демонстрацию инструментального мастерства."
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
                            FullName = "Мануилиди Мария",
                            Bio = "Ритм/лид гитарист, играет 5 лет. Основатель группы Blackwire.",
                            ProfilePictureURL = "https://i.postimg.cc/RFKHGwwY/msg730438509-27716.jpg"

                        },
                        new Member()
                        {
                            FullName = "Капулер Дмитрий",
                            Bio = "Клавишник, опыт игры - 5 лет. Частный преподаватель фортепиано.",
                            ProfilePictureURL = "https://i.postimg.cc/brd1m4Bz/image.jpg"
                        },
                        new Member()
                        {
                            FullName = "Денисова Дарья",
                            Bio = "Барабанщица, играет 4 года.",
                            ProfilePictureURL = "https://i.postimg.cc/tTBht9DS/image.jpg"
                        },
                        new Member()
                        {
                            FullName = "Едина Млада",
                            Bio = "Бас-гитарист, играет 3 года. Новый участник группы.",
                            ProfilePictureURL = "https://i.postimg.cc/nVdkqGPF/image.jpg"
                        },
                        new Member()
                        {
                            FullName = "Мартиросян Карина",
                            Bio = "Сессионный вокалист, близкий друг группы.",
                            ProfilePictureURL = "https://i.postimg.cc/bNsRgS7Q/image.jpg"
                        },
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
                            FullName = "Рок",
                            Bio = "Ряд направлений популярной музыки",
                            ProfilePictureURL = "https://i.postimg.cc/3RTrwpTm/image.jpg"

                        },
                        new Genre()
                        {
                            FullName = "Инди-рок",
                            Bio = "Широкий диапазон музыкантов и стилей, объединённых причастностью к контркультуре и имеющих отношение к рок-музыке.",
                            ProfilePictureURL = "https://i.postimg.cc/k5x9L4b4/image.jpg"
                        },
                        new Genre()
                        {
                            FullName = "Экспериментальная музыка",
                            Bio = "Музыкальные произведения, использующие необычный инструментарий или новые композиционные принципы.",
                            ProfilePictureURL = "https://i.postimg.cc/xT0kRwBM/image.jpg"
                        },
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
                            Name = "Москва",
                            Description = "просп. Андропова 1",
                            Price = 2500,
                            ImageURL = "https://i.postimg.cc/k5dZLy9r/image.jpg",
                            StartDate = new DateTime(2024, 5, 30, 0, 0, 0),
                            StartTime = new TimeSpan(21, 0, 0),
                            EventId = 1,
                            GenreId = 1,
                            TownCategory = TownCategory.cat_21
                        },
                        new Town()
                        {
                            Name = "Санкт-Петербург",
                            Description = "просп. Невский 30",
                            Price = 2500,
                            ImageURL = "https://i.postimg.cc/tJ7mFSd6/image.jpg",
                            StartDate = new DateTime(2024, 6, 6, 0, 0, 0),
                            StartTime = new TimeSpan(21, 0, 0),
                            EventId = 2,
                            GenreId = 1,
                            TownCategory = TownCategory.cat_16
                        },
                        new Town()
                        {
                            Name = "Казань",
                            Description = "пл. Свободы 3",
                            Price = 2300,
                            ImageURL = "https://i.postimg.cc/tCKmVzs1/image.jpg",
                            StartDate = new DateTime(2024, 6, 12, 0, 0, 0),
                            StartTime = new TimeSpan(20, 0, 0),
                            EventId = 2,
                            GenreId = 2,
                            TownCategory = TownCategory.cat_16
                        },
                        new Town()
                        {
                            Name = "Челябинск",
                            Description = "ул. Кирова 78",
                            Price = 2000,
                            ImageURL = "https://i.postimg.cc/W4n9CLXr/image.jpg",
                            StartDate = new DateTime(2024, 6, 17, 0, 0, 0),
                            StartTime = new TimeSpan(20, 0, 0),
                            EventId = 1,
                            GenreId = 2,
                            TownCategory = TownCategory.cat_18
                        },
                        new Town()
                        {
                            Name = "Тольятти",
                            Description = "ул. Юбилейная 24",
                            Price = 2200,
                            ImageURL = "https://i.postimg.cc/wBHfwTcg/image.jpg",
                            StartDate = new DateTime(2024, 6, 23, 0, 0, 0),
                            StartTime = new TimeSpan(18, 0, 0),
                            EventId = 1,
                            GenreId = 3,
                            TownCategory = TownCategory.cat_18
                        },
                        new Town()
                        {
                            Name = "Владивосток",
                            Description = "ул. Верхнепортовая 38",
                            Price = 2000,
                            ImageURL = "https://i.postimg.cc/XY91Ky5s/image.jpg",
                            StartDate = new DateTime(2024, 6, 29, 0, 0, 0),
                            StartTime = new TimeSpan(19, 0, 0),
                            EventId = 1,
                            GenreId = 3,
                            TownCategory = TownCategory.cat_21
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
