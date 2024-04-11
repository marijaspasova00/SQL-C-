using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Implemenations;
using SQLProcedureConvert.Services.Interfaces;

namespace SQLProcedureConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateContactAsync([FromBody] Contact contact)
        {
            try
            {
                if (contact == null || contact.Name == null)
                {
                    return BadRequest("Invalid input");
                }

                await contactService.CreateAsync(contact);

                return StatusCode(StatusCodes.Status201Created, "Contact added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
            }
        }

    }
}
