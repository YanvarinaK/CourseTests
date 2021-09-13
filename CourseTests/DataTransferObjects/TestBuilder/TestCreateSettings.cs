using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.TestBuilder
{
    public class TestCreateSettings
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionTestBuildSettings> questions { get; set; }
    }
}
