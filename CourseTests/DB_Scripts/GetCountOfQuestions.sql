USE CourseTestsDB;
GO
CREATE PROCEDURE GetCountOfQuestions
	@idOfTest UNIQUEIDENTIFIER,
	@countOfQuestions INT OUTPUT
	AS
SELECT @countOfQuestions = COUNT(*) FROM Questions
WHERE TestId = @idOfTest;