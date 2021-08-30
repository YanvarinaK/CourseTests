using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PossibleAnswer> PossibleAnswers { get; set; }
        public Test Test { get; set; }

        public Question()
        {
            PossibleAnswers = new List<PossibleAnswer>();
        }
    }
}
