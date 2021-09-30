USE CourseTestsDB;
GO
CREATE PROCEDURE GetCountOfTests
	@idOfCourse UNIQUEIDENTIFIER,
	@countOfTests INT OUTPUT
	AS
SELECT @countOfTests = COUNT(*) FROM Tests
WHERE CourseId = @idOfCourse;