using CourseTests.DataTransferObjects.PossibleAnswer;
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
    public class PossibleAnswerCRUDService : IPossibleAnswerCRUDService
    {
        public bool Create(PossibleAnswerCreate possibleAnswer)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    PossibleAnswer entity = new PossibleAnswer()
                    {
                        Id = Guid.NewGuid(),
                        Name = possibleAnswer.Name,
                        IsRight = possibleAnswer.IsRight,
                        QuestionId = possibleAnswer.QuestionId,
                    };
                    db.PossibleAnswers.Add(entity);
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
                PossibleAnswer possibleAnswerFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Entry(possibleAnswerFromDb).State = EntityState.Deleted;
                    db.PossibleAnswers.Remove(possibleAnswerFromDb);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public PossibleAnswerView Get(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                PossibleAnswer entity = GetEntity(id);
                PossibleAnswerView possibleAnswer = new PossibleAnswerView()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    IsRight = entity.IsRight,
                    QuestionId = entity.QuestionId
                };
                return possibleAnswer;
            }
        }

        public List<PossibleAnswerList> List()
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<PossibleAnswerList> possibleAnswers = db.PossibleAnswers
                    .Select(p => new PossibleAnswerList
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsRight = p.IsRight,
                        QuestionId = p.QuestionId
                    }).ToList();
                return possibleAnswers;
            }
        }

        public List<PossibleAnswerList> ListPagination(int page = 0, int pageSize = 4)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<PossibleAnswerList> possibleAnswers = db.PossibleAnswers
                    .OrderBy(x=> x.Name)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .Select(p => new PossibleAnswerList
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsRight = p.IsRight,
                        QuestionId = p.QuestionId
                    }).ToList();
                return possibleAnswers;
            }
        }

        public bool Update(PossibleAnswerUpdate newPossibleAnswer, Guid id)
        {
            try
            {
                PossibleAnswer possibleAnswerFromDb = GetEntity(id);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    possibleAnswerFromDb.Name = newPossibleAnswer.Name;
                    possibleAnswerFromDb.IsRight = newPossibleAnswer.IsRight;
                    possibleAnswerFromDb.QuestionId = newPossibleAnswer.QuestionId;
                    db.Entry(possibleAnswerFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private PossibleAnswer GetEntity(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                PossibleAnswer possibleAnswerFromDb = db.PossibleAnswers
                    .Include(x => x.Question)
                    .FirstOrDefault(t => t.Id == id);
                return possibleAnswerFromDb;
            }
        }
    }
}
