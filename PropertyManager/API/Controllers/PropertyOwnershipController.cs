using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services.Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/property-ownerships")]
    public class PropertyOwnershipController : ControllerBase
    {
        private readonly IPropertyOwnershipService _propertyOwnershipService;
        public PropertyOwnershipController(IPropertyOwnershipService propertyOwnershipService)
        {
            _propertyOwnershipService = propertyOwnershipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPropertyOwnerships()
        {
            return Ok(await _propertyOwnershipService.GetAllPropertyOwnerships());
        }

        [HttpGet("{propertyOwnerhsipId}")]
        public async Task<IActionResult> GetPropertyOwnershipById([FromRoute] Guid propertyOwnerhsipId)
        {
            return Ok(await _propertyOwnershipService.GetPropertyOwnershipById(propertyOwnerhsipId));
        }

        [HttpGet("contact/{contactId}")]
        public async Task<IActionResult> GetPropertyOwnershipsByContactId([FromRoute] Guid contactId)
        {
            return Ok(await _propertyOwnershipService.GetPropertyOwnershipsByContactId(contactId));
        }

        [HttpGet("property/{propertyId}")]
        public async Task<IActionResult> GetPropertyOwnershipsByPropertyId([FromRoute] Guid propertyId)
        {
            return Ok(await _propertyOwnershipService.GetPropertyOwnershipsByPropertyId(propertyId));
        }

        [HttpPut("{propertyOwnerhsipId}")]
        public async Task<IActionResult> UpdatePropertyOwnership([FromBody] PropertyOwnership propertyOwnership)
        {
            return Ok(await _propertyOwnershipService.UpdatePropertyOwnership(propertyOwnership));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePropertyOwnership([FromBody] PropertyOwnership propertyOwnership)
        {
            return Ok(await _propertyOwnershipService.CreatePropertyOwnership(propertyOwnership));
        }

        [HttpDelete("{propertyOwnerhsipId}")]
        public async Task<IActionResult> DeletePropertyOwnershipById([FromRoute] Guid propertyOwnerhsipId)
        {
            _propertyOwnershipService.DeletePropertyOwnershipById(propertyOwnerhsipId);
            return Ok();
        }
    }
}
