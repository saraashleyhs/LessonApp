using System;
using System.Collections.Generic;
using System.Linq;
using LessonApp.Core.Models;

namespace LessonApp.API.ApiModels
{
    public static class TaskMappingExtensions
    {

        public static TaskModel ToApiModel(this LessonTask task)
        {
            return new TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Content = task.Content,
                LessonId = task.LessonId,
                DatePublished = task.DatePublished,
                LessonName = task.Lesson.Name,
                AuthorName = task.Lesson.User.FullName,
            };
        }

        public static LessonTask ToDomainModel(this TaskModel taskModel)
        {
            return new LessonTask
            {
                Id = taskModel.Id,
                Title = taskModel.Title,
                Content = taskModel.Content,
                LessonId = taskModel.LessonId,
                DatePublished = taskModel.DatePublished
            };
        }

        public static IEnumerable<TaskModel> ToApiModels(this IEnumerable<LessonTask> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<LessonTask> ToDomainModels(this IEnumerable<TaskModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
