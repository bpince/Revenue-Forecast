using System.ComponentModel.DataAnnotations.Schema;

namespace Revenue_Forecast.Data.EntityModels
{
    public class ClientAudit : AuditBase
    {
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public ClientRevenue Client { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
