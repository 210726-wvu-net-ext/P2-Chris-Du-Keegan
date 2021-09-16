﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostN.Domain;
using Microsoft.Extensions.Logging;

namespace PostN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly ILogger<FollowerController> _logger;
        private readonly IUserRepo _repo;
        public FollowerController(ILogger<FollowerController> logger, IUserRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var follower = _repo.GetFollowers().First(x => x.Id == id);
            return Ok(follower);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Create(Follower follower)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
            }

            try
            {
                var newfollower = _repo.AddAFollower(follower);
                return Ok(newfollower);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Username", e.Message);
                return Ok(e.Message);
            }

        }

        // PUT api/<FollowerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe, int id)
        {
            try
            {
                var updateUser = await _repo.UpdateUser(id, otherFirstName, otherLastName, otherEmail, otherPhoneNumber, otherAboutMe);
                return Ok(updateUser);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteFollower(id);
        }
    }
}