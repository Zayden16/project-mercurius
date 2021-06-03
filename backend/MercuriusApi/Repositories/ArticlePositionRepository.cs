using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class ArticlePositionRepository : IArticlePositionRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlePositionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ArticlePositionRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the article position record.
        /// </summary>
        /// <param name="articlePosition">The article position.</param>
        public void AddArticlePositionRecord(ArticlePosition articlePosition)
        {
            var entity = _context.ArticlePosition.FirstOrDefault(x => x.ArticlePosition_Id == articlePosition.ArticlePosition_Id);

            if (entity != null)
                throw new Exception($"Entity with id: '{articlePosition.ArticlePosition_Id}' already exists.");

            _context.ArticlePosition.Add(articlePosition);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the article position record.
        /// </summary>
        /// <param name="articlePosition">The article position.</param>
        public void UpdateArticlePositionRecord(ArticlePosition articlePosition)
        {
            _context.ArticlePosition.Update(articlePosition);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the article position record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeleteArticlePositionRecord(int id)
        {
            var entity = _context.ArticlePosition.FirstOrDefault(t => t.ArticlePosition_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.ArticlePosition.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the article position single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article position.</returns>
        public ArticlePosition GetArticlePositionSingleRecord(int id)
        {
            return _context.ArticlePosition.FirstOrDefault(t => t.ArticlePosition_Id == id);
        }

        /// <summary>
        /// Gets the article position records.
        /// </summary>
        /// <returns>The article positions.</returns>
        public List<ArticlePosition> GetArticlePositionRecords()
        {
            return _context.ArticlePosition.ToList();
        }
    }
}
