using CourseTests.DataTransferObjects.User;
using CourseTests.Entities;
using CourseTests.GlobalInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Services.CRUD
{
    public class UserCRUDService : IUserCRUDService
    {
        public bool Create(UserCreate user)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    User entity = new User()
                    {
                        Id = Guid.NewGuid(),
                        FullName = user.FullName
                    };

                    db.Users.Add(entity);

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                User user = GetEntuty(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Entry(user).State = EntityState.Deleted;
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private User GetEntuty(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == id);

                return user;
            }
        }

        public List<UserList> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<UserList> users = db.Users.Select(u=> new UserList
                {
                Id = u.Id,
                FullName = u.FullName
                }).ToList();
                return users;
            }
        }

        public bool Update(UserUpdate user, Guid id)
        {
            try
            {
                User entityFromDB = GetEntuty(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    entityFromDB.FullName = user.FullName;
                    db.Entry(entityFromDB).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
              
            }
        }

        public UserView Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                User entity = GetEntuty(id);
                UserView user = new UserView()
                {
                    Id = entity.Id,
                    FullName = entity.FullName
                };
                return user;
            }
        }
    }
}
