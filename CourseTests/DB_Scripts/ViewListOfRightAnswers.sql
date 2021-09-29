CREATE VIEW ListOfRightAnswers AS
SELECT PossibleAnswers.Id AS RightAnswerId,
	   PossibleAnswers.Name AS RightAnswerName,
	   PossibleAnswers.QuestionId AS QuestionID,
	   Questions.Name AS QuestionName
FROM CourseTestsDB.dbo.PossibleAnswers
INNER JOIN CourseTestsDB.dbo.Questions ON Questions.Id = PossibleAnswers.QuestionId
WHERE PossibleAnswers.IsRight = 1;