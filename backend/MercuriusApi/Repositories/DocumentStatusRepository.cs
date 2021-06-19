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

        public DocumentStatusRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public DocumentStatus GetDocumentStatusSingleRecord(int id)
        {
            return _context.DocumentStatus.FirstOrDefault(t => t.DocumentStatus_Id == id);
        }

        public List<DocumentStatus> GetDocumentStatusRecords()
        {
            return _context.DocumentStatus.ToList();
        }
    }
}