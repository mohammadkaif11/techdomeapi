using Api1.IReposistory;
using Api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUserReposistory _repsistory;
        private object _configuration;

        public Auth(IUserReposistory repository)
        {
            _repsistory = repository;
        }
        [HttpGet("{id}")]


        [HttpPost("{UserRegister}")]
        public IActionResult RegisterUser(User user)
        {
            _repsistory.RegisterByUser(user);
            return Ok(user);
        }

        [HttpPost("AdminRegister")]
        public IActionResult RegisterAdmin(User user)
        {
            _repsistory.RegisterByAdmin(user);
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            User user=_repsistory.Login(login.Email,login.Password);
            if (user == null)
            {
                return BadRequest("user is not found");
            }
            return Ok(user);
        }


    }
}
