using Interfaces.Repositories;
using Models.DataTransferObjects;
using Models.Entities;
using Models.Enums;
using System.Linq.Expressions;

namespace Services.Domain
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository ?? throw new ArgumentNullException(nameof(propertyRepository));
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _propertyRepository.GetAllProperties();
        }

        public async Task<PaginationDto> GetPropertiesWithPagination(int currentPage, int pageSize)
        {
            return await _propertyRepository.GetPropertiesWithPagination(currentPage, pageSize);
        }

        public async Task<List<Property>> GetAllProperties(IEnumerable<Func<Property, bool>> filters = null, Expression<Func<Property, object>> orderBy = null, bool orderByDescending = false)
        {
            return await _propertyRepository.GetAllProperties(filters, orderBy, orderByDescending);
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            return await _propertyRepository.GetPropertyById(id);
        }

        public Dictionary<PropertyType, int> GetTotalPropertiesByType()
        {
            return _propertyRepository.GetTotalPropertiesByType();
        }

        public async Task<Property> UpdateProperty(Property property)
        {
            return await _propertyRepository.UpdateProperty(property);
        }

        public async Task<Property> CreateProperty(Property property)
        {
            return await _propertyRepository.CreateProperty(property);
        }

        public void DeletePropertyById(Guid id)
        {
            _propertyRepository.DeletePropertyById(id);
        }
    }
}
