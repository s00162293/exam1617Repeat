using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models.Data
{
    public class AttendDBContext: DbContext
    {
        public AttendDBContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Lecturer> lecturers { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<LecturerSubject> lecturerSubjects { get; set; }
        public DbSet<Attendance> attendance { get; set; }

    }
}