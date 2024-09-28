using AutoMapper;
using DEPI9APITask.BL.Dtos;
using DEPI9APITask.DAL;

namespace DEPI9APITask.BL;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentManager(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<List<StudentDto>> GetStudentsListAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<List<StudentDto>>(students); 
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
            return null;

        return _mapper.Map<StudentDto>(student); 
    }

    public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
    {
        var studentDb = _mapper.Map<Student>(studentDto); 
        studentDb.Id = 0; 

        await _studentRepository.AddAsync(studentDb);
        await _studentRepository.SaveChangesAsync();

        return _mapper.Map<StudentDto>(studentDb);
    }

    public async Task<bool> UpdateStudentAsync(StudentDto studentDto)
    {
        var studentDb = await _studentRepository.GetByIdAsync(studentDto.Id);
        if (studentDb == null)
            return false;

        _mapper.Map(studentDto, studentDb);
        _studentRepository.Update(studentDb);
        await _studentRepository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
            return;

        _studentRepository.Delete(student);
        await _studentRepository.SaveChangesAsync();
    }
}
