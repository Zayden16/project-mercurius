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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public UserController(IUserRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpGet("{id}")]
        public User Details(int id)
        {
            return _dataAccessProvider.GetUserSingleRecord(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddUserRecord(patient);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateUserRecord(patient);
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
                var data = _dataAccessProvider.GetUserSingleRecord(id);

                if (data == null)
                    return NotFound();

                _dataAccessProvider.DeleteUserRecord(id);
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