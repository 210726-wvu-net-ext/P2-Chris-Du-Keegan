using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostN.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace PostN.WebApi.Controllers
{
    [Route("api/friends")]
    [Authorize]
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

        // GET api/<FollowerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var follower = _repo.GetFollowers().First(x => x.Id == id);
            return Ok(follower);
        }

        // put api/<FollowerController>
        [HttpPut]
        public async Task<ActionResult<Follower>> Put(bool request, Follower follower)
        {
            if(request == true)
            {
                var newFollower = await _repo.AddAFollower(follower);
                return Ok(newFollower);
            }
            else
            {
                request = false;
                return Ok();
            }
        }

        // DELETE api/<FollowerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.DeleteFollower(id);
            if(x == false)
            {
                return Ok("Are you sure you're frinds?");
            }
            return Ok("Friend has been removed");
        }

    }
}
