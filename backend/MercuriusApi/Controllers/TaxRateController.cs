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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddTaxRateRecord(patient);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] TaxRate patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateTaxRateRecord(patient);
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
                var data = _dataAccessProvider.GetTaxRateSingleRecord(id);

                if (data == null)
                    return NotFound();

                _dataAccessProvider.DeleteTaxRateRecord(id);
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
