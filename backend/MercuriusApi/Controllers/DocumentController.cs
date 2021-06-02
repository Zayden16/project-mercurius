using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public DocumentController(IDocumentRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Document> Get()
        {
            return _dataAccessProvider.GetDocumentRecords();
        }

        [HttpGet("{id}")]
        public Document Details(int id)
        {
            return _dataAccessProvider.GetDocumentSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Document patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddDocumentRecord(patient);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Document patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateDocumentRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetDocumentSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeleteDocumentRecord(id);
            return Ok();
        }
    }
}
