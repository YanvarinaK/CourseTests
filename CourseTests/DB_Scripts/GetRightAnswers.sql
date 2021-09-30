USE CourseTestsDB;
GO
CREATE PROCEDURE GetRightAnswers
	@idOfUser UNIQUEIDENTIFIER
	AS
SELECT PossibleAnswer_Id, PossibleAnswers.Name 
FROM UserPossibleAnswers
JOIN PossibleAnswers ON UserPossibleAnswers.PossibleAnswer_Id = PossibleAnswers.Id
WHERE UserPossibleAnswers.User_Id = @idOfUser AND PossibleAnswers.IsRight = 1;