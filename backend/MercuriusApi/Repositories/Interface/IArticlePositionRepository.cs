using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IArticlePositionRepository  
    {
        /// <summary>
        /// Adds the article position record.
        /// </summary>
        /// <param name="articlePosition">The article position.</param>
        void AddArticlePositionRecord(ArticlePosition articlePosition);

        /// <summary>
        /// Updates the article position record.
        /// </summary>
        /// <param name="articlePosition">The article position.</param>
        void UpdateArticlePositionRecord(ArticlePosition articlePosition);

        /// <summary>
        /// Deletes the article position record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteArticlePositionRecord(int id);

        /// <summary>
        /// Gets the article position records.
        /// </summary>
        /// <returns>The article positions.</returns>
        List<ArticlePosition> GetArticlePositionRecords();  

        /// <summary>
        /// Gets the article positions by document id.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>The article positions.</returns>
        List<ArticlePosition> GetArticlePositionsByDocumentId(int documentId);

        /// <summary>
        /// Gets the article position single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article position.</returns>
        ArticlePosition GetArticlePositionSingleRecord(int id);
    }  
}
