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

        public UserRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddUserRecord(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUserRecord(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserRecord(int id)
        {
            var entity = _context.User.FirstOrDefault(t => t.User_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        public User GetUserSingleRecord(int id)
        {
            return _context.User.FirstOrDefault(t => t.User_Id == id);
        }

        public List<User> GetUserRecords()
        {
            return _context.User.ToList();
        }
    }
}
