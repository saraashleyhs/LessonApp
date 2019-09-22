using System;
using System.Collections.Generic;
using System.Linq;
using LessonApp.Core;
using LessonApp.Core.Models;
using LessonApp.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace LessonApp.API
{
    public class DbInitializer
    {

        private readonly ILessonTaskRepository _taskRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILessonRepository _lessonRepo;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILessonRepository lessonRepo, ILessonTaskRepository taskRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _lessonRepo = lessonRepo;
            _taskRepo = taskRepo;
        }

        public void Initialize()
        {
            AddAdminUser();
            AddTestUsers();
            AddTestLessons();
            AddTestBlogPosts();
        }

        public void AddTestUsers()
        {
            var testUsers = new[] {
                new
                {
                    Email = "sara.ashley@test.com",
                    FirstName = "Sara",
                    LastName = "Ashley"
                },
                new {
                    Email = "jeff.rowland@test.com",
                    FirstName = "Jeff",
                    LastName = "Rowland"
                }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.FirstName, user.LastName);
            }

        }

        private AppUser CreateUser(string email, string firstName, string lastName)
        {
            if (_userManager.FindByNameAsync(email).Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
                // add user
                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestLessons()
        {
            if (_lessonRepo.GetAll().Count() > 0) return;

            var sara = _userManager.FindByNameAsync("sara.ashley@test.com").Result;
            var jeff = _userManager.FindByNameAsync("jeff.rowland@test.com").Result;
            var saraLesson1 = CreateTestLesson(sara, "Yada Yada Yada", "A blog about nothing");
            var jeffLesson1 = CreateTestLesson(jeff, "Random Nonsense", "Just what it says");
            _lessonRepo.Add(saraLesson1);
            _lessonRepo.Add(jeffLesson1);
        }

        private Lesson CreateTestLesson(AppUser user, string name, string description)
        {
            var content = @"<p>
Urna praesent porttitor lectus netus dictumst pretium. Cubilia eros nec primis elit ridiculus. Euismod auctor habitant ante, varius placerat consequat per sem. Neque bibendum commodo phasellus hendrerit. Rhoncus sit cursus ultricies vitae? Luctus facilisi dictum feugiat hac senectus rutrum aliquam neque lacus pulvinar condimentum! Pretium imperdiet nunc ultricies ridiculus odio lectus urna nibh nam. Donec!
</p>
<p>
Mauris parturient platea parturient dictum eu; massa congue fringilla taciti posuere facilisi nam! Senectus, congue amet imperdiet nulla platea? Quisque massa tempor himenaeos mi a cum lobortis odio sociis! Turpis, facilisis adipiscing pretium. Vitae fringilla hac scelerisque suscipit odio a eu inceptos a ornare felis pellentesque. Per feugiat tristique nostra maecenas cursus facilisi iaculis lobortis nisi magna velit. Arcu fusce, accumsan feugiat scelerisque class aliquam!
</p>
<p>
Sapien, nascetur senectus risus vestibulum per gravida sociosqu. Gravida senectus natoque fringilla laoreet. Sociis ac ac et fames tellus purus malesuada? Dapibus mauris aenean placerat. Odio turpis ultrices nunc sit nullam ad cras lacus. Taciti facilisis augue, sociosqu himenaeos porta curabitur enim nunc! Dis et conubia montes. Etiam nulla et sit. Ullamcorper odio lacus dapibus. Sapien elit vel orci pellentesque tellus libero ullamcorper vel auctor hac? Mus quisque accumsan massa venenatis ad arcu morbi. Fusce nulla facilisis faucibus aliquet.
</p>
<p>
Inceptos nascetur congue aliquet sociosqu dapibus. Neque himenaeos metus potenti dignissim. Fusce imperdiet vel nisl sodales amet mauris mi. Taciti sed ac nunc tincidunt dapibus at mi dis hendrerit condimentum. Consectetur feugiat libero iaculis magnis maecenas. Ut quam amet vitae mus dapibus magna tortor fermentum fames viverra! Semper cras duis hac, dapibus elit? Facilisis, inceptos metus habitant varius. Eros curae; sollicitudin, facilisis vitae felis rhoncus consectetur suspendisse molestie. Suscipit a consequat pellentesque penatibus nostra habitasse ornare penatibus? Dolor montes ornare sem. Ultricies mi massa pulvinar nostra varius, tellus faucibus ante rutrum tempor. Diam lobortis duis?
</p>
<p>
Ipsum arcu tempus turpis nam amet aenean in cras cursus dictum nullam enim. Ridiculus conubia phasellus pharetra tellus facilisi taciti diam hendrerit proin nostra. Congue nullam ligula et class facilisi ac. Eleifend, aliquet curae; a montes rutrum varius. Ut cubilia laoreet arcu accumsan cum ad posuere dis. Litora fusce non cubilia amet a. Rhoncus morbi nibh nisi risus ad. Suspendisse maecenas viverra sodales sem nisi. Praesent blandit fringilla natoque. Ad molestie cras dis magnis nulla ornare nibh metus commodo nisi porta. Tortor lectus ac suscipit varius. Ultricies luctus nunc volutpat. Cubilia ante metus potenti, accumsan duis rhoncus purus.
</p>";
            return new Lesson
            {
                Name = name,
                Description = description,
                UserId = user.Id,
                Tasks = new List<LessonTask>
                {
                    new LessonTask
                    {
                        Title = "My First Task",
                        Content = content,
                        DatePublished = DateTime.Now
                    },
                    new LessonTask
                    {
                        Title = "My Second Task",
                        Content = content,
                        DatePublished = DateTime.Now
                    },
                }
            };
        }

        public void AddTestBlogPosts()
        {

        }


        private void AddAdminUser()
        {
            // create an Admin role, if it doesn't already exist
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
            //// create an Admin user, if it doesn't already exist
            //if (_userManager.FindByNameAsync("admin").Result == null)
            //{
            //    AppUser user = new AppUser
            //    {
            //        UserName = "admin@test.com",
            //        Email = "admin@test.com"
            //    };

            //    // add the Admin user to the Admin role
            //    IdentityResult result = _userManager.CreateAsync(user, "AdminPassword123!").Result;

            //    if (result.Succeeded)
            //    {
            //        _userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
        }


    }

}