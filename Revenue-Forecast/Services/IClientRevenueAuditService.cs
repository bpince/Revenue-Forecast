using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revenue_Forecast.Services
{
    public interface IClientRevenueAuditService
    {
        Task<ClientAudit> CreateAudit(ClientRevenue existingClient, ClientRevenue newClient);
        Task CommitAudit(ClientAudit audit);
        Task<IEnumerable<ClientAuditViewModel>> GetAudits(int clientId);
    }
}