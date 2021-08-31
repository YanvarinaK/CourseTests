using CourseTests.DataTransferObjects.User;
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
        bool Create(UserCreate user);

        UserView Get(Guid id);

        List<UserList> List();

        bool Update(UserUpdate user, Guid id);

        bool Delete(Guid id);
    }
}
