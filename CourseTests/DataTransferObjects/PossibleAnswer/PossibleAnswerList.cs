using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.PossibleAnswer
{
    public class PossibleAnswerList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsRight { get; set; }
        public Guid QuestionId { get; set; }
    }
}
