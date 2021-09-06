USE CourseTestsDB;
SELECT QuestionId, (SELECT Name FROM Questions WHERE Id = QuestionId) AS QuestionName, COUNT(*) AS CountOfRightAnswers
FROM PossibleAnswers
WHERE IsRight = 1
GROUP BY QuestionId