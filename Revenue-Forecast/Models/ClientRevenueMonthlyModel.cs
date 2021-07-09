
using Revenue_Forecast.Data.EntityModels;
using System;

namespace Revenue_Forecast.Models
{
    public class ClientRevenueMonthlyModel
    {
        public ClientRevenueMonthlyModel(ClientRevenue client)
        {
            Id = client.Id;
            ClientName = client.ClientName;
            ProjectName = client.ProjectName;
            JobNumber = client.JobNumber;
            NetRevenue = client.NetRevenue;
            StatusName = Enum.GetName(typeof(RevenueStatus), client.Status);
            MonthName = Enum.GetName(typeof(Month), client.Month);
        }
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public int JobNumber { get; set; }
        public string StatusName { get; set; }
        public float NetRevenue { get; set; }
        public string MonthName { get; set; }
    }
}
