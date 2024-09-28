using DEPI9APITask.BL;
using DEPI9APITask.BL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DEPI9APITask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentManager;

        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            var students = await _studentManager.GetStudentsListAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto?>> GetStudent(int id)
        {
            var student = await _studentManager.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent([FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdStudent = await _studentManager.AddStudentAsync(studentDto);

            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDto.Id)
            {
                return BadRequest("Student ID mismatch");
            }

            var result = await _studentManager.UpdateStudentAsync(studentDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentManager.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentManager.DeleteStudentAsync(id);

            return NoContent();
        }
    }
}
