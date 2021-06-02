using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DocumentRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the document record.
        /// </summary>
        /// <param name="document">The document.</param>
        public void AddDocumentRecord(Document document)
        {
            _context.Document.Add(document);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the document record.
        /// </summary>
        /// <param name="document">The document.</param>
        public void UpdateDocumentRecord(Document document)
        {
            _context.Document.Update(document);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the document record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeleteDocumentRecord(int id)
        {
            var entity = _context.Document.FirstOrDefault(t => t.Document_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.Document.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the document single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The document.</returns>
        public Document GetDocumentSingleRecord(int id)
        {
            return _context.Document.FirstOrDefault(t => t.Document_Id == id);
        }

        /// <summary>
        /// Gets the document records.
        /// </summary>
        /// <returns>The documents.</returns>
        public List<Document> GetDocumentRecords()
        {
            return _context.Document.ToList();
        }
    }
}
