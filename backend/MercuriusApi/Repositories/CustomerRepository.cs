using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomerRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the customer record.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void AddCustomerRecord(Customer customer)
        {
            var entity = _context.Customer.FirstOrDefault(x => x.Customer_Id == customer.Customer_Id);

            if (entity != null)
                throw new Exception($"Entity with id: '{customer.Customer_Id}' already exists.");

            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the customer record.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void UpdateCustomerRecord(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the customer record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeleteCustomerRecord(int id)
        {
            var entity = _context.Customer.FirstOrDefault(t => t.Customer_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.Customer.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the customer single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The customer.</returns>
        public Customer GetCustomerSingleRecord(int id)
        {
            return _context.Customer.FirstOrDefault(t => t.Customer_Id == id);
        }

        /// <summary>
        /// Gets the customer records.
        /// </summary>
        /// <returns>The customers.</returns>
        public List<Customer> GetCustomerRecords()
        {
            return _context.Customer.ToList();
        }
    }
}
