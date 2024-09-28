using AutoMapper;
using DEPI9APITask.BL.Dtos;
using DEPI9APITask.DAL;

namespace DEPI9APITask.BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Course, CourseDto>();
        CreateMap<Course, CourseDto>().ReverseMap();
    }
}
