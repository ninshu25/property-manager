using Interfaces.System;
using Models.DataTransferObjects;
using Models.Entities;

namespace Interfaces.Repositories
{
    public interface IDashboardService
    {
        public Task<DashboardDto> GetDashboardDetails();
    }
}
