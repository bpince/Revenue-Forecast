using Microsoft.EntityFrameworkCore;
using Revenue_Forecast.Data.EntityModels;
using System.Threading.Tasks;

namespace Revenue_Forecast.Data.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClientRevenue> ClientRevenues { get; set; }
        public DbSet<ClientAudit> ClientAudits { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
