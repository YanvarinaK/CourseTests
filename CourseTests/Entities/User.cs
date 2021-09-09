using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public List<PossibleAnswer> PossibleAnswers { get; set; }

        public User()
        {
            PossibleAnswers = new List<PossibleAnswer>();
        }
    }
}
