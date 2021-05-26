using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.DataAccess
{
    public interface IDataAccessProvider  
    {  
        void AddUserRecord(User patient);  

        void UpdateUserRecord(User patient);  

        void DeleteUserRecord(int id);  

        User GetUserSingleRecord(int id);  

        List<User> GetUserRecords();  
    }  
}
