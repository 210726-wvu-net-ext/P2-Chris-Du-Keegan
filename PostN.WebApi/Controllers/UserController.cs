using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PostN.Domain;

namespace PostN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
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
        }
    }
}
