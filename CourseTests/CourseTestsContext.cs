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
    }
}
