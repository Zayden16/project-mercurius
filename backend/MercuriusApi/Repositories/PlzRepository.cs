using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class PlzRepository : IPlzRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlzRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PlzRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the PLZ record.
        /// </summary>
        /// <param name="plz">The PLZ.</param>
        public void AddPlzRecord(Plz plz)
        {
            _context.Plz.Add(plz);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the PLZ record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeletePlzRecord(int id)
        {
            var entity = _context.Plz.FirstOrDefault(t => t.Plz_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.Plz.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the PLZ single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The postal code.</returns>
        public Plz GetPlzSingleRecord(int id)
        {
            return _context.Plz.FirstOrDefault(t => t.Plz_Id == id);
        }

        /// <summary>
        /// Gets the PLZ records.
        /// </summary>
        /// <returns>The postal codes.</returns>
        public List<Plz> GetPlzRecords()
        {
            return _context.Plz.ToList();
        }
    }
}
