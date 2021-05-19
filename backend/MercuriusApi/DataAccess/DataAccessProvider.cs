using System.Collections.Generic;
using System.Linq;
using MercuriusApi.Models;

namespace MercuriusApi.DataAccess
{
    public class DataAccessProvider: IDataAccessProvider  
    {  
        private readonly PostgreSqlContext _context;  
  
        public DataAccessProvider(PostgreSqlContext context)  
        {  
            _context = context;  
        }  
  
        public void AddUserRecord(User patient)  
        {  
            _context.Users.Add(patient);  
            _context.SaveChanges();  
        }  
  
        public void UpdateUserRecord(User patient)  
        {  
            _context.Users.Update(patient);  
            _context.SaveChanges();  
        }  
  
        public void DeleteUserRecord(string id)  
        {  
            var entity = _context.Users.FirstOrDefault(t => t.User_Id == id);  
            _context.Users.Remove(entity);  
            _context.SaveChanges();  
        }  
  
        public User GetUserSingleRecord(string id)  
        {  
            return _context.Users.FirstOrDefault(t => t.User_Id == id);  
        }  
  
        public List<User> GetUserRecords()  
        {  
            return _context.Users.ToList();  
        }  
    }  

}
