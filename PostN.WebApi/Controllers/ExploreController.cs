﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostN.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExploreController : ControllerBase
    {
        private readonly ILogger<ExploreController> _logger;
        private readonly IPostRepo _prepo;
        private readonly IUserRepo _urepo;
        public ExploreController(ILogger<ExploreController> logger, IPostRepo prepo, IUserRepo urepo)
        {
            _logger = logger;
            _prepo = prepo;
            _urepo = urepo;
        }
        // GET: api/<ExploreController>
        [HttpGet]
        public  IActionResult GetPosts()
        {
            var posts = _prepo.GetPost();
            return Ok(posts);
        }
        [HttpGet]
        public IActionResult SearchUsers()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult SearchUsers(User user)
        {
            if(_urepo.SearchUsers(user.Username).Equals(null))
            {
                return Ok("User does not exist");
            }
            else
            {
                //ViewBag.Username = restaurants.Name;
                //TempData["restaurant"] = restaurants.Name;
                //TempData.Keep("user");
                _logger.LogCritical("Found user");
                return Ok(_urepo.SearchUsers(user.Username));
            }
        }

        // POST api/<ExploreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExploreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExploreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
