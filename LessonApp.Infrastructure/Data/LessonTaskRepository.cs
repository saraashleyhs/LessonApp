using System;
using LessonApp.Core.Models;
using LessonApp.Core.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LessonApp.Infrastructure.Data
{
    public class LessonTaskRepository : ILessonTaskRepository
    {
            private readonly AppDbContext _dbContext;

            public LessonTaskRepository(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public LessonTask Get(int id)
            {
                return _dbContext.Tasks
                    .Include(p => p.Lesson)
                    .Include(p => p.Lesson.User)
                    .SingleOrDefault(p => p.Id == id);
            }

            public IEnumerable<LessonTask> GetAllLessonTasks(int taskId)
            {
                return _dbContext.Tasks
                    .Include(p => p.Lesson)
                    .Include(p => p.Lesson.User)
                    .Where(p => p.LessonId == taskId).ToList();
            }

            public LessonTask Add(LessonTask newTask)
            {
                _dbContext.Tasks.Add(newTask);
                _dbContext.SaveChanges();
                return newTask;
            }

            public LessonTask Update(LessonTask updatedTask)
            {
                var existingItem = _dbContext.Tasks.Find(updatedTask.Id);
                if (existingItem == null) return null;
                _dbContext.Entry(existingItem)
                   .CurrentValues
                   .SetValues(updatedTask);
                _dbContext.Tasks.Update(existingItem);
                _dbContext.SaveChanges();
                return existingItem;

            }

            public IEnumerable<LessonTask> GetAll()
            {
                return _dbContext.Tasks.ToList();
            }

            public void Remove(int id)
            {
                var deletedTask = _dbContext.Tasks.FirstOrDefault(p => p.Id == id);
                _dbContext.Tasks.Remove(deletedTask);
                _dbContext.SaveChanges();
            }
        }
}
