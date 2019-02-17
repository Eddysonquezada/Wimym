using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wimym.Model.Shared.Helper;
using Wimym.Services;

namespace Wimym.Api.Controllers
{
   // [Authorize]
    public class OriginController : Controller
    {
        private readonly IOriginService _originService;     

        public OriginController(
            IOriginService originService
        )
        {
            _originService = originService;
        }

        [HttpGet("origins")]
        public async Task<IActionResult> GetAll(
            [FromQuery] ApiFilter queryFilter
        )
        {
            return Ok(
                await _originService.GetAllAsync(queryFilter)
            );
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}