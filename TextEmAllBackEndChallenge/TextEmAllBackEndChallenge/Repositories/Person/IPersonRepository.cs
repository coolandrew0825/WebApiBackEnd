using TextEmAllBackEndChallenge.Models;

namespace TextEmAllBackEndChallenge.Repositories
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Gets a Person object by person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>
        /// a Person object
        /// </returns>
        public Person GetPersonById(int personId);
    }
}