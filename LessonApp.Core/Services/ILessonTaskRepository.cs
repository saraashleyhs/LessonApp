using System;
using System.Collections.Generic;
using LessonApp.Core.Models;

namespace LessonApp.Core.Services
{
    public interface ILessonTaskRepository
    {
        LessonTask Add(LessonTask newTask);
        LessonTask Update(LessonTask updatedTask);
        LessonTask Get(int id);
        IEnumerable<LessonTask> GetAll();
        void Remove(int id);
        IEnumerable<LessonTask> GetAllLessonTasks(int taskId);
    }
}
