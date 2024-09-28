using AutoMapper;
using DEPI9APITask.BL.Dtos;
using DEPI9APITask.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI9APITask.BL
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> GetCoursesListAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDto?>(course); 
        }

        public async Task<CourseDto> AddCourseAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> UpdateCourseAsync(CourseDto courseDto)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(courseDto.Id);
            if (existingCourse == null)
            {
                return false; // Course not found
            }

            // Update properties
            _mapper.Map(courseDto, existingCourse);
            _courseRepository.Update(existingCourse);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                _courseRepository.Delete(course);
                await _courseRepository.SaveChangesAsync();
            }
        }
    }
}
