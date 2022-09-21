using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Data.Context
{
    public class StudentsManagementDBContext : DbContext
    {
        public StudentsManagementDBContext(DbContextOptions<StudentsManagementDBContext> options) : base(options) { }
     
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.Id).ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Student>()
                            .Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Student>()
                            .Property(s => s.ScholarNo).IsRequired();

            modelBuilder.Entity<Course>()
               .Property(s => s.Id).ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Course>()
                            .Property(s => s.Name).IsRequired();

            modelBuilder.Entity<Course>()
                .HasMany<Student>()
                .WithOne(c => c.Course)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Name = ".Net Core"},
                new Course() { Id = 2, Name = "Angular" },
                new Course() { Id = 3, Name = "React" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, Name = "John", ScholarNo = "123", CourseId = 1 },
                new Student() { Id = 2, Name = "Smith", ScholarNo = "456", CourseId = 2 },
                new Student() { Id = 3, Name = "Alex", ScholarNo = "789", CourseId = 3 }
            );
        }
    }
}
