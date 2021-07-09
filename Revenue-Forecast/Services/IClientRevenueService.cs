using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revenue_Forecast.Services
{
    public interface IClientRevenueService
    {
        Task<string> CreateClient(ClientRevenue client);
        Task<bool> DeleteClient(int id);
        Task<ClientRevenue> GetClient(int id);
        Task<IEnumerable<ClientRevenueViewModel>> GetClients();
        Task<IEnumerable<ClientRevenueMonthlyModel>> GetMonthlyProjects(ProjectSearch? search, string searchTerm);
        Task<string> UpdateClient(int id, ClientRevenue updatedClient);
    }
}