namespace TextEmAllBackEndChallenge.Models
{
    public class StudentGpa
    {
        /// <summary>
        /// student id
        /// </summary>
        /// <value></value>
        public int StudentId { get; set; }

        /// <summary>
        /// first name
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// last name
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// GPA
        /// </summary>
        /// <value></value>
        public double? Gpa { get; set; }
    }
}
