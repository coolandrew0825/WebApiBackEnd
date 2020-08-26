using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public interface ICourseRepository
    {
        /// <summary>
        /// getting a course by course id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>
        /// a course object
        /// </returns>
        public Course GetCourseByCourseId(int courseId);
    }
}