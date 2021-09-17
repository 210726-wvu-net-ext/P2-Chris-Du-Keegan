﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PostN.Domain;
using PostN.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PostN.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepo _userRepo;
        public AuthController(ILogger<AuthController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }
        [HttpPost, Route("login")]
        public async Task<ActionResult> Login([FromBody]LoginUser user)
        {
            if (user == null) return BadRequest("Invalid client request");

            var loggingInUser = new User
            {
                Username = user.Username,
                Password = user.Password
            };
            if(await _userRepo.UserLoginAsync(loggingInUser))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretSupersupes#345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44365",
                    audience: "https://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString, message = "You have logged in!", success = true });
            }
            return Unauthorized(new { message = "Your credentials were incorrect! Please try again or Sign up.", success = false });
        }
    }
}
