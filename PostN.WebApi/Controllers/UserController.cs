
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostN.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PostN.WebApi.Models;

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
        public async Task<ActionResult<User>> GetUsers()
        {
            var user = await _repo.GetUsers();
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repo.GetUsersById(id);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Create(CreatedUser user)
        {
            
            if (!ModelState.IsValid)
            {
                return Ok();
            }

            try
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    AboutMe = user.AboutMe,
                    State = user.State,
                    Country = user.Country,
                    Admin = user.Admin,
                    PhoneNumber = user.PhoneNumber,
                    DoB = user.DoB

                };
                var returnedUSer = await _repo.AddAUser(newUser);
                return Ok(returnedUSer);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Username", e.Message);
                ModelState.AddModelError("Email", e.Message);
                
                return BadRequest(e.Message);
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
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repo.DeleteUserById(id);
            if (result == false)
                return NotFound($"Post with ID: {id} not found!");
            return Ok();
        }
    }
}
