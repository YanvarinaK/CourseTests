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
        bool Create(Course entity);

        Course Get(Guid id);

        List<Course> List();

        bool Update(Course newEntity, Guid id);

        bool Delete(Guid id);
    }
}
