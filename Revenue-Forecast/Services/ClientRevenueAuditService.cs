
using Microsoft.EntityFrameworkCore;
using Revenue_Forecast.Data.DbContext;
using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenue_Forecast.Services
{
    public class ClientRevenueAuditService : IClientRevenueAuditService
    {
        private readonly IApplicationDbContext _context;
        public ClientRevenueAuditService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClientAudit> CreateAudit(ClientRevenue existingClient, ClientRevenue newClient)
        {
            //would be better to add this to the override SaveChanges() in ApplicationDbContext but I don't have time.
            var audit = new ClientAudit();
            audit.ClientId = newClient.Id;

            var oldValues = new StringBuilder();
            var newValues = new StringBuilder();
            var anyChanges = false;

            if (existingClient.ClientName != newClient.ClientName)
            {
                oldValues.Append($"Client Name: {existingClient.ClientName}, ");
                newValues.Append($"Client Name: {newClient.ClientName}, ");
                anyChanges = true;
            }

            if (existingClient.ProjectName != newClient.ProjectName)
            {
                oldValues.Append($"Project Name: {existingClient.ProjectName}, ");
                newValues.Append($"Project Name: {newClient.ProjectName}, ");
                anyChanges = true;
            }

            if (existingClient.NetRevenue != newClient.NetRevenue)
            {
                oldValues.Append($"Net Revenue: {existingClient.NetRevenue}, ");
                newValues.Append($"Net Revenue: {newClient.NetRevenue}, ");
                anyChanges = true;
            }

            if (existingClient.JobNumber != newClient.JobNumber)
            {
                oldValues.Append($"Job Number: {existingClient.JobNumber}, ");
                newValues.Append($"Job Number: {newClient.JobNumber}, ");
                anyChanges = true;
            }

            if (existingClient.Month != newClient.Month)
            {
                oldValues.Append($"Month: {existingClient.Month}, ");
                newValues.Append($"Month: {newClient.Month}, ");
                anyChanges = true;
            }

            if (existingClient.Status != newClient.Status)
            {
                oldValues.Append($"Status: {existingClient.Status}, ");
                newValues.Append($"Status: {newClient.Status}, ");
                anyChanges = true;
            }

            if(anyChanges)
            {
                audit.OldValues = oldValues.ToString().TrimEnd(' ', ',');
                audit.NewValues = newValues.ToString().TrimEnd(' ', ',');

                return audit;
            }
            else
            {
                return null;
            }
        }

        public async Task CommitAudit(ClientAudit audit)
        {
            audit.ChangeDateTime = DateTime.UtcNow;

            await _context.ClientAudits.AddAsync(audit);

            await _context.SaveChanges();
        }

        public async Task<IEnumerable<ClientAuditViewModel>> GetAudits(int clientId)
        {
            return await _context.ClientAudits
                .Where(ca => ca.ClientId == clientId)
                .OrderByDescending(ca => ca.ChangeDateTime)
                .Select(ca => new ClientAuditViewModel(ca))
                .ToListAsync();
        }
    }
}
