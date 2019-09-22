using System;
using System.Linq;
using System.Collections.Generic;
using LessonApp.Core.Models;

namespace LessonApp.API.ApiModels
{
    public static class LessonMappingExtensions
    {

        public static LessonModel ToApiModel(this Lesson lesson)
        {
            return new LessonModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                AuthorName = lesson.User.FullName
            };
        }

        public static Lesson ToDomainModel(this LessonModel lessonModel)
        {
            return new Lesson
            {
                Id = lessonModel.Id,
                Name = lessonModel.Name,
                Description = lessonModel.Description,
            };
        }

        public static IEnumerable<LessonModel> ToApiModels(this IEnumerable<Lesson> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Lesson> ToDomainModels(this IEnumerable<LessonModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
