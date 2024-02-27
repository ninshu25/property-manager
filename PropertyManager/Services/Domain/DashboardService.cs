using DataAccess.Repositories;
using Interfaces.Repositories;
using Models.DataTransferObjects;
using Models.Entities;
using System.Linq.Expressions;

namespace Services.Domain
{
    public class DashboardService : IDashboardService
    {
        private readonly IPropertyOwnershipService _propertyOwnershipService;
        private readonly IPropertyService _propertyService;

        public DashboardService(IPropertyOwnershipService propertyOwnershipService, IPropertyService propertyService)
        {
            _propertyOwnershipService = propertyOwnershipService ?? throw new ArgumentNullException(nameof(propertyOwnershipService));
            _propertyService = propertyService ?? throw new ArgumentNullException(nameof(propertyService));
        }

        public async Task<DashboardDto> GetDashboardDetails()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            var filters = new List<Func<PropertyOwnership, bool>>
            {
                ownership => ownership.EffectiveFrom >= today
            };

            var propertiesFilter = new List<Func<Property, bool>>
            {
                property => property.RegistrationDate >= firstDayOfMonth && property.RegistrationDate < firstDayOfNextMonth
            };

            Expression<Func<PropertyOwnership, object>> orderBy = ownership => ownership.EffectiveFrom;
            Expression<Func<Property, object>> orderByProperties = property => property.RegistrationDate;

            bool orderByDescending = true;



            List<Property> properties = await _propertyService.GetAllProperties(propertiesFilter, orderByProperties, orderByDescending);
            List<PropertyOwnership> ownershipsTransfered = await _propertyOwnershipService.GetAllPropertyOwnerships(filters, orderBy, orderByDescending);


            decimal highestPrice = ownershipsTransfered.OrderByDescending(o => o.PriceAcquisition)
                                            .Select(o => o.PriceAcquisition)
                                            .FirstOrDefault();


            var newProperties = new CardData { Name = "New Properties", Value = properties.Count};
            var newOwnershipsTransfered = new CardData { Name = "Ownerships Transferred", Value = ownershipsTransfered.Count };
            var newHighestSoldProperty = new CardData { Name = "Highest Sold Property", Value = (int)highestPrice };


            var dashboardDto = new DashboardDto 
            { 
                PropertyOwnerships = ownershipsTransfered,
                PropertyTypes = GetTotalPropertiesByType(),
                CardData = [newProperties, newOwnershipsTransfered, newHighestSoldProperty]
            };

           
            return dashboardDto;
        }

        internal List<CardData> GetTotalPropertiesByType()
        {
            var propertyCounts = _propertyService.GetTotalPropertiesByType();

            var cardDataList = propertyCounts.Select(kv => new CardData
            {
                Name = kv.Key.ToString(), // Assuming PropertyType is an enum and you want its string representation
                Value = kv.Value
            }).ToList();

            return cardDataList;
        }
    }
}
