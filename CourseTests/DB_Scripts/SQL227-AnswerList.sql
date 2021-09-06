USE CourseTestsDB;
SELECT Questions.Id, Questions.Name, Tests.Id, Tests.Name, Courses.Id, Courses.Name
FROM Questions
JOIN Tests ON Questions.TestId = Tests.Id
JOIN Courses ON Tests.CourseId = Courses.Id;
SELECT PossibleAnswers.Id, PossibleAnswers.Name, PossibleAnswers.IsRight, Questions.Id, Questions.Name, Tests.Id, Tests.Name
FROM PossibleAnswers
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
JOIN Tests ON Questions.TestId = Tests.Id;
SELECT PossibleAnswers.Id, PossibleAnswers.Name, PossibleAnswers.IsRight, Questions.Id, Questions.Name, Tests.Id, Tests.Name
FROM PossibleAnswers
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
JOIN Tests ON Questions.TestId = Tests.Id
WHERE PossibleAnswers.IsRight = 1;