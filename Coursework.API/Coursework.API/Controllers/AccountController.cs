using System;
using System.Threading.Tasks;
using Coursework.API.DTOs;
using Coursework.API.Services.AuthenticationService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IJwtAuthenticationService jwtAuthenticationService;

        public AccountController(IJwtAuthenticationService jwtAuthenticationService)
        {
            this.jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationToken>> Token([FromBody]LoginModel model)
        {
            try
            {
                var token = await jwtAuthenticationService.Authenticate(model);

                return token;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]UserDTO user)
        {
            try
            {
                await jwtAuthenticationService.RegisterAsync(user);           

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
