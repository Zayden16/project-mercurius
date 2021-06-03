using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface ITaxRateRepository  
    {
        /// <summary>
        /// Adds the tax rate record.
        /// </summary>
        /// <param name="taxRate">The tax rate.</param>
        void AddTaxRateRecord(TaxRate taxRate);

        /// <summary>
        /// Updates the tax rate record.
        /// </summary>
        /// <param name="taxRate">The tax rate.</param>
        void UpdateTaxRateRecord(TaxRate taxRate);

        /// <summary>
        /// Deletes the tax rate record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteTaxRateRecord(int id);

        /// <summary>
        /// Gets the tax rate single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The tax rate.</returns>
        TaxRate GetTaxRateSingleRecord(int id);

        /// <summary>
        /// Gets the tax rate records.
        /// </summary>
        /// <returns>The tax rates.</returns>
        List<TaxRate> GetTaxRateRecords();  
    }  
}
