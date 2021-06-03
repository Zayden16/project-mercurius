using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IDocumentStatusRepository  
    {
        /// <summary>
        /// Gets the document status single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The document status.</returns>
        DocumentStatus GetDocumentStatusSingleRecord(int id);

        /// <summary>
        /// Gets the document status records.
        /// </summary>
        /// <returns>The document status.</returns>
        List<DocumentStatus> GetDocumentStatusRecords();  
    }  
}
