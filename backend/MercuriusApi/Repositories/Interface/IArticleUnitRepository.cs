using System.Collections.Generic;
using MercuriusApi.Models;

namespace MercuriusApi.Repositories.Interface
{
    public interface IArticleUnitRepository  
    {
        /// <summary>
        /// Gets the article unit single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article unit.</returns>
        ArticleUnit GetArticleUnitSingleRecord(int id);

        /// <summary>
        /// Gets the article unit records.
        /// </summary>
        /// <returns>The article units.</returns>
        List<ArticleUnit> GetArticleUnitRecords();  
    }  
}
