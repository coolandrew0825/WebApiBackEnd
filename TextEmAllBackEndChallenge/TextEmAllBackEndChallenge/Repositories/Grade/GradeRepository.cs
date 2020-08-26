using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string dbConnection;

        #region Sql Queries
        private const string _getStudentGradeById = @"SELECT c.CourseID
                                                    ,c.Title
                                                    ,c.Credits
                                                    ,sg.Grade
                                                    FROM dbo.Course c
                                                    INNER JOIN dbo.StudentGrade sg
                                                    ON c.CourseID = sg.CourseID
                                                    WHERE Grade IS NOT NULL
													AND sg.StudentID = @StudentId;";

        // includes the calculation of GPA in the SQL query
        // brings less data over => improves efficiency
        private const string _getGrades = @"SELECT sg.StudentID StudentID
                                            ,p.FirstName FirstName
                                            ,p.LastName LastName
											,(SUM(sg.Grade * c.Credits) / SUM(CASE WHEN sg.Grade IS NOT NULL THEN c.Credits END)) Gpa
                                            FROM dbo.Person p
                                            INNER JOIN dbo.StudentGrade sg
                                            ON p.PersonID = sg.StudentID
											INNER JOIN dbo.Course c
											ON sg.CourseID = c.CourseID
                                            GROUP BY sg.StudentID, p.FirstName, p.LastName;";
        #endregion

        public GradeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            dbConnection = _configuration.GetConnectionString("Default");
        }

        /// <summary>
        /// Gets all the grade of a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// a list of grade object
        /// </returns>
        public List<Grades> GetGradeByStudentId(int studentId)
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                List<Grades> gradeList = connection.Query<Grades>(_getStudentGradeById, new { studentId }).ToList();

                return gradeList;
            }
        }

        /// <summary>
        /// Gets gpa of all students
        /// </summary>
        /// <returns>
        /// a list of gpa of all students
        /// </returns>
        public List<StudentGpa> GetAllGpa()
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                List<StudentGpa> gpaList = connection.Query<StudentGpa>(_getGrades).ToList();

                return gpaList;
            }
        }
    }
}