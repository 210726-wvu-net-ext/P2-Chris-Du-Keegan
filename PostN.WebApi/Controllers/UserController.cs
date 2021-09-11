<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostN.Domain;
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
>>>>>>> feature/Chris
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostN.WebApi.Controllers
{
    
=======
using Microsoft.Extensions.Logging;
using PostN.Domain;

namespace PostN.WebApi.Controllers
{
>>>>>>> feature/Chris
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
<<<<<<< HEAD
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
=======
        private IUserRepo _userrepo;

        public UserController(IUserRepo userrepo, ILogger<UserController> logger)
        {
            _logger = logger;
            _userrepo = userrepo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var note = _userrepo.GetUsers();
            return Ok(note);
>>>>>>> feature/Chris
        }
    }
}
