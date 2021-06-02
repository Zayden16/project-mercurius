using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class ArticleUnitRepository : IArticleUnitRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleUnitRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ArticleUnitRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the article unit single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article unit.</returns>
        public ArticleUnit GetArticleUnitSingleRecord(int id)
        {
            return _context.ArticleUnit.FirstOrDefault(t => t.ArticleUnit_Id == id);
        }

        /// <summary>
        /// Gets the article unit records.
        /// </summary>
        /// <returns>The article units.</returns>
        public List<ArticleUnit> GetArticleUnitRecords()
        {
            return _context.ArticleUnit.ToList();
        }
    }
}
