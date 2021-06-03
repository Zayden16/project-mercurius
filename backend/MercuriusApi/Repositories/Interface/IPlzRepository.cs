using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IPlzRepository  
    {
        /// <summary>
        /// Adds the PLZ record.
        /// </summary>
        /// <param name="plz">The PLZ.</param>
        void AddPlzRecord(Plz plz);

        /// <summary>
        /// Deletes the PLZ record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePlzRecord(int id);

        /// <summary>
        /// Gets the PLZ single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The postal code.</returns>
        Plz GetPlzSingleRecord(int id);

        /// <summary>
        /// Gets the PLZ records.
        /// </summary>
        /// <returns>The postal codes.</returns>
        List<Plz> GetPlzRecords();  
    }  
}
