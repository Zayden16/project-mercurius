using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class DocumentStatusRepository : IDocumentStatusRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentStatusRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DocumentStatusRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the document status single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The document status.</returns>
        public DocumentStatus GetDocumentStatusSingleRecord(int id)
        {
            return _context.DocumentStatus.FirstOrDefault(t => t.DocumentStatus_Id == id);
        }

        /// <summary>
        /// Gets the document status records.
        /// </summary>
        /// <returns>The document status.</returns>
        public List<DocumentStatus> GetDocumentStatusRecords()
        {
            return _context.DocumentStatus.ToList();
        }
    }
}
