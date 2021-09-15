using CourseTests.DataTransferObjects.Test;
using System;
using System.Collections.Generic;

namespace CourseTests.GlobalInterfaces
{
    public interface ITestCRUDService
    {
        bool Create(TestCreate test, out Guid? testId);

        TestView Get(Guid id);

        List<TestList> List();

        bool Update(TestUpdate newTest, Guid id);

        bool Delete(Guid id);

        List<TestList> ListPagination(int page = 0, int pageSize = 4);

    }
}
