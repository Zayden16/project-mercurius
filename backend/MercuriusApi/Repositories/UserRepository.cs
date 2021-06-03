using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the user record.
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddUserRecord(User user)
        {
            var entity = _context.User.FirstOrDefault(x => x.User_Id == user.User_Id);

            if (entity != null)
                throw new Exception($"Entity with id: '{user.User_Id}' already exists.");

            _context.User.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the user record.
        /// </summary>
        /// <param name="user">The user.</param>
        public void UpdateUserRecord(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the user single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        public User GetUserSingleRecord(int id)
        {
            return _context.User.FirstOrDefault(t => t.User_Id == id);
        }

        /// <summary>
        /// Gets the user records.
        /// </summary>
        /// <returns>The users.</returns>
        public List<User> GetUserRecords()
        {
            return _context.User.ToList();
        }
    }
}
