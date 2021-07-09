
using Revenue_Forecast.Data.EntityModels;
using System;

namespace Revenue_Forecast.Models
{
    public class ClientRevenueViewModel
    {
        public ClientRevenueViewModel(ClientRevenue client)
        {
            Id = client.Id;
            ClientName = client.ClientName;
            ProjectName = client.ProjectName;
            JobNumber = client.JobNumber;
            NetRevenue = client.NetRevenue;
            MonthName = Enum.GetName(typeof(Month), client.Month);
            StatusName = Enum.GetName(typeof(RevenueStatus), client.Status);
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public int JobNumber { get; set; }
        public string MonthName { get; set; }
        public string StatusName { get; set; }
        public float NetRevenue { get; set; }
    }
}
