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

        public ArticlePositionRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddArticlePositionRecord(ArticlePosition articlePosition)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity =
                    _context.ArticlePosition.FirstOrDefault(x =>
                        x.ArticlePosition_Id == articlePosition.ArticlePosition_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{articlePosition.ArticlePosition_Id}' already exists.");

                _context.ArticlePosition.Add(articlePosition);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdateArticlePositionRecord(ArticlePosition articlePosition)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.ArticlePosition.Update(articlePosition);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteArticlePositionRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.ArticlePosition.FirstOrDefault(t => t.ArticlePosition_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.ArticlePosition.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public ArticlePosition GetArticlePositionSingleRecord(int id)
        {
            return _context.ArticlePosition.FirstOrDefault(t => t.ArticlePosition_Id == id);
        }

        public List<ArticlePosition> GetArticlePositionRecords()
        {
            return _context.ArticlePosition.ToList();
        }
    }
}