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
        bool Create(PossibleAnswer entity);

        PossibleAnswer Get(Guid id);

        List<PossibleAnswer> List();

        bool Update(PossibleAnswer newEntity, Guid id);

        bool Delete(Guid id);
    }
}
