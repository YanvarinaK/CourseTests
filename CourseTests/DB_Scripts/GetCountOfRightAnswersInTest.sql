USE CourseTestsDB;
GO
CREATE PROCEDURE GetCountOfRightAnswersInTest
	@idOfUser UNIQUEIDENTIFIER,
	@idOfTest UNIQUEIDENTIFIER
	AS
SELECT COUNT(*) FROM PossibleAnswers
JOIN UserPossibleAnswers ON UserPossibleAnswers.PossibleAnswer_Id = PossibleAnswers.Id
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
WHERE UserPossibleAnswers.User_Id = @idOfUser AND PossibleAnswers.IsRight = 1 AND Questions.TestId = @idOfTest;