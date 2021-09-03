using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.Test
{
    public class TestView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> QuestionIds { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }

    }
}
