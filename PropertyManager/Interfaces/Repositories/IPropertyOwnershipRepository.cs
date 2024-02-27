using Interfaces.System;
using Models.Entities;
using System.Linq.Expressions;

namespace Interfaces.Repositories
{
    public interface IPropertyOwnershipRepository
    {
        public Task<List<PropertyOwnership>> GetAllPropertyOwnerships();

        public Task<List<PropertyOwnership>> GetAllPropertyOwnerships(IEnumerable<Func<PropertyOwnership, bool>> filters = null, Expression<Func<PropertyOwnership, object>> orderBy = null, bool orderByDescending = false);

        public Task<PropertyOwnership> GetPropertyOwnershipById(Guid id);

        public Task<List<PropertyOwnership>> GetPropertyOwnershipsByContactId(Guid id);

        public Task<List<PropertyOwnership>> GetPropertyOwnershipsByPropertyId(Guid id);

        public Task<PropertyOwnership> UpdatePropertyOwnership(PropertyOwnership propertyOwnership);

        public Task<PropertyOwnership> CreatePropertyOwnership(PropertyOwnership propertyOwnership);

        public void DeletePropertyOwnershipById(Guid id);
    }
}
