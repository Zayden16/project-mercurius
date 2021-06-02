using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _dataAccessProvider;

        public CustomerController(ICustomerRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dataAccessProvider.GetCustomerRecords();
        }

        [HttpGet("{id}")]
        public Customer Details(int id)
        {
            return _dataAccessProvider.GetCustomerSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddCustomerRecord(patient);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Customer patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateCustomerRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dataAccessProvider.GetCustomerSingleRecord(id);

            if (data == null)
                return NotFound();

            _dataAccessProvider.DeleteCustomerRecord(id);
            return Ok();
        }
    }
}
