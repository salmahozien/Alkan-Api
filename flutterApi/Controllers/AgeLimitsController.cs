﻿using flutterApi.DTOs.Medical.AgeLmit;
using flutterApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeLimitsController : ControllerBase
    {private readonly IAgeLimitesService _ageLimitesService;

        public AgeLimitsController(IAgeLimitesService ageLimitesService)
        {
            _ageLimitesService = ageLimitesService;
        }

        [HttpPost("AddAgeLimits")]
        public async Task<IActionResult>AddAgeLimits(CreateAgeLimitesDto model)
        {
            var result= await _ageLimitesService.AddAgeLimits(model);
            if(result.Message!=string.Empty || result.AgeLimit == null)
            {
              return BadRequest(result.Message);    
            }
            return Ok(result.AgeLimit);
        }
    }
}
