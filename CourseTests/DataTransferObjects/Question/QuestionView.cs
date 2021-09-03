using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.Question
{
    public class QuestionView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> PossibleAnswersIds { get; set; }
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
