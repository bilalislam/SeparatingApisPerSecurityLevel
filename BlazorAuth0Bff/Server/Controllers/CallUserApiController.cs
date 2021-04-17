﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuth0Bff.Server.Controllers
{
    [ValidateAntiForgeryToken]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class CallUserApiController : ControllerBase
    {
        private readonly MyApiUserOneClient _myApiUserOneClient;

        public CallUserApiController(MyApiUserOneClient myApiUserOneClient)
        {
            _myApiUserOneClient = myApiUserOneClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            // call user API
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var userData = await _myApiUserOneClient.GetUserOneApiData(accessToken);

            return Ok(userData);
        }
    }
}
