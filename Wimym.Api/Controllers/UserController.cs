using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wimym.Model.Shared;
using Wimym.Services;

namespace Wimym.Api.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("users/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(
                await _userService.Get(id)
            );
        }

        [AllowAnonymous]
        [HttpPatch("users/{id}")]
        public async Task<IActionResult> Patch(
            string id,
            [FromBody]UserPartialDto model
        )
        {
            await _userService.PartialUpdate(id, model);
            //the partial update //pacth, for best practice dont return body
            return NoContent();
        }
    }
}
