USE CourseTestsDB;
GO
CREATE PROCEDURE GetCountOfRightAnswers
	@idOfUser UNIQUEIDENTIFIER
	AS
SELECT COUNT(*) FROM PossibleAnswers
JOIN UserPossibleAnswers ON UserPossibleAnswers.PossibleAnswer_Id = PossibleAnswers.Id
WHERE UserPossibleAnswers.User_Id = @idOfUser AND PossibleAnswers.IsRight = 1;