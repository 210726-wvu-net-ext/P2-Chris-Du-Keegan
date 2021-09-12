
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
        public IActionResult Get(int id)
        {
            var user = _repo.GetUsers().First(x => x.Id == id);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
            }

            try
            {
                var newuser = _repo.AddAUser(user);
                return Ok(newuser);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Username", e.Message);
                ModelState.AddModelError("Email", e.Message);
                
                return Ok(e.Message);
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Update(string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe, int id)
        {
            _repo.UpdateUser(otherFirstName, otherLastName, otherEmail, otherPhoneNumber, otherAboutMe, id);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteUser(id);
        }
    }
}
