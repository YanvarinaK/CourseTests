using CourseTests.DataTransferObjects.Test;
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
    public class TestCRUDService : ITestCRUDService
    {
        public bool Create(TestCreate test)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    Test entity = new Test()
                    {
                        Id = Guid.NewGuid(),
                        Name = test.Name,
                        Description = test.Description,
                        Questions = null,
                        CourseId = test.CourseId,
                        Course = db.Courses.FirstOrDefault(c=>c.Id == test.CourseId)
                    };
                    db.Tests.Add(entity);
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
                Test testFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Entry(testFromDb).State = EntityState.Deleted;
                    db.Tests.Remove(testFromDb);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TestView Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Test entity = GetEntity(id);
                TestView test = new TestView()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    QuestionIds = entity.Questions != null ? entity.Questions.Select(t => t.Id).ToList() : new List<Guid>(),
                    CourseId = entity.CourseId,
                    CourseName = entity.Course.Name
                };
                return test;
            }
        }

        public List<TestList> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<TestList> tests = db.Tests
                    .Select(c => new TestList
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        CourseId = c.CourseId
                    }).ToList();
                return tests;
            }
        }

        public bool Update(TestUpdate newTest, Guid id)
        {
            try
            {
                Test testFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    testFromDb.Name = newTest.Name;
                    testFromDb.Description = newTest.Description;
                    testFromDb.CourseId = newTest.CourseId;
                    db.Entry(testFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Test GetEntity(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Test TestFromDb = db.Tests
                    .Include(x => x.Questions)
                    .Include(x => x.Course)
                    .FirstOrDefault(t => t.Id == id);
                return TestFromDb;
            }
        }
    }
}
