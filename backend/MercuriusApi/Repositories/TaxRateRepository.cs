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

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TaxRateRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the tax rate record.
        /// </summary>
        /// <param name="taxRate">The tax rate.</param>
        public void AddTaxRateRecord(TaxRate taxRate)
        {
            _context.TaxRate.Add(taxRate);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the tax rate record.
        /// </summary>
        /// <param name="taxRate">The tax rate.</param>
        public void UpdateTaxRateRecord(TaxRate taxRate)
        {
            _context.TaxRate.Update(taxRate);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the tax rate record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeleteTaxRateRecord(int id)
        {
            var entity = _context.TaxRate.FirstOrDefault(t => t.Taxrate_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.TaxRate.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the tax rate single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The tax rate.</returns>
        public TaxRate GetTaxRateSingleRecord(int id)
        {
            return _context.TaxRate.FirstOrDefault(t => t.Taxrate_Id == id);
        }

        /// <summary>
        /// Gets the tax rate records.
        /// </summary>
        /// <returns>The tax rates.</returns>
        public List<TaxRate> GetTaxRateRecords()
        {
            return _context.TaxRate.ToList();
        }
    }
}
