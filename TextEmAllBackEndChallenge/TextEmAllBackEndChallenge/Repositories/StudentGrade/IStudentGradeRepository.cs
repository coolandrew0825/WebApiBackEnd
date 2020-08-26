using System.Collections.Generic;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public interface IStudentGradeRepository
    {
        /// <summary>
        /// Getting a list of student grade record by student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// a list of student grade
        /// </returns>
        public StudentGrade GetStudentGradeByIds(int studentId, int courseId);

        /// <summary>
        /// create a student grade row in StudenGrade table
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// boolean value indicates success/failure
        /// </returns>
        public bool Insert(InsertingGrade grade);


        /// <summary>
        /// check if the combination of the student & course already exists
        /// </summary>
        /// <param name="studenId"></param>
        /// <param name="courseId"></param>
        /// <returns>
        /// boolean valu indicates it exists or not
        /// </returns>
        public bool IsStudentCourseCombinationExists(int studenId, int courseId);
    }
}
