using CourseTests.DataTransferObjects.Course;
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
        public bool Create(CourseCreate course)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    Course entity = new Course()
                    {
                        Id = Guid.NewGuid(),
                        Name = course.Name,
                        Description = course.Description,
                        Tests = null
                    };
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
                Course courseFromDb = GetEntity(id);
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

        private Course GetEntity(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Course courseFromDb = db.Courses
                    .Include(x => x.Tests)
                    .FirstOrDefault(c => c.Id == id);
                return courseFromDb;
            }
        }

        public List<CourseList> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<CourseList> courses = db.Courses
                    .Select(c => new CourseList
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    }).ToList();
                return courses;
            }
        }

        public bool Update(CourseUpdate course, Guid id)
        {
            try
            {
                Course courseFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    courseFromDb.Name = course.Name;
                    courseFromDb.Description = course.Description;
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

        public CourseView Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Course entity = GetEntity(id);
                CourseView course = new CourseView()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    TestIds = entity.Tests != null ? entity.Tests.Select(t => t.Id).ToList() : new List<Guid>()
                };
                return course;
            }
        }

        public List<CourseList> ListPagination(int page = 0, int pageSize = 4)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<CourseList> courses = db.Courses
                    .OrderBy(x=> x.Name)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .Select(c => new CourseList
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    }).ToList();
                return courses;
            }
        }
    }
}
