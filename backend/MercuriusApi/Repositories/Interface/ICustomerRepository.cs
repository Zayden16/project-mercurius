using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface ICustomerRepository  
    {  
        void AddCustomerRecord(Customer customer);  

        void UpdateCustomerRecord(Customer customer);  

        void DeleteCustomerRecord(int id);  

        Customer GetCustomerSingleRecord(int id);  

        List<Customer> GetCustomerRecords();  
    }  
}
