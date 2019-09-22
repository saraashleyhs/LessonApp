using System;
using System.Collections.Generic;
using LessonApp.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace LessonApp.Core
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Lesson> Lessons { get; set; }    
    }
}
