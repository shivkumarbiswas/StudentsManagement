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
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentsManagementDBContext _context;

        public CourseRepository(StudentsManagementDBContext context)
        {
            _context = context;
        }

        public  async Task<List<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync(); 
        }

        public async Task<bool> AddCourse(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
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
