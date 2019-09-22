using System;
namespace LessonApp.API.ApiModels
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool CommentsAllowed { get; set; }
        public DateTime DatePublished { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string AuthorName { get; set; }
    }
}
