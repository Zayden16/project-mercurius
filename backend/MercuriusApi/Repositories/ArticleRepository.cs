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

        public ArticleRepository(PostgreSqlContext context)
        {
            _context = context;
        }


        public void AddArticleRecord(Article article)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Article.FirstOrDefault(x => x.Article_Id == article.Article_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{article.Article_Id}' already exists.");

                _context.Article.Add(article);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateArticleRecord(Article article)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Article.Update(article);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteArticleRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Article.FirstOrDefault(t => t.Article_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Article.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Article GetArticleSingleRecord(int id)
        {
            return _context.Article.FirstOrDefault(t => t.Article_Id == id);
        }

        public List<Article> GetArticleRecords()
        {
            return _context.Article.ToList();
        }
    }
}