using web.Models;
using System;
using System.Linq;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ParkingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var user = new User[]
            {
            new User{Name="Anze",Surname="Novak"},
            new User{Name="Jan",Surname="Kokalj"},
            new User{Name="Denis",Surname="Mikic"},
            new User{Name="Zan",Surname="Aleksander"},
            };
            foreach (User s in user)
            {
                context.User.Add(s);
            }
            context.SaveChanges();

            var car = new Car[]
            {
            new Car{CarID=1,CarType="Kia Creed",CarColor="red"},
            new Car{CarID=2,CarType="Audi R6",CarColor="white"},
            new Car{CarID=3,CarType="Merzedes C3130",CarColor="black"},
            new Car{CarID=4,CarType="Toyota Yaris",CarColor="green"},
            };
            foreach (Car c in car)
            {
                context.Car.Add(c);
            }
            context.SaveChanges();

            var spot = new Spot[]
            {
            new Spot{SpotID=1,SpotNumber=4,SpotName="Zivalski vrt"},
            new Spot{SpotID=2,SpotNumber=3,SpotName="FRI garaza"},
            new Spot{SpotID=3,SpotNumber=12,SpotName="Zivalski vrt 2"},
            new Spot{SpotID=4,SpotNumber=5,SpotName="Makadam"},
            };
            foreach (Spot c in spot)
            {
                context.Spot.Add(c);
            }
            context.SaveChanges();

            var time = new Time[]
            {
            new Time{TimeID=1,Arrival=DateTime.Parse("2005-09-01"),Departure=DateTime.Parse("2005-09-02")},
            new Time{TimeID=2,Arrival=DateTime.Parse("2005-09-03"),Departure=DateTime.Parse("2005-09-04")},
            new Time{TimeID=3,Arrival=DateTime.Parse("2005-09-05"),Departure=DateTime.Parse("2005-09-06")},
            new Time{TimeID=4,Arrival=DateTime.Parse("2005-09-07"),Departure=DateTime.Parse("2005-09-08")},
            };
            foreach (Time c in time)
            {
                context.Time.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{UserID=1,CarID=1,SpotID=1,TimeID=1},
            new Enrollment{UserID=2,CarID=2,SpotID=2,TimeID=2},
            new Enrollment{UserID=3,CarID=3,SpotID=3,TimeID=3},
            new Enrollment{UserID=4,CarID=4,SpotID=4,TimeID=4},
            
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
            // var roles = new IdentityRole[]
            // {
            //     new IdentityRole{Id="1", Name = "Administrator"},
            //     new IdentityRole{Id="2", Name = "Manager"},
            //     new IdentityRole{Id="3", Name = "Staff"},
            // };
            // foreach(IdentityRole r in roles)
            // {
            //     context.Roles.add(r);
            // }
            // context.SaveChanges();

            // var user = new ApplicationUser
            // {
            //     Name = "Denis",
            //     Surname = "Mikic",
            //     City = "Naklo",
            //     Email = "dm5060@student.uni-lj.si",
            //     NormalizedEmail = "DM@fri.si",
            //     UserName = "denis@fri.si",
            //     NormalizedUserName = "denismikic@fri.si",
            //     PhoneNumber = "040981072",
            //     EmailConfirmed = true,
            //     PhoneNumberConfirmed = true,
            //     SecurityStamp = Guid.NewGuid().ToString("D")
            // };

            // if (!context.Users.Any(u=> u.UserName == user.UserName))
            // {
            //     var password = new PasswordHasher<ApplicationUser>();
            //     var hashed = password.HashPassword(user,"Test123");
            //     user.PasswordHash = hashed;
            //     context.Users.Add(user);

            // }
            // context.SaveChanges();

            // var UserRoles = new IdentityUserRole<string>[]
            // {
            //     new IdentityUserRole<string>{RoleId=roles[0].Id, UserId = user.Id},
            //     new IdentityUserRole<string>{RoleId=roles[1].Id, UserId = user.Id},
            // };
            // foreach(IdentityUserRole<string> r in UserRoles)
            // {
            //     context.UserRoles.Add(r);
            // }
            // context.SaveChanges();
        }
    }
}