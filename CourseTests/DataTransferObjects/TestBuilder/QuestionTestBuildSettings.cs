using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.TestBuilder
{
    public class QuestionTestBuildSettings
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PossibleAnswerBuildSettings> possibleAnswers { get; set; }
    }
}
