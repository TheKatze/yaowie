using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Users;

namespace Yaowie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto dto)
        {
            await userService.CreateUser(dto);

            return Created("", "");
        }

        [HttpGet("test")]
        public bool Works()
        {
            return true;
        }
    }
}
