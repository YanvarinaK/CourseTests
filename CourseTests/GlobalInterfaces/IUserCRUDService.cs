using CourseTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface IUserCRUDService
    {
        bool Create(User entity);

        User Get(Guid id);

        List<User> List();

        bool Update(User newEntity, Guid id);

        bool Delete(Guid id);
    }
}
