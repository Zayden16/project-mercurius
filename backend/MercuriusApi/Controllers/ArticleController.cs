using System;
using System.Collections.Generic;
using MercuriusApi.Helpers;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [AuthorizationRequired]
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
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Article patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateArticleRecord(patient);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _dataAccessProvider.GetArticleSingleRecord(id);

                if (data == null)
                    return NotFound($"Entity with {id} not found.");

                _dataAccessProvider.DeleteArticleRecord(id);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}
