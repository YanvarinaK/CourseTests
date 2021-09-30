USE CourseTestsDB;
GO
CREATE PROCEDURE GetRightAnswersInTest
	@idOfUser UNIQUEIDENTIFIER,
	@idOfTest UNIQUEIDENTIFIER
	AS
SELECT PossibleAnswer_Id, PossibleAnswers.Name 
FROM UserPossibleAnswers
JOIN PossibleAnswers ON UserPossibleAnswers.PossibleAnswer_Id = PossibleAnswers.Id
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
WHERE UserPossibleAnswers.User_Id = @idOfUser AND PossibleAnswers.IsRight = 1 AND Questions.TestId = @idOfTest;