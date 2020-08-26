using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public class StudentGradeRepository : IStudentGradeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string dbConnection;

        #region Sql Queries
        private const string _getStudentGradeById = @"SELECT [EnrollmentID]
                                                    ,[CourseID]
                                                    ,[StudentID]
                                                    ,[Grade]
                                                    FROM dbo.StudentGrade
                                                    WHERE StudentID = @StudentId
                                                    AND CourseID = @CourseId;";

        private const string _AddStudentGrade = @"INSERT INTO dbo.StudentGrade
                                            VALUES(@CourseId, @StudentId, @Grade);";

        private const string _getStudentCourse = @"SELECT COUNT(*)
                                                FROM [dbo].[StudentGrade]
                                                WHERE CourseID = @CourseId
                                                AND StudentID = @StudentId;";
        #endregion

        public StudentGradeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            dbConnection = _configuration.GetConnectionString("Default");
        }

        /// <summary>
        /// Getting a list of student grade record by student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// a list of student grade
        /// </returns>
        public StudentGrade GetStudentGradeByIds(int studentId, int courseId)
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                // geting a list of student grade object using Dapper
                StudentGrade studentGrade = connection.QueryFirstOrDefault<StudentGrade>(_getStudentGradeById, new { StudentId = studentId, CourseId = courseId });

                return studentGrade;
            }
        }

        /// <summary>
        /// create a student grade row in StudenGrade table
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// boolean value indicates success/failure
        /// </returns>
        public bool Insert(InsertingGrade grade)
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                // inserting student garade to StudentGrade table
                int result = connection.Execute(_AddStudentGrade, new { CourseId = grade.CourseId, StudentId = grade.StudentId, Grade = grade.Grade });

                var isSuccess = (result == 1) ? true : false;

                return isSuccess;
            }
        }

        /// <summary>
        /// check if the combination of the student & course already exists
        /// </summary>
        /// <param name="studenId"></param>
        /// <param name="courseId"></param>
        /// <returns>
        /// boolean valu indicates it exists or not
        /// </returns>
        public bool IsStudentCourseCombinationExists(int studenId, int courseId)
        {
            using (IDbConnection connection = new SqlConnection(dbConnection))
            {
                int result = connection.QueryFirst<int>(_getStudentCourse, new { CourseId = courseId, StudentId = studenId });

                var combinationExists = (result > 0) ? true : false;

                return combinationExists;
            }
        }
    }
}
