using System.Collections.Generic;
using MercuriusApi.Helpers;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [AuthorizationRequired]
    [Route("api/[controller]")]
    public class ArticleUnitController : ControllerBase
    {
        private readonly IArticleUnitRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleUnitController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public ArticleUnitController(IArticleUnitRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ArticleUnit> Get()
        {
            return _dataAccessProvider.GetArticleUnitRecords();
        }

        [HttpGet("{id}")]
        public ArticleUnit Details(int id)
        {
            return _dataAccessProvider.GetArticleUnitSingleRecord(id);
        }
    }
}
