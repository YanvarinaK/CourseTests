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
        public bool Create(User entity)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
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
                User user = Get(id);
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

        public User Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == id);

                return user;
            }
        }

        public List<User> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<User> users = db.Users.ToList();
                return users;
            }
        }

        public bool Update(User newEntity, Guid id)
        {
            try
            {
                User userFromDB = Get(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    userFromDB.FullName = newEntity.FullName;
                    db.Entry(userFromDB).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
              
            }
        }
    }
}
