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
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Customer.FirstOrDefault(x => x.Customer_Id == customer.Customer_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{customer.Customer_Id}' already exists.");

                _context.Customer.Add(customer);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateCustomerRecord(Customer customer)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Customer.Update(customer);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteCustomerRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Customer.FirstOrDefault(t => t.Customer_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Customer.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
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