using System.Collections;
using System.Collections.Generic;
using LessonApp.Core.Models;

namespace LessonApp.Core.Services
{
    public interface ILessonService
    {
        Lesson Add(Lesson newLesson);
        Lesson Update(Lesson updatedLesson);
        Lesson Get(int id);
        IEnumerable<Lesson> GetAll();
        void Remove(int id);
    }
}