using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IArticleRepository  
    {
        /// <summary>
        /// Adds the article record.
        /// </summary>
        /// <param name="article">The article.</param>
        void AddArticleRecord(Article article);

        /// <summary>
        /// Updates the article record.
        /// </summary>
        /// <param name="article">The article.</param>
        void UpdateArticleRecord(Article article);

        /// <summary>
        /// Deletes the article record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteArticleRecord(int id);

        /// <summary>
        /// Gets the article single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article.</returns>
        Article GetArticleSingleRecord(int id);

        /// <summary>
        /// Gets the article records.
        /// </summary>
        /// <returns>The articles.</returns>
        List<Article> GetArticleRecords();  
    }  
}
