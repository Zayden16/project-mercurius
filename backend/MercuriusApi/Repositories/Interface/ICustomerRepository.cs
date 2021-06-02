using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface ICustomerRepository  
    {
        /// <summary>
        /// Adds the customer record.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void AddCustomerRecord(Customer customer);

        /// <summary>
        /// Updates the customer record.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void UpdateCustomerRecord(Customer customer);

        /// <summary>
        /// Deletes the customer record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCustomerRecord(int id);

        /// <summary>
        /// Gets the customer single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The customer.</returns>
        Customer GetCustomerSingleRecord(int id);

        /// <summary>
        /// Gets the customer records.
        /// </summary>
        /// <returns>The customers.</returns>
        List<Customer> GetCustomerRecords();  
    }  
}
