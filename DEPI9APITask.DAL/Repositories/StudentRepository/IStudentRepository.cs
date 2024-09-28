using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI9APITask.DAL
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();    
        Task<Student?> GetByIdAsync(int id); 
        Task<Student?> GetByPhoneAsync(string phone);
        Task AddAsync(Student student);      
        void Update(Student student);       
        void Delete(Student student);  
        Task SaveChangesAsync(); 
    }
}
