namespace TextEmAllBackEndChallenge.Models
{
    public class StudentGrade
    {
        /// <summary>
        /// EnrollmentId
        /// </summary>
        /// <value></value>
        public int EnrollmentId { get; set; }

        /// <summary>
        /// CourseId
        /// </summary>
        /// <value></value>
        public int CourseId { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        /// <value></value>
        public int StudentId { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        /// <value></value>
        public double? Grade { get; set; }
    }
}