using System;
using LessonApp.Core.Models;
using System.Collections.Generic;

namespace LessonApp.Core.Services
{
    public interface ILessonRepository
    {
        Lesson Add(Lesson blog);
        Lesson Update(Lesson blog);
        Lesson Get(int id);
        IEnumerable<Lesson> GetAll();
        void Remove(int id);

    }
}
