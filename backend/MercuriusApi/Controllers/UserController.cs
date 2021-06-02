﻿using System.Collections.Generic;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
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
            if (!ModelState.IsValid)
                return BadRequest();

            _dataAccessProvider.AddUserRecord(patient);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdateUserRecord(patient);
            return Ok();
        }
    }
}