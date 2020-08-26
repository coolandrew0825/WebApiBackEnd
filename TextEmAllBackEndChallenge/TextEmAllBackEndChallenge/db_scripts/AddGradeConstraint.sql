-- Challenge 3

-- Add a contraint named CK_StudenGrade to encure grade is either null or between 0.00 to 4.00 when not null
ALTER TABLE dbo.StudentGrade WITH CHECK
ADD CONSTRAINT [CK_StudentGrade] CHECK
(([Grade] >= (0.00) AND [Grade] <= (4.00) OR [Grade] IS NULL))