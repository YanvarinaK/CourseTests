using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Entities
{
    public class PossibleAnswer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsRight { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public List<User> Users { get; set; }

        public PossibleAnswer()
        {
            Users = new List<User>();
        }
    }
}
