
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostN.Domain;
﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PostN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepo _repo;
        public UserController(ILogger<UserController> logger, IUserRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var user = _repo.GetUsers();
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
