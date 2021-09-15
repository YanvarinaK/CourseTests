using CourseTests.DataTransferObjects.RecordAnswer;
using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface IRecordAnswerCRUDService
    {
        bool Create(RecordAnswerCreate recordAnswer);

        RecordAnswerView Get(Guid userId);

        List<RecordAnswerView> List();

        bool Delete(Guid userId, Guid possibleAnswerId);

        List<RecordAnswerView> ListPagination(int page = 0, int pageSize = 4);

    }
}
