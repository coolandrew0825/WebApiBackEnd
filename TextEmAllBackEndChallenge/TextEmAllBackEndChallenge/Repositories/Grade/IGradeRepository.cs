using System.Collections.Generic;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public interface IGradeRepository
    {
        /// <summary>
        /// Gets all the grade of a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// a list of grade object
        /// </returns>
        public List<Grades> GetGradeByStudentId(int studentId);

        /// <summary>
        /// Gets gpa of all students
        /// </summary>
        /// <returns>
        /// a list of gpa of all students
        /// </returns>
        public List<StudentGpa> GetAllGpa();
    }
}