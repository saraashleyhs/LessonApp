using System;
using System.Collections.Generic;
using LessonApp.Core.Models;

namespace LessonApp.Core.Services
{
    public class LessonTaskService : ILessonTaskService
    {
        private readonly ILessonTaskRepository _taskRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserService _userService;

        public LessonTaskService(ILessonTaskRepository taskRepository, ILessonRepository lessonRepository, IUserService userService)
        {
            _taskRepository = taskRepository;
            _lessonRepository = lessonRepository;
            _userService = userService;
        }

        public LessonTask Add(LessonTask newTask)
        {
            var currentUser = _userService.CurrentUserId;
            var currentBlog = _lessonRepository.Get(newTask.LessonId);
            if (currentUser == currentBlog.UserId)
            {
                newTask.DatePublished = DateTime.Now;
                return _taskRepository.Add(newTask);
            }

            throw new Exception("Nuh uh uh!  Nuh uh uh! Not yours!");
        }

        public LessonTask Get(int id)
        {
            return _taskRepository.Get(id);
        }

        public IEnumerable<LessonTask> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public IEnumerable<LessonTask> GetAllTasks(int taskId)
        {
            return _taskRepository.GetAllLessonTasks(taskId);
        }

        public void Remove(int id)
        {
            var post = this.Get(id);
            if (_userService.CurrentUserId == post.Lesson.UserId)
            {
                _taskRepository.Remove(id);
                return;
            }
            throw new Exception("Nuh uh uh!  Nuh uh uh! Not yours!");
        }

        public LessonTask Update(LessonTask updatedTask)
        {
            var currentUser = _userService.CurrentUserId;
            if (currentUser == updatedTask.Lesson.UserId)
            {
                return _taskRepository.Update(updatedTask);
            }
            throw new Exception("Nuh uh uh!  Nuh uh uh! Not yours!");
        }
    }
}
