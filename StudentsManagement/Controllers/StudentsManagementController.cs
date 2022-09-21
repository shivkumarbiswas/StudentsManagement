using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Data.Repositories.Interfaces;
using StudentsManagement.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsManagementController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentsManagementController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet("students")]
        public async Task<List<Student>> GetStudents()
        {
            var listOfStudents = await _studentRepository.GetStudents();

            var students = new List<Student>();
            foreach (var stud in listOfStudents)
            {
                var student = new Student() { Id = stud.Id, Name = stud.Name, ScholarNo = stud.ScholarNo, CourseId = stud.CourseId };

                students.Add(student);
            }

            return students;
        }

        [HttpGet("courses")]
        public async Task<List<Course>> GetCourses()
        {
            var listOfCourses = await _courseRepository.GetCourses();

            var courses = new List<Course>();
            foreach (var course in listOfCourses)
            {
                var courseDTO = new Course() { Id = course.Id, Name = course.Name};

                courses.Add(courseDTO);
            }

            return courses;
        }

        [HttpPost("register-student")]
        public async Task<bool> RegisterStudent([FromBody] Student student)
        {
            return await _studentRepository.RegisterStudent(new Data.Entities.Student() { Id = student.Id, Name = student.Name, ScholarNo = student.ScholarNo, CourseId = student.CourseId});
        }

        [HttpPost("add-course")]
        public async Task<bool> AddCourse([FromBody] Course course)
        {
            return await _courseRepository.AddCourse(new Data.Entities.Course() { Id = course.Id, Name = course.Name});
        }
    }
}
