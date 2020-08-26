using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string dbConnection;
        
        #region Sql Queries
        private const string _getPersonById = @"SELECT [PersonID]
                                                ,[LastName]
                                                ,[FirstName]
                                                ,[HireDate]
                                                ,[EnrollmentDate]
                                                ,[Discriminator]
                                                FROM dbo.Person
                                                WHERE PersonID = @PersonId";
        #endregion

        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            // getting the database connection string from appsetting
            dbConnection = _configuration.GetConnectionString("Default");
        }

        /// <summary>
        /// Gets a Person object by person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>
        /// a Person object
        /// </returns>
        public Person GetPersonById(int personId)
        {
            using(IDbConnection connection = new SqlConnection(dbConnection))
            {
                // using Dapper ORM to get the first result from the database
                Person person = connection.QueryFirstOrDefault<Person>(_getPersonById, new { personId });

                return person;
            }
        }
    }
}
