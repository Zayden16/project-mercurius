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
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.User.FirstOrDefault(x => x.User_Id == user.User_Id);
                if (entity != null)
                    throw new Exception($"Entity with id: '{user.User_Id}' already exists.");

                _context.User.Add(user);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateUserRecord(User user)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.User.Update(user);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public User GetUserSingleRecord(int id)
        {
            return _context.User.FirstOrDefault(t => t.User_Id == id);
        }

        public List<User> GetUserRecords()
        {
            return _context.User.ToList();
        }

        public void DeleteUserRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.User.FirstOrDefault(u => u.User_Id == id);
                _context.User.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}