using CourseTests.DataTransferObjects.PossibleAnswer;
using CourseTests.DataTransferObjects.Question;
using CourseTests.DataTransferObjects.Test;
using CourseTests.DataTransferObjects.TestBuilder;
using CourseTests.GlobalInterfaces;
using CourseTests.Services.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.Services
{
    public class TestBuilder : ITestBuilder
    {
        private readonly IQuestionCRUDService questionCRUDService;

        private readonly IPossibleAnswerCRUDService possibleAnswerCRUDService;

        private readonly ITestCRUDService testCRUDService;

        public TestBuilder()
        {
            this.questionCRUDService = new QuestionCRUDService();
            this.possibleAnswerCRUDService = new PossibleAnswerCRUDService();
            this.testCRUDService = new TestCRUDService();
        }

        public Guid QuestionBuild(QuestionBuildSettings setting)
        {
            int countIsRight = setting.possibleAnswers.Where(i => i.IsRight).Count();
            if (countIsRight < 1)
            {
                throw new Exception("IsRight doesn't exist");
            }
            QuestionCreate question = new QuestionCreate()
            {
                TestId = setting.TestId,
                Name = setting.Name,
                Description = setting.Description
            };
            Guid? questionId;
            questionCRUDService.Create(question, out questionId);
            if (questionId == null)
            {
                throw new Exception("Failed Create Question");
            }
            var possibleAnswerCreates = setting.possibleAnswers
                .Select(pa => new PossibleAnswerCreate
                {
                    Name = pa.Name,
                    IsRight = pa.IsRight,
                    QuestionId = questionId.Value
                })
                .ToList();
            foreach (var item in possibleAnswerCreates)
            {
                possibleAnswerCRUDService.Create(item);
            }
            return questionId.Value;
        }

        public bool TestBuild(TestCreateSettings settings)
        {
            try
            {
                TestCreate test = new TestCreate()
                {
                    CourseId = settings.CourseId,
                    Name = settings.Name,
                    Description = settings.Description
                };
                Guid? testId;
                testCRUDService.Create(test, out testId);
                if (testId == null)
                {
                    throw new Exception("Failed Test Create");
                }
                var questionCreates = settings.questions
                    .Select(q => new QuestionBuildSettings
                    {
                        Name = q.Name,
                        Description = q.Description,
                        TestId = testId.Value,
                        possibleAnswers = q.possibleAnswers
                    })
                    .ToList();
                foreach (var item in questionCreates)
                {
                    QuestionBuild(item);
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
