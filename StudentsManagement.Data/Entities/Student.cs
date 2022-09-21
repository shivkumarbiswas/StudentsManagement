using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ScholarNo { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }
    }
}
