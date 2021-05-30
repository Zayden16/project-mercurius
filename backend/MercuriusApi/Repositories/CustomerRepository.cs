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

        public CustomerRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddCustomerRecord(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomerRecord(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomerRecord(int id)
        {
            var entity = _context.Customer.FirstOrDefault(t => t.Customer_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.Customer.Remove(entity);
            _context.SaveChanges();
        }

        public Customer GetCustomerSingleRecord(int id)
        {
            return _context.Customer.FirstOrDefault(t => t.Customer_Id == id);
        }

        public List<Customer> GetCustomerRecords()
        {
            return _context.Customer.ToList();
        }
    }
}
