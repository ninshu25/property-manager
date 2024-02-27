using Interfaces.Repositories;
using Interfaces.System;
using Microsoft.EntityFrameworkCore;
using Models.DataTransferObjects;
using Models.Entities;
using Models.Enums;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IDataAccessService _dataAccessService;

        public PropertyRepository(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return _dataAccessService.Query<Property>().Where<Property>(property => property.Deleted.Equals(false)).ToList();
        }
        
        public async Task<PaginationDto> GetPropertiesWithPagination(int currentPage, int pageSize)
        {
            //return _dataAccessService.Query<Property>()
            //                          .Where<Property>(property => property.Deleted.Equals(false))
            //                          .OrderBy(p => p.RegistrationDate)
            //                          .Skip((currentPage - 1) * pageSize)
            //                          .Take(pageSize)
            //                          .ToList();


            var query = _dataAccessService.Query<Property>()
                                  .Where(property => !property.Deleted)
                                  .OrderBy(p => p.RegistrationDate);

            int totalCount = query.Count();

            var pagedProperties = query.Skip((currentPage - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            var newt = new PaginationDto
            {
                count = totalCount,
                data = pagedProperties.Cast<object>().ToList()
            };

            return newt;
        }

        

        public async Task<List<Property>> GetAllProperties(IEnumerable<Func<Property, bool>> filters = null, Expression<Func<Property, object>> orderBy = null, bool orderByDescending = false)
        {
            IEnumerable<Property> query = _dataAccessService.Query<Property>();

            // Apply filters
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            // Apply sorting
            if (orderBy != null)
            {
                if (orderByDescending)
                {
                    query = query.OrderByDescending(orderBy.Compile());
                }
                else
                {
                    query = query.OrderBy(orderBy.Compile());
                }
            }

            // Execute the query and retrieve the results
            return query.ToList();
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            return (Property)_dataAccessService.Query<Property>().Where(contact => contact.Id.Equals(id)).FirstOrDefault();
        }

        public Dictionary<PropertyType, int> GetTotalPropertiesByType()
        {
            var propertyCounts = _dataAccessService.Query<Property>()
                .Where(p => !p.Deleted)
                .GroupBy(p => p.PropertyTypeId)
                .Select(g => new { PropertyType = g.Key, Count = g.Count() })
                .ToDictionary(x => x.PropertyType, x => x.Count);

            return propertyCounts;
        }

        public async Task<Property> UpdateProperty(Property property)
        {
            _dataAccessService.Update<Property>(property);
            return property;
        }

        public async Task<Property> CreateProperty(Property property)
        {
            _dataAccessService.Add<Property>(property);
            return property;
        }

        public void DeletePropertyById(Guid id)
        {
            _dataAccessService.SoftRemoveById<Property>(id);
        }

    }
}
