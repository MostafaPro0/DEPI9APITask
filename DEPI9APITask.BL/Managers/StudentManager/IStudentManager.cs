using DEPI9APITask.BL.Dtos;

namespace DEPI9APITask.BL
{
    public interface IStudentManager
    {
        Task<List<StudentDto>> GetStudentsListAsync();
        Task<StudentDto?> GetStudentByIdAsync(int id);
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
        Task<bool> UpdateStudentAsync(StudentDto studentDto);
        Task DeleteStudentAsync(int id);
    }
}
