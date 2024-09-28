using DEPI9APITask.BL;
using DEPI9APITask.BL.Dtos; // Assuming you have Dtos for Course
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI9APITask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManager _courseManager; // Assuming you have an ICourseManager

        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourses()
        {
            var courses = await _courseManager.GetCoursesListAsync();
            return Ok(courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto?>> GetCourse(int id)
        {
            var course = await _courseManager.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse([FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCourse = await _courseManager.AddCourseAsync(courseDto);

            return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.Id }, createdCourse);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseDto.Id)
            {
                return BadRequest("Course ID mismatch");
            }

            var result = await _courseManager.UpdateCourseAsync(courseDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseManager.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseManager.DeleteCourseAsync(id);

            return NoContent();
        }
    }
}
