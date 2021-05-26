using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.DataAccess
{
    public interface IDataAccessProvider  
    {  
        void AddUserRecord(User patient);  
        void UpdateUserRecord(User patient);  
        void DeleteUserRecord(string id);  
        User GetUserSingleRecord(string id);  
        List<User> GetUserRecords();  
    }  
}
