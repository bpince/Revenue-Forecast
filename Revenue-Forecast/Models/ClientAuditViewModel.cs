using Revenue_Forecast.Data.EntityModels;
using System;

namespace Revenue_Forecast.Models
{
    public class ClientAuditViewModel
    {
        public ClientAuditViewModel(ClientAudit audit)
        {
            ChangeDateTime = string.Format("{0:MM/dd/yyyy HH:mm}", audit.ChangeDateTime);
            OldValues = audit.OldValues;
            NewValues = audit.NewValues;
        }

        public string ChangeDateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
