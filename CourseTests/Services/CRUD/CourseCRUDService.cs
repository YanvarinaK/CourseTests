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
    public class CourseCRUDService : ICourseCRUDService
    {
        public bool Create(Course entity)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Courses.Add(entity);
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
                Course courseFromDb = Get(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Entry(courseFromDb).State = EntityState.Deleted;
                    db.Courses.Remove(courseFromDb);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Course Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Course courseFromDb = db.Courses
                    .Include(x => x.Tests)
                    .FirstOrDefault(c => c.Id == id);
                return courseFromDb;
            }
        }

        public List<Course> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<Course> courses = db.Courses.ToList();
                return courses;
            }
        }

        public bool Update(Course newEntity, Guid id)
        {
            try
            {
                Course courseFromDb = Get(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    courseFromDb.Name = newEntity.Name;
                    courseFromDb.Description = newEntity.Description;
                    db.Entry(courseFromDb).State = EntityState.Modified;
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
