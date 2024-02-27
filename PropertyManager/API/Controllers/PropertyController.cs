using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.DataTransferObjects;
using Models.Entities;
using Services.Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            return Ok(await _propertyService.GetAllProperties());
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPropertiesWithPagination([FromQuery] int currentPage, [FromQuery] int pageSize)
        {
            PaginationDto test = await _propertyService.GetPropertiesWithPagination(currentPage, pageSize);
            return Ok(test);
        }

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetPropertyById([FromRoute] Guid propertyId)
        {
            return Ok(await _propertyService.GetPropertyById(propertyId));
        }

        [HttpPut("{propertyId}/update")]
        public async Task<IActionResult> UpdateProperty([FromBody] Property property)
        {
            return Ok(await _propertyService.UpdateProperty(property));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            return Ok(await _propertyService.CreateProperty(property));
        }

        [HttpDelete("{propertyId}/delete")]
        public async Task<IActionResult> DeletePropertyById([FromRoute] Guid propertyId)
        {
            _propertyService.DeletePropertyById(propertyId);
            return Ok();
        }
    }
}
