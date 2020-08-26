namespace TextEmAllBackEndChallenge.Models
{
    public class Course
    {

        /// <summary>
        /// CourseId
        /// </summary>
        /// <value></value>
        public int CourseId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        /// <value></value>
        public string Title { get; set; }

        /// <summary>
        /// Credits
        /// </summary>
        /// <value></value>
        public int Credits { get; set; }

        /// <summary>
        /// DepartmentId
        /// </summary>
        /// <value></value>
        public int DepartmentId { get; set; }
    }
}