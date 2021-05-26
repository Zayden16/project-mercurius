using System.Collections.Generic;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UsersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddUserRecord(patient);
            return Ok();
        }

        [HttpGet("{id}")]
        public User Details(int id)
        {
            return _dataAccessProvider.GetUserSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User patient)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUserRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetUserSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteUserRecord(id);
            return Ok();
        }

        //[ApiController]
        //[Route("[controller]")]
        //public class UserController : ControllerBase
        //{
        //    private readonly ILogger<UserController> _logger;

        //    public UserController(ILogger<UserController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet]
        //    public IEnumerable<WeatherForecast> Get()
        //    {
        //        _logger.LogInformation("Getting Random Weather");
        //        var rng = new Random();
        //        _logger.LogWarning($"Returning Random Weather with " + $"{rng}");
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = rng.Next(-20, 55),
        //        })
        //            .ToArray();
        //    }
        //}
    }
}