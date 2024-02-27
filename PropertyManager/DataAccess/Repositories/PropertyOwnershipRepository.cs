using Interfaces.Repositories;
using Interfaces.System;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class PropertyOwnershipRepository : IPropertyOwnershipRepository
    {
        private readonly IDataAccessService _dataAccessService;

        public PropertyOwnershipRepository(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
        }

        public async Task<List<PropertyOwnership>> GetAllPropertyOwnerships()
        {
            return (List<PropertyOwnership>)_dataAccessService.Query<PropertyOwnership>().ToList();
        }

        public async Task<List<PropertyOwnership>> GetAllPropertyOwnerships(IEnumerable<Func<PropertyOwnership, bool>> filters = null, Expression<Func<PropertyOwnership, object>> orderBy = null, bool orderByDescending = false)
        {
            IEnumerable<PropertyOwnership> query = _dataAccessService.Query<PropertyOwnership>();

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

        public async Task<PropertyOwnership> GetPropertyOwnershipById(Guid id)
        {
            return (PropertyOwnership)_dataAccessService.Query<PropertyOwnership>().Where(propertyOwnership => propertyOwnership.Id.Equals(id)).FirstOrDefault();
        }
        
        public async Task<List<PropertyOwnership>> GetPropertyOwnershipsByContactId(Guid id)
        {
            return (List<PropertyOwnership>)_dataAccessService.Query<PropertyOwnership>().Where(propertyOwnership => propertyOwnership.ContactId.Equals(id)).ToList();
        }

        public async Task<List<PropertyOwnership>> GetPropertyOwnershipsByPropertyId(Guid id)
        {
            return (List<PropertyOwnership>)_dataAccessService.Query<PropertyOwnership>().Where(propertyOwnership => propertyOwnership.PropertyId.Equals(id)).ToList();
        }

        public async Task<PropertyOwnership> UpdatePropertyOwnership(PropertyOwnership propertyOwnership)
        {
            _dataAccessService.Update<PropertyOwnership>(propertyOwnership);
            return propertyOwnership;
        }

        public async Task<PropertyOwnership> CreatePropertyOwnership(PropertyOwnership propertyOwnership)
        {
            PropertyOwnership updatingParent = _dataAccessService.Query<PropertyOwnership>()
                .Where(ownership => ownership.PropertyId.Equals(propertyOwnership.PropertyId))
                .OrderByDescending(o => o.EffectiveFrom)
                
                .FirstOrDefault();

            updatingParent.EffectiveTill = propertyOwnership.EffectiveFrom;

            await UpdatePropertyOwnership(updatingParent);

            _dataAccessService.Add<PropertyOwnership>(propertyOwnership);
            return propertyOwnership;
        }

        public void DeletePropertyOwnershipById(Guid id)
        {
            _dataAccessService.SoftRemoveById<PropertyOwnership>(id);
        }

    }
}
