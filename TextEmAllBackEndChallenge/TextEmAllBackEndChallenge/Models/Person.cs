using System;

namespace TextEmAllBackEndChallenge.Models
{
    public class Person
    {
        /// <summary>
        /// PersonId
        /// </summary>
        /// <value></value>
        public int PersonId { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// HireDate
        /// </summary>
        /// <value></value>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// EnrollmentDate
        /// </summary>
        /// <value></value>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Discriminator
        /// </summary>
        /// <value></value>
        public string Discriminator { get; set; }
    }
}
