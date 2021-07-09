using System;

namespace Revenue_Forecast.Data.EntityModels
{
    public class AuditBase : EntityBase
    {
        public DateTime ChangeDateTime { get; set; }
    }
}
