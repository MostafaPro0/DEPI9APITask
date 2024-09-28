using DEPI9APITask.BL.Dtos;

namespace DEPI9APITask.BL
{
    public interface ICourseManager
    {
        Task<List<CourseDto>> GetCoursesListAsync();
        Task<CourseDto?> GetCourseByIdAsync(int id);
        Task<CourseDto> AddCourseAsync(CourseDto courseDto);
        Task<bool> UpdateCourseAsync(CourseDto courseDto);
        Task DeleteCourseAsync(int id);
    }
}