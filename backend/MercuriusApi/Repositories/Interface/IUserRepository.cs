using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IUserRepository  
    {
        /// <summary>
        /// Adds the user record.
        /// </summary>
        /// <param name="user">The user.</param>
        void AddUserRecord(User user);

        /// <summary>
        /// Updates the user record.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUserRecord(User user);

        /// <summary>
        /// Gets the user single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        User GetUserSingleRecord(int id);

        /// <summary>
        /// Gets the user records.
        /// </summary>
        /// <returns>The users.</returns>
        List<User> GetUserRecords();
        
        /// <summary>
        /// Deletes a User record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUserRecord(int id);
    }
}
