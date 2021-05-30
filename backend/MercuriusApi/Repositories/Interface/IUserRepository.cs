using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IUserRepository  
    {  
        void AddUserRecord(User user);  

        void UpdateUserRecord(User user);  

        void DeleteUserRecord(int id);  

        User GetUserSingleRecord(int id);  

        List<User> GetUserRecords();  
    }  
}
