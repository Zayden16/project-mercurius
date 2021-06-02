using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class TaxRateController : ControllerBase
    {
        private readonly ITaxRateRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public TaxRateController(ITaxRateRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<TaxRate> Get()
        {
            return _dataAccessProvider.GetTaxRateRecords();
        }

        [HttpGet("{id}")]
        public TaxRate Details(int id)
        {
            return _dataAccessProvider.GetTaxRateSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaxRate patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddTaxRateRecord(patient);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] TaxRate patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateTaxRateRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetTaxRateSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeleteTaxRateRecord(id);
            return Ok();
        }
    }
}
