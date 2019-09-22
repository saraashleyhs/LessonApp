using System;
using System.Collections.Generic;
using LessonApp.Core.Models;

namespace LessonApp.Core.Services
{
    public interface ILessonTaskService
    {
        LessonTask Add(LessonTask newTask);
        LessonTask Update(LessonTask updatedTask);
        LessonTask Get(int id);
        IEnumerable<LessonTask> GetAll();
        IEnumerable<LessonTask> GetAllTasks(int lessonId);
        void Remove(int id);
    }
}
