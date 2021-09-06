USE CourseTestsDB;
	SELECT * FROM PossibleAnswers
	WHERE IsRight = 1;
	SELECT * FROM Questions
	WHERE Description is not null;