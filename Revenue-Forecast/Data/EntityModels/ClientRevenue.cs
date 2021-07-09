
namespace Revenue_Forecast.Data.EntityModels
{
    public class ClientRevenue : EntityBase
    {
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public int JobNumber { get; set; }
        public Month Month { get; set; }
        public RevenueStatus Status { get; set; }
        public string StatusString { get; set; }
        public float NetRevenue { get; set; }

        public string ValidateClient()
        {
            if (string.IsNullOrWhiteSpace(ClientName)
                || string.IsNullOrWhiteSpace(ProjectName)
                || JobNumber <= 0
                || Month == null
                || Status == null
                || NetRevenue <= 0)
            {
                return "All fields are required.";
            }

            return string.Empty;
        }
    }

    public enum RevenueStatus
    {
        Rejected,
        Pending,
        Approved
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
