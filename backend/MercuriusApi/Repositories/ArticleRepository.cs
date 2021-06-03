using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ArticleRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the article record.
        /// </summary>
        /// <param name="article">The article.</param>
        public void AddArticleRecord(Article article)
        {
            var entity = _context.Article.FirstOrDefault(x => x.Article_Id == article.Article_Id);

            if (entity != null)
                throw new Exception($"Entity with id: '{article.Article_Id}' already exists.");

            _context.Article.Add(article);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the article record.
        /// </summary>
        /// <param name="article">The article.</param>
        public void UpdateArticleRecord(Article article)
        {
            _context.Article.Update(article);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the article record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="Exception">Entity with {id} not found.</exception>
        public void DeleteArticleRecord(int id)
        {
            var entity = _context.Article.FirstOrDefault(t => t.Article_Id == id);

            if (entity == null)
                throw new Exception($"Entity with {id} not found.");

            _context.Article.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the article single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The article.</returns>
        public Article GetArticleSingleRecord(int id)
        {
            return _context.Article.FirstOrDefault(t => t.Article_Id == id);
        }

        /// <summary>
        /// Gets the article records.
        /// </summary>
        /// <returns>The articles.</returns>
        public List<Article> GetArticleRecords()
        {
            return _context.Article.ToList();
        }
    }
}
