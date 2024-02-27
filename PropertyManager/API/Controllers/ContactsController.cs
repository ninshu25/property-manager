using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.DataTransferObjects;
using Models.Entities;
using Services.Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;
        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _contactsService.GetAllContacts());
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetContactsWithPagination([FromQuery] int currentPage, [FromQuery] int pageSize)
        {
            PaginationDto test = await _contactsService.GetContactsWithPagination(currentPage, pageSize);
            return Ok(test);
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactById([FromRoute] Guid contactId)
        {
            return Ok(await _contactsService.GetContactById(contactId));
        }

        [HttpPut("{contactId}/update")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            return Ok(await _contactsService.UpdateContact(contact));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            return Ok(await _contactsService.CreateContact(contact));
        }

        [HttpDelete("{contactId}/delete")]
        public async Task<IActionResult> DeleteContactById([FromRoute] Guid contactId)
        {
            _contactsService.DeleteContactById(contactId);
            return Ok();
        }
    }
}
