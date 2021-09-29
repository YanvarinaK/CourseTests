CREATE VIEW ListOfCourses AS
SELECT Name AS NameOfCourse, (SELECT COUNT(*) FROM Tests WHERE Tests.CourseId = Courses.Id) AS CountOfTests
FROM CourseTestsDB.dbo.Courses
