-- Challenge 3

-- if the index with the same name arleady exists, delete the existing index
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_CourseID_StudentID')
DROP INDEX IX_CourseID_StudentID ON dbo.StudentGrade;

-- Create a nonclustered index called IX_CourseID_StudentID on dbo.StudentGrade table using course id and student id
CREATE UNIQUE NONCLUSTERED INDEX [IX_CourseID_StudentID]
ON dbo.StudentGrade ([CourseID], [StudentID])

GO