using Microsoft.AspNetCore.Mvc;
using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Revenue_Forecast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController
    {
        [HttpGet("getMonths")]
        public IEnumerable<IntKeyValueModel> GetMonthsKeyValue()
        {
            return GetEnumDictionary(typeof(Month));
        }

        [HttpGet("getStatuses")]
        public IEnumerable<IntKeyValueModel> GetStatusesKeyValue()
        {
            return GetEnumDictionary(typeof(RevenueStatus));
        }

        [HttpGet("getSearchFields")]
        public IEnumerable<IntKeyValueModel> GetSearchFieldsKeyValue()
        {
            return GetEnumDictionary(typeof(ProjectSearch));
        }

        private IEnumerable<IntKeyValueModel> GetEnumDictionary(Type enumType)
        {
            return Enum.GetValues(enumType)
                .Cast<int>()
                .Select(e => new IntKeyValueModel()
                {
                    Key = Enum.GetName(enumType, e),
                    Value = e
                });
        }
    }
}
