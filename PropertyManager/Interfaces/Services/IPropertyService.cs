using Interfaces.System;
using Models.DataTransferObjects;
using Models.Entities;
using Models.Enums;
using System.Linq.Expressions;

namespace Interfaces.Repositories
{
    public interface IPropertyService
    {
        public Task<List<Property>> GetAllProperties();

        public Task<PaginationDto> GetPropertiesWithPagination(int currentPage, int pageSize);

        public Task<List<Property>> GetAllProperties(IEnumerable<Func<Property, bool>> filters = null, Expression<Func<Property, object>> orderBy = null, bool orderByDescending = false);

        public Task<Property> GetPropertyById(Guid id);

        public Dictionary<PropertyType, int> GetTotalPropertiesByType();

        public Task<Property> UpdateProperty(Property property);

        public Task<Property> CreateProperty(Property property);

        public void DeletePropertyById(Guid id);
    }
}
