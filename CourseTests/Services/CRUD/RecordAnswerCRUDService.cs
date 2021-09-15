using CourseTests.DataTransferObjects.RecordAnswer;
using CourseTests.Entities;
using CourseTests.GlobalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CourseTests.DataTransferObjects.PossibleAnswer;

namespace CourseTests.Services.CRUD
{
    public class RecordAnswerCRUDService : IRecordAnswerCRUDService
    {
        public bool Create(RecordAnswerCreate recordAnswer)
        {
            try
            {
                User userFromDb = GetUser(recordAnswer.UserId);
                List<PossibleAnswer> answers = GetListAnswers(recordAnswer.PossibleAnswersIds);
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    db.Users.Attach(userFromDb);
                    foreach (var item in answers)
                    {
                        db.PossibleAnswers.Attach(item);
                        userFromDb.PossibleAnswers.Add(item);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid userId, Guid possibleAnswerId)
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    var user = db.Users.Include(x => x.PossibleAnswers).FirstOrDefault(x => x.Id == userId);
                    var answer = db.PossibleAnswers.Include(x => x.Users).FirstOrDefault(x => x.Id == possibleAnswerId);
                    user.PossibleAnswers.Remove(answer);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public RecordAnswerView Get(Guid userId)
        {

            User entity = GetUser(userId);
            RecordAnswerView recordAnswer = new RecordAnswerView()
            {
                UserId = entity.Id,
                FullNameUser = entity.FullName,
                Answers = entity.PossibleAnswers.Select(p => new PossibleAnswerView
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsRight = p.IsRight,
                    QuestionId = p.QuestionId
                }).ToList()
            };
            return recordAnswer;

        }

        public List<RecordAnswerView> List()
        {
            try
            {
                using (CourseTestsContext db = new CourseTestsContext())
                {
                    var users = db.Users.Include(x => x.PossibleAnswers)
                        .Where(x => x.PossibleAnswers.Count > 0)
                        .ToList();

                    var recordAnswers = users.Select(u => new RecordAnswerView
                    {
                        UserId = u.Id,
                        FullNameUser = u.FullName,
                        Answers = u.PossibleAnswers != null
                        ? u.PossibleAnswers.Select(p => new PossibleAnswerView
                        {
                            Id = p.Id,
                            IsRight = p.IsRight,
                            QuestionId = p.QuestionId,
                            Name = p.Name
                        }).ToList()
                        : new List<PossibleAnswerView>()
                    })
                    .ToList();

                    return recordAnswers;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private User GetUser(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                User UserFromDb = db.Users
                    .Include(x => x.PossibleAnswers)
                    .FirstOrDefault(t => t.Id == id);
                return UserFromDb;
            }
        }

        private List<PossibleAnswer> GetListAnswers(List<Guid> Ids)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                List<PossibleAnswer> answers = db.PossibleAnswers.Where(i=> Ids.Contains(i.Id)).ToList();
                return answers;
            }
        }

        private PossibleAnswer GetAnswer(Guid id)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                return db.PossibleAnswers.Include(p => p.Users).FirstOrDefault(p => p.Id == id);
            }
        }

        public List<RecordAnswerView> ListPagination(int page = 0, int pageSize = 4)
        {
            using (CourseTestsContext db = new CourseTestsContext())
            {
                var users = db.Users.Include(x => x.PossibleAnswers)
                    .Where(x => x.PossibleAnswers.Count > 0)
                    .OrderBy(x=> x.FullName)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToList();

                var recordAnswers = users.Select(u => new RecordAnswerView
                {
                    UserId = u.Id,
                    FullNameUser = u.FullName,
                    Answers = u.PossibleAnswers != null
                    ? u.PossibleAnswers.Select(p => new PossibleAnswerView
                    {
                        Id = p.Id,
                        IsRight = p.IsRight,
                        QuestionId = p.QuestionId,
                        Name = p.Name
                    }).ToList()
                    : new List<PossibleAnswerView>()
                })
                .ToList();

                return recordAnswers;
            }
        }
    }
}
