using CourseTests.DataTransferObjects.PossibleAnswer;
using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface IPossibleAnswerCRUDService
    {
        bool Create(PossibleAnswerCreate possibleAnswer);

        PossibleAnswerView Get(Guid id);

        List<PossibleAnswerList> List();

        bool Update(PossibleAnswerUpdate newPossibleAnswer, Guid id);

        bool Delete(Guid id);

        List<PossibleAnswerList> ListPagination(int page = 0, int pageSize = 4);

    }
}
