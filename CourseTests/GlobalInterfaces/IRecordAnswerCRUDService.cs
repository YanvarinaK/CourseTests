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
        bool Create(RecordAnswer entity);

        RecordAnswer Get(Guid userId, Guid possibleAnswerId);

        List<RecordAnswer> List();

        bool Update(RecordAnswer newEntity, Guid userId, Guid PossibleAnswerId);

        bool Delete(Guid userId, Guid possibleAnswerId);
    }
}
