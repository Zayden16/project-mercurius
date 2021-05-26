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
            _context.User.Add(patient);  
            _context.SaveChanges();  
        }  
  
        public void UpdateUserRecord(User patient)  
        {  
            _context.User.Update(patient);  
            _context.SaveChanges();  
        }  
  
        public void DeleteUserRecord(int id)  
        {  
            var entity = _context.User.FirstOrDefault(t => t.User_Id == id);  
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
