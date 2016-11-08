using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanq.ItcastOA.Common
{
    public class WebCommon
    {
        public static string GetJsonList<T>(int total,IEnumerable<T> rows)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            string data = JsonConvert.SerializeObject(new { total = total, rows = rows }, Formatting.Indented, timeFormat);
            return data;
        }

        public static string GetJson(object value)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            string data = JsonConvert.SerializeObject(value, Formatting.Indented, timeFormat);
            return data;
        }
    }
}
