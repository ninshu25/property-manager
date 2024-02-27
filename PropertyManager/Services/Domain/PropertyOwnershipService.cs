using Interfaces.Repositories;
using Models.Entities;
using System.Linq.Expressions;

namespace Services.Domain
{
    public class PropertyOwnershipService : IPropertyOwnershipService
    {
        private readonly IPropertyOwnershipRepository _propertyOwnershipsRepository;
        public PropertyOwnershipService(IPropertyOwnershipRepository propertyOwnershipsRepository)
        {
            _propertyOwnershipsRepository = propertyOwnershipsRepository ?? throw new ArgumentNullException(nameof(propertyOwnershipsRepository));
        }

        public async Task<List<PropertyOwnership>> GetAllPropertyOwnerships()
        {
            return await _propertyOwnershipsRepository.GetAllPropertyOwnerships();
        }

        public async Task<List<PropertyOwnership>> GetAllPropertyOwnerships(IEnumerable<Func<PropertyOwnership, bool>> filters = null, Expression<Func<PropertyOwnership, object>> orderBy = null, bool orderByDescending = false)
        {
            return await _propertyOwnershipsRepository.GetAllPropertyOwnerships(filters, orderBy, orderByDescending);
        }

        public async Task<PropertyOwnership> GetPropertyOwnershipById(Guid id)
        {
            return await _propertyOwnershipsRepository.GetPropertyOwnershipById(id);
        }

        public async Task<List<PropertyOwnership>> GetPropertyOwnershipsByContactId(Guid id)
        {
            return await _propertyOwnershipsRepository.GetPropertyOwnershipsByContactId(id);
        }

        public async Task<List<PropertyOwnership>> GetPropertyOwnershipsByPropertyId(Guid id)
        {
            return await _propertyOwnershipsRepository.GetPropertyOwnershipsByPropertyId(id);
        }

        public async Task<PropertyOwnership> UpdatePropertyOwnership(PropertyOwnership propertyOwnership)
        {
            return await _propertyOwnershipsRepository.UpdatePropertyOwnership(propertyOwnership);
        }

        public async Task<PropertyOwnership> CreatePropertyOwnership(PropertyOwnership propertyOwnership)
        {
            return await _propertyOwnershipsRepository.CreatePropertyOwnership(propertyOwnership);
        }

        public void DeletePropertyOwnershipById(Guid id)
        {
            _propertyOwnershipsRepository.DeletePropertyOwnershipById(id);
        }
    }
}
