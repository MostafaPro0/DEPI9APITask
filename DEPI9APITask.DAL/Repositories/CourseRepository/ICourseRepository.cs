using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI9APITask.DAL
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task AddAsync(Course course);
        void Update(Course course);
        void Delete(Course course);
        Task SaveChangesAsync();
    }
}
