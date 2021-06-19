using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class TaxRateRepository : ITaxRateRepository
    {
        private readonly PostgreSqlContext _context;

        public TaxRateRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddTaxRateRecord(TaxRate taxRate)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.TaxRate.FirstOrDefault(x => x.Taxrate_Id == taxRate.Taxrate_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{taxRate.Taxrate_Id}' already exists.");

                _context.TaxRate.Add(taxRate);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateTaxRateRecord(TaxRate taxRate)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.TaxRate.Update(taxRate);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteTaxRateRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.TaxRate.FirstOrDefault(t => t.Taxrate_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.TaxRate.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public TaxRate GetTaxRateSingleRecord(int id)
        {
            return _context.TaxRate.FirstOrDefault(t => t.Taxrate_Id == id);
        }


        public List<TaxRate> GetTaxRateRecords()
        {
            return _context.TaxRate.ToList();
        }
    }
}