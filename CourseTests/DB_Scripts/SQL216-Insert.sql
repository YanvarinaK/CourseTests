USE CourseTestsDB;
INSERT INTO Users (Id, FullName) 
VALUES 
('c6d528ef-dfbc-4486-af93-977fbeae9d84', 'Lipinskiy Artem Dmitrievich'),
('ba66e169-a23c-4c71-afb9-1d6746465199', 'Voitkowa Yana Konstantinovna'),
('a20beff1-5608-4fef-98de-917cdc47eb00', 'Leonov Pavel Ivanovich'),
('91d23d5c-3282-49f9-b485-85ebe770731b', 'Davletshina Margo Olegovna');
INSERT INTO Courses (Id, Name, Description)
VALUES
('c85dcc5a-b414-4e94-a128-386e943446a7', 'DataBase Course', 'Course about DataBases'),
('168c0a97-7464-4f82-91c2-ff28476fa17c', 'C# Course', 'Course about C#'),
('5f7ea179-07f2-45f0-b520-e062f453fc63', 'Algorithms Course', 'Course about Algorithms');
INSERT INTO Tests (Id, Name, Description, CourseId)
VALUES
('015f65ab-85fc-4cde-8d21-cc3bb3f9f662', 'Basics of DataBases', 'basic concepts of DB', 'c85dcc5a-b414-4e94-a128-386e943446a7'),
('862b7c05-2802-4dcf-8a1d-26fe9cdd1e83', 'Basics of C#', 'basic concepts of C#', '168c0a97-7464-4f82-91c2-ff28476fa17c'),
('611def89-9041-4cb3-a1be-094b26e00794', 'Basics of Algorithms', 'basic concepts of Algorithms', '5f7ea179-07f2-45f0-b520-e062f453fc63');
INSERT INTO Questions (Id, Name, Description, TestId)
VALUES
('011a9e5c-c142-4305-bd6b-18b5307e295a', 'Specification of relational database', 'What is a relational database?', '015f65ab-85fc-4cde-8d21-cc3bb3f9f662'),
('0291980d-070a-46b4-b7fa-9e8853272c5d', 'Three concepts of OOP', 'What are the Three Concepts of OOP?', '862b7c05-2802-4dcf-8a1d-26fe9cdd1e83'),
('a2dca7dd-9197-4da4-86cf-585d3b70ef85', 'Complexity of quick sort', 'Complexity of quick sort', '611def89-9041-4cb3-a1be-094b26e00794');
INSERT INTO PossibleAnswers (Id, Name, IsRight, QuestionId)
VALUES
('dd05068c-0cdb-4fe1-a930-1e38c5e7da85', 'Digital database based on the relational model of data', 1, '011a9e5c-c142-4305-bd6b-18b5307e295a'),
('549620aa-ed44-4e87-b2a5-d9fa12a62b8d', 'Encapsulation, inheritance, and polymorphism', 1, '0291980d-070a-46b4-b7fa-9e8853272c5d'),
('a5e69908-7662-4624-839a-d2338167b7c9', 'O(log2 n)', 1, 'a2dca7dd-9197-4da4-86cf-585d3b70ef85');