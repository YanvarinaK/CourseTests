using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Entities
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
