using System;
using System.Collections.Generic;
using System.Linq;
using TextEmAllBackEndChallenge.Models;
using TextEmAllBackEndChallenge.Repositories;

namespace TextEmAllBackEndChallenge.Services
{
    public class StudentService : IStudentService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly IGradeRepository _gradeRepository;

        public StudentService(IPersonRepository personRepository, IStudentGradeRepository studentGradeRepository, IGradeRepository gradeRepository)
        {
            _personRepository = personRepository;
            _studentGradeRepository = studentGradeRepository;
            _gradeRepository = gradeRepository;
        }

        /// <summary>
        /// Getting a student's transcript by student id
        /// </summary>
        /// <param name="person"></param>
        /// <param name="studentId"></param>
        /// <returns>
        /// returns a transcript object
        /// </returns>
        public Transcript GetTranscriptByStudentId(Person person, int studentId)
        {
            double gpa = 0.0;
            List<Grades> gradeList = _gradeRepository.GetGradeByStudentId(studentId);

            if (gradeList.Count() > 0)
            {
                // getting the GPA of the student
                gpa = getGpaAverage(gradeList);
            }

            // creating the transcript object
            Transcript transcript = new Transcript()
            {
                StudentId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gpa = decimal.Round((decimal)gpa, 1, MidpointRounding.AwayFromZero),
                Grades = gradeList
            };

            return transcript;
        }

        /// <summary>
        /// getting all students' GPAs
        /// </summary>
        /// <returns>
        /// returns a list of transcript object
        /// </returns>
        public List<StudentGpa> GetAllGpas()
        {
            List<StudentGpa> gradeList = _gradeRepository.GetAllGpa();
            return gradeList;
        }

        /// <summary>
        /// calculates gpa
        /// </summary>
        /// <param name="grades"></param>
        /// <returns>
        /// GPA value
        /// </returns>
        private double getGpaAverage(List<Grades> grades)
        {
            double gpaSum = 0.0;
            var count = Convert.ToDouble(grades.Count());

            // adding grade up
            foreach(var grade in grades)
            {
                gpaSum += grade.Grade;
            }

            // sum of grade devided by number of grade
            var gpaAverage = gpaSum / count;

            return gpaAverage;
        }

        /// <summary>
        /// insert grade into database
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// returning grade object of the record
        /// </returns>
        public ReturningGrade InsertStudentGrade(InsertingGrade grade)
        {
            var result = _studentGradeRepository.Insert(grade);

            ReturningGrade returningGrade = null;
            if (result)
            {
                StudentGrade studentGrade = _studentGradeRepository.GetStudentGradeByIds(grade.StudentId, grade.CourseId);

                returningGrade = new ReturningGrade()
                {
                    GradeId = studentGrade.EnrollmentId,
                    CourseId = studentGrade.CourseId,
                    StudentId = studentGrade.StudentId,
                    Grade = studentGrade.Grade
                };
            }

            return returningGrade;
        }

        /// <summary>
        /// check if the combination of the student & course already exists
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// boolean valu indicates it exists or not
        /// </returns>
        public bool IsStudentCourseCombinationExists(InsertingGrade grade)
        {
            var combinationExists = _studentGradeRepository.IsStudentCourseCombinationExists(grade.StudentId, grade.CourseId);

            return combinationExists;
        }
    }
}
