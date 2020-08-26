using System.Collections.Generic;

namespace TextEmAllBackEndChallenge.Models
{
    public class Transcript
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
        public decimal Gpa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<Grades> Grades { get; set; }
    }
}
