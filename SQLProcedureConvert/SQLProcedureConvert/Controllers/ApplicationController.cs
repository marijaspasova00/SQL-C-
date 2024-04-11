using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Implemenations;
using SQLProcedureConvert.Services.Interfaces;

namespace SQLProcedureConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateApplicationAsync([FromBody] Application application)
        {
            try
            {
                if (application == null)
                {
                    return BadRequest("Invalid input");
                }

                await _applicationService.CreateAsync(application);

                return StatusCode(StatusCodes.Status201Created, "Application added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }

        [HttpPatch("{applicationID}")]
        public async Task<ActionResult> UpdateApplicationAsync([FromBody] Application application, int applicationID)
        {
            try
            {

                if (applicationID == null)
                {
                    return BadRequest("Invalid input");
                }

                await _applicationService.UpdateAsync(application, applicationID);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
    }
}
