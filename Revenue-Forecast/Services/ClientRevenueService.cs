using Microsoft.EntityFrameworkCore;
using Revenue_Forecast.Data.DbContext;
using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Revenue_Forecast.Services
{
    public class ClientRevenueService : IClientRevenueService
    {
        private readonly IApplicationDbContext _context;
        private readonly IClientRevenueAuditService _auditService;
        public ClientRevenueService(
            IApplicationDbContext context,
            IClientRevenueAuditService auditService
        )
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<IEnumerable<ClientRevenueViewModel>> GetClients()
        {
            return await _context.ClientRevenues
                .Select(cr => new ClientRevenueViewModel(cr))
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientRevenueMonthlyModel>> GetMonthlyProjects(
            ProjectSearch? search,
            string searchTerm
        )
        {
            var currentMonth = (Month)DateTime.UtcNow.Month;

            var monthlyProjects = _context.ClientRevenues
               .Where(p => p.Month == currentMonth);

            Expression<Func<ClientRevenue, bool>> projectFilter = null;

            if (search.HasValue
                && !string.IsNullOrWhiteSpace(searchTerm))
            {
                switch (search)
                {

                    case ProjectSearch.ClientName:
                        {
                            projectFilter = p => p.ClientName.Contains(searchTerm);
                            break;
                        }
                    case ProjectSearch.JobNumber:
                        {
                            projectFilter = p => p.JobNumber.ToString().Contains(searchTerm);
                            break;
                        }
                    case ProjectSearch.Status:
                        {
                            projectFilter = p => p.StatusString.Contains(searchTerm);
                            break;
                        }
                }

                if (projectFilter != null)
                {
                    monthlyProjects = monthlyProjects.Where(projectFilter);
                }
            }

            return await monthlyProjects
                .Select(cr => new ClientRevenueMonthlyModel(cr))
                .ToListAsync();
        }

        public async Task<ClientRevenue> GetClient(int id)
        {
            var client = await _context
                .ClientRevenues
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                //error
            }

            return client;
        }

        public async Task<string> UpdateClient(int id, ClientRevenue updatedClient)
        {
            var validationError = updatedClient.ValidateClient();

            if(!string.IsNullOrWhiteSpace(validationError))
            {
                return validationError;
            }

            var client = await _context
                .ClientRevenues
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return "Could not find client";
            }

            var audit = await _auditService.CreateAudit(client, updatedClient);

            client.JobNumber = updatedClient.JobNumber;
            client.Month = updatedClient.Month;
            client.NetRevenue = updatedClient.NetRevenue;
            client.ProjectName = updatedClient.ProjectName;
            client.Status = updatedClient.Status;
            client.ClientName = updatedClient.ClientName;
            client.StatusString = Enum.GetName(typeof(RevenueStatus), updatedClient.Status);

            await _context.SaveChanges();

            //add audit
            await _auditService.CommitAudit(audit);

            return string.Empty;
        }

        public async Task<string> CreateClient(ClientRevenue client)
        {
            var validationError = client.ValidateClient();

            if (!string.IsNullOrWhiteSpace(validationError))
            {
                return validationError;
            }

            client.StatusString = Enum.GetName(typeof(RevenueStatus), client.Status);

            await _context.ClientRevenues.AddAsync(client);
            
            await _context.SaveChanges();

            return string.Empty;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context
                .ClientRevenues
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (client == null)
            {
                return false;
            }

            _context.ClientRevenues.Remove(client);

            await _context.SaveChanges();

            return true;
        }

    }
}
