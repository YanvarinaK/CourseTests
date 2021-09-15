using CourseTests.DataTransferObjects.Question;
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
        bool Create(QuestionCreate question, out Guid? QuestionId);

        QuestionView Get(Guid id);

        List<QuestionList> List();

        bool Update(QuestionUpdate newQuestion, Guid id);

        bool Delete(Guid id);

        List<QuestionList> ListPagination(int page = 0, int pageSize = 4);

    }
}
