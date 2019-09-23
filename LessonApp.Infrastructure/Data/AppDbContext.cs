using System;
using LessonApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LessonApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=../LessonApp.Infrastructure/lesson.db");
        }
    }
}
