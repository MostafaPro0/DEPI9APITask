using DEPI9APITask.DAL;
using DEPI9APITask.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI9APITask.BL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DEPI9APITaskContext _context;

        public StudentRepository(DEPI9APITaskContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Courses).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> GetByPhoneAsync(string phone)
        {
            return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Phone == phone);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
