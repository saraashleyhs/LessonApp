using System;
using System.Collections;
using System.Collections.Generic;


namespace LessonApp.Core.Models
{
    public class Lesson : IEntity<int>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<LessonTask> Tasks { get; set; }    
    }
}
