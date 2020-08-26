using System.Collections.Generic;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Getting a student's transcript by student id
        /// </summary>
        /// <param name="person"></param>
        /// <param name="studentId"></param>
        /// <returns>
        /// returns a transcript object
        /// </returns>
        public Transcript GetTranscriptByStudentId(Person person, int studentId);

        /// <summary>
        /// getting all students' GPAs
        /// </summary>
        /// <returns>
        /// returns a list of transcript object
        /// </returns>
        public List<StudentGpa> GetAllGpas();

        /// <summary>
        /// insert grade into database
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// student grade object of the record
        /// </returns>
        public ReturningGrade InsertStudentGrade(InsertingGrade grade);

        /// <summary>
        /// check if the combination of the student & course already exists
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// boolean valu indicates it exists or not
        /// </returns>
        public bool IsStudentCourseCombinationExists(InsertingGrade grade);
    }
}