using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
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
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddPlzRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetPlzSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeletePlzRecord(id);
            return Ok();
        }
    }
}
