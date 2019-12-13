using System;
using LessonApp.API.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LessonApp.Core.Services;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonApp.API.Controllers
{

    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        private readonly ILessonTaskService _taskService;

        public PostsController(ILessonTaskService taskService)
        {
            _taskService = taskService;
        }

        // GET /api/blogs/{blogId}/posts
        [HttpGet("/api/lessons/{lessonId}/tasks")]
        public IActionResult Get(int lessonId)
        {
            try
            {
                var allTasks = _taskService
                    .GetAllTasks(lessonId)
                    .ToApiModels();
                return Ok(allTasks);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetTasks", ex.Message);
                return BadRequest(ModelState);
            }
        }

        //get post by id
        //allow anyone to get, even if not logged in
        // GET api/blogs/{blogId}/posts/{postId}
        [HttpGet("/api/lessons/{lessonId}/tasks/{taskId}")]
        public IActionResult Get(int lessonId, int taskId)
        {
            try
            {
                var singlePost = _taskService
                    .GetAllTasks(lessonId)
                    .ToApiModels().FirstOrDefault(p => p.Id == taskId);
                return Ok(singlePost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetTask", ex.Message);
                return BadRequest(ModelState);
            }

        }

        // add a new post to blog
        // POST /api/blogs/{blogId}/post
        [HttpPost("/api/lessons/{lessonId}/tasks")]
        public IActionResult Post(int lessonId, [FromBody]TaskModel taskModel)
        {
            try
            {
                _taskService.Add(taskModel.ToDomainModel());
                return Ok(taskModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddPost", ex.Message);
                return BadRequest(ModelState);
            }

        }

        // PUT /api/blogs/{blogId}/posts/{postId}
        [HttpPut("/api/lessons/{lessonId}/tasks/{taskId}")]
        public IActionResult Put(int lessonId, int taskId, [FromBody]TaskModel taskModel)
        {
            try
            {
                var updatedPost = _taskService.Update(taskModel.ToDomainModel());
                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdatePost", ex.Message);
                return BadRequest(ModelState);
            }
        }


        // DELETE /api/blogs/{blogId}/posts/{postId}
        [HttpDelete("/api/lessons/{lessonId}/tasks/{taskId}")]
        public IActionResult Delete(int lessonId, int taskId)
        {
            try
            {
                _taskService.Remove(taskId);
                return Ok(_taskService.Get(lessonId));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeletePost", ex.Message);
                return BadRequest(ModelState);
            }

        }
    }
}