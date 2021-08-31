using CourseTests.DataTransferObjects.Course;
using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface ICourseCRUDService
    {
        bool Create(CourseCreate course);

        CourseView Get(Guid id);

        List<CourseList> List();

        bool Update(CourseUpdate course, Guid id);

        bool Delete(Guid id);
    }
}
