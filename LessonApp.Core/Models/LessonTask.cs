using System;

namespace LessonApp.Core.Models
{
    public class LessonTask : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

    }
}