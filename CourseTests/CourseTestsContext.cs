using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests
{
    public class CourseTestsContext : DbContext
    {
        public CourseTestsContext() : base("CourseTestsDB") 
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
