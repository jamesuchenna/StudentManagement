using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.IRepositories;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Student> _db;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Students;
        }
        public async Task AddStudentAsync(Student student)
        {
            await _db.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studentDelete = await GetStudentByIdAsync(id);
            _db.Remove(studentDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditStudentAsync(Student student)
        {
            _db.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
