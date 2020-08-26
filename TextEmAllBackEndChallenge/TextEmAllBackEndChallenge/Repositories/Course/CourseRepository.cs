using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string dbConnection;

        #region Sql Queries
        private const string _getCourseById = @"SELECT [CourseID]
                                                ,[Title]
                                                ,[Credits]
                                                ,[DepartmentID]
                                                FROM [Course]
                                                WHERE CourseID = @CourseId;";
        #endregion
        
        public CourseRepository(IConfiguration configuraion)
        {
            _configuration = configuraion;

            // getting my local database connection string
            dbConnection = _configuration.GetConnectionString("Default");
        }


        /// <summary>
        /// getting a course by course id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>
        /// a course object
        /// </returns>
        public Course GetCourseByCourseId(int courseId)
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                // getting the first course object with the course id using Dapper
                Course course = connection.QueryFirstOrDefault<Course>(_getCourseById, new { courseId });

                return course;
            }
        }
    }
}