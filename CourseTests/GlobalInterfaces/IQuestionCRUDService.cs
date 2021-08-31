using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface IQuestionCRUDService
    {
        bool Create(Question entity);

        Question Get(Guid id);

        List<Question> List();

        bool Update(Question newEntity, Guid id);

        bool Delete(Guid id);
    }
}
