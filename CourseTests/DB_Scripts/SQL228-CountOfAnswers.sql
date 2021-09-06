USE CourseTestsDB;
SELECT COUNT(*) AS Count_of_RightAnswers FROM PossibleAnswers
WHERE IsRight = 1 AND QuestionId = '23521A02-487C-41FE-8F0E-326EF15F6C78';
SELECT COUNT(*) AS Count_Of_Right_Answers FROM PossibleAnswers
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
WHERE IsRight = 1 AND TestId = '9A2D017A-8DC6-4957-ADD2-2254727FA156';
SELECT COUNT(*) AS CountOfRightAnswers FROM PossibleAnswers
JOIN Questions ON PossibleAnswers.QuestionId = Questions.Id
JOIN Tests ON Questions.TestId = Tests.Id
WHERE IsRight = 1 AND CourseId = '5F7EA179-07F2-45F0-B520-E062F453FC63';
