using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Implemenations;
using SQLProcedureConvert.Services.Interfaces;

namespace SQLProcedureConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeApplicationStatusController : ControllerBase
    {
        private readonly IChangeApplicationStatusService changeApplicationStatusService;

        public ChangeApplicationStatusController(IChangeApplicationStatusService changeApplicationStatusService)
        {
            this.changeApplicationStatusService = changeApplicationStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChangeApplicationStatus>>> GetAllChangeApplicationStatusesAsync()
        {
            try
            {
                return Ok(await changeApplicationStatusService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }
    }
}
