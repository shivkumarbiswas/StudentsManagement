using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data.Context;
using StudentsManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Data.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();

        Task<bool> AddCourse(Course course);
    }
}
