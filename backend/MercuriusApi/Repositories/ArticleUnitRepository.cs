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

        public ArticleUnitRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public ArticleUnit GetArticleUnitSingleRecord(int id)
        {
            return _context.ArticleUnit.FirstOrDefault(t => t.ArticleUnit_Id == id);
        }

        public List<ArticleUnit> GetArticleUnitRecords()
        {
            return _context.ArticleUnit.ToList();
        }
    }
}