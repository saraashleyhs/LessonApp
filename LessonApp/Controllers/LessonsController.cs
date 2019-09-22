using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonApp.API.ApiModels;
using LessonApp.Core.Models;
using LessonApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        //GET: api/lessons
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_lessonService.GetAll().ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBlogs", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/lessons/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_lessonService.Get(id).ToApiModel());

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBlog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/lessons
        [HttpPost]
        public IActionResult Post([FromBody]Lesson lesson)
        {
            try
            {
                return Ok(_lessonService.Add(lesson).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddLesson", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/lessons/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Lesson lesson)
        {
            try
            {
                return Ok(_lessonService.Update(lesson).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateLesson", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/lessons/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _lessonService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteLesson", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}