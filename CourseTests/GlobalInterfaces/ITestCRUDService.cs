using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface ITestCRUDService
    {
        bool Create(Test entity);

        Test Get(Guid id);

        List<Test> List();

        bool Update(Test newEntity, Guid id);

        bool Delete(Guid id);
    }
}
