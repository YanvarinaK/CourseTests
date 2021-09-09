using CourseTests.DataTransferObjects.PossibleAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.RecordAnswer
{
    public class RecordAnswerView
    {
        public Guid UserId { get; set; }
        public string FullNameUser { get; set; }
        public List<PossibleAnswerView> Answers { get; set; }
    }
}
