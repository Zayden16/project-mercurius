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
    public class PlzController : ControllerBase
    {
        private readonly IPlzRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlzController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public PlzController(IPlzRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Plz> Get()
        {
            return _dataAccessProvider.GetPlzRecords();
        }

        [HttpGet("{id}")]
        public Plz Details(int id)
        {
            return _dataAccessProvider.GetPlzSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Plz patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddPlzRecord(patient);
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
                var data = _dataAccessProvider.GetPlzSingleRecord(id);

                if (data == null)
                    return NotFound();

                _dataAccessProvider.DeletePlzRecord(id);
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
