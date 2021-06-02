using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class ArticlePositionController : ControllerBase
    {
        private readonly IArticlePositionRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlePositionController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public ArticlePositionController(IArticlePositionRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ArticlePosition> Get()
        {
            return _dataAccessProvider.GetArticlePositionRecords();
        }

        [HttpGet("{id}")]
        public ArticlePosition Details(int id)
        {
            return _dataAccessProvider.GetArticlePositionSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ArticlePosition patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddArticlePositionRecord(patient);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ArticlePosition patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateArticlePositionRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetArticlePositionSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeleteArticlePositionRecord(id);
            return Ok();
        }
    }
}
