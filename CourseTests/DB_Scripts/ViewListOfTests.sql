CREATE VIEW ListOfTests AS
SELECT Name AS NameOfTest, (SELECT COUNT(*) FROM Questions WHERE Questions.TestId = Tests.Id) AS CountOfQuestions
FROM CourseTestsDB.dbo.Tests