using System;
using System.Collections.Generic;
using System.Linq;
using LessonApp.Core.Services;
using LessonApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonApp.Infrastructure.Data
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _dbContext;

        public LessonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _dbContext.Lessons
                .Include(b => b.User)
                .ToList();
        }

        public Lesson Get(int id)
        {
            return _dbContext.Lessons
                .Include(b => b.User)
                .SingleOrDefault(b => b.Id == id);
        }

        public Lesson Add(Lesson newBlog)
        {
            _dbContext.Lessons.Add(newBlog);
            _dbContext.SaveChanges();
            return newBlog;
        }

        public Lesson Update(Lesson updatedItem)
        {
            var existingItem = _dbContext.Lessons.Find(updatedItem.Id);
            if (existingItem == null) return null;
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);
            _dbContext.Lessons.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }

        public void Remove(int id)
        {
            var deletedBlog = _dbContext.Lessons.FirstOrDefault(b => b.Id == id);
            _dbContext.Lessons.Remove(deletedBlog);
            _dbContext.SaveChanges();
        }

    }
}
