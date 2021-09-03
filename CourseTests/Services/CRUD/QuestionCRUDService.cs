using CourseTests.DataTransferObjects.Question;
using CourseTests.Entities;
using CourseTests.GlobalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Services.CRUD
{
    public class QuestionCRUDService : IQuestionCRUDService
    {
        public bool Create(QuestionCreate question)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    Question entity = new Question()
                    {
                        Id = Guid.NewGuid(),
                        Name = question.Name,
                        Description = question.Description,
                        PossibleAnswers = null,
                        TestId = question.TestId,
                    };
                    db.Questions.Add(entity);
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
                Question questionFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Entry(questionFromDb).State = EntityState.Deleted;
                    db.Questions.Remove(questionFromDb);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public QuestionView Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Question entity = GetEntity(id);
                QuestionView question = new QuestionView()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    PossibleAnswersIds = entity.PossibleAnswers != null ? entity.PossibleAnswers.Select(t => t.Id).ToList() : new List<Guid>(),
                    TestId = entity.TestId,
                    TestName = entity.Test.Name,
                    CourseId = entity.Test.CourseId,
                    CourseName = entity.Test != null ? entity.Test.Course.Name : string.Empty
                };
                return question;
            }
        }

        public List<QuestionList> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<QuestionList> questions = db.Questions
                    .Select(q => new QuestionList
                    {
                        Id = q.Id,
                        Name = q.Name,
                        Description = q.Description,
                        TestId = q.TestId
                    }).ToList();
                return questions;
            }
        }

        public bool Update(QuestionUpdate newQuestion, Guid id)
        {
            try
            {
                Question questionFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    questionFromDb.Name = newQuestion.Name;
                    questionFromDb.Description = newQuestion.Description;
                    questionFromDb.TestId = newQuestion.TestId;
                    db.Entry(questionFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Question GetEntity(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                Question QuestionFromDb = db.Questions
                    .Include(x => x.PossibleAnswers)
                    .Include(x => x.Test)
                    .Include(x => x.Test.Course)
                    .FirstOrDefault(t => t.Id == id);
                return QuestionFromDb;
            }
        }
    }
}
