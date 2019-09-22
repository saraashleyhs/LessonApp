using System;
using System.Collections.Generic;
using LessonApp.Core.Models;
namespace LessonApp.Core.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public Lesson Add(Lesson newBlog)
        {
            return _lessonRepository.Add(newBlog);
        }

        public Lesson Get(int id)
        {
            return _lessonRepository.Get(id);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _lessonRepository.GetAll();
        }

        public void Remove(int id)
        {
            _lessonRepository.Remove(id);
        }

        public Lesson Update(Lesson updatedBlog)
        {
            return _lessonRepository.Update(updatedBlog);
        }
    }
}
