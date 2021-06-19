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

        public DocumentRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddDocumentRecord(Document document)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Document.FirstOrDefault(x => x.Document_Id == document.Document_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{document.Document_Id}' already exists.");

                _context.Document.Add(document);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateDocumentRecord(Document document)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Document.Update(document);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteDocumentRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Document.FirstOrDefault(t => t.Document_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Document.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Document GetDocumentSingleRecord(int id)
        {
            return _context.Document.FirstOrDefault(t => t.Document_Id == id);
        }

        public List<Document> GetDocumentRecords()
        {
            return _context.Document.ToList();
        }
    }
}