using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IDocumentRepository
    {
        /// <summary>
        /// Adds the document record.
        /// </summary>
        /// <param name="document">The document.</param>
        void AddDocumentRecord(Document document);

        /// <summary>
        /// Updates the document record.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        void UpdateDocumentRecord(Document document);

        /// <summary>
        /// Deletes the document record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteDocumentRecord(int id);

        /// <summary>
        /// Gets the document single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The document.</returns>
        Document GetDocumentSingleRecord(int id);

        /// <summary>
        /// Gets the document records.
        /// </summary>
        /// <returns>The documents.</returns>
        List<Document> GetDocumentRecords();
    }
}
