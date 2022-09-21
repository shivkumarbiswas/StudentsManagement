using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data.Context;
using StudentsManagement.Data.Entities;
using StudentsManagement.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsManagementDBContext _context;

        public StudentRepository(StudentsManagementDBContext context)
        {
            _context = context;
        }

        public  async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync(); 
        }

        public async Task<bool> RegisterStudent(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
