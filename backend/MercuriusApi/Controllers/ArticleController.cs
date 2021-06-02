using System;
using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public ArticleController(IArticleRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _dataAccessProvider.GetArticleRecords();
        }

        [HttpGet("{id}")]
        public Article Details(int id)
        {
            return _dataAccessProvider.GetArticleSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Article patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddArticleRecord(patient);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Article patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateArticleRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetArticleSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeleteArticleRecord(id);
            return Ok();
        }
    }
}
