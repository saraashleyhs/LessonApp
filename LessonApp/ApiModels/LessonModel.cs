using System;
namespace LessonApp.API.ApiModels
{
    public class LessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string AuthorName { get; set; }
    }
}
