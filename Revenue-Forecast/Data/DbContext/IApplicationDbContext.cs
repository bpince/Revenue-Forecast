using Microsoft.EntityFrameworkCore;
using Revenue_Forecast.Data.EntityModels;
using System.Threading.Tasks;

namespace Revenue_Forecast.Data.DbContext
{
    public interface IApplicationDbContext
    {
        DbSet<ClientRevenue> ClientRevenues { get; set; }
        DbSet<ClientAudit> ClientAudits { get; set; }
        Task<int> SaveChanges();
    }
}