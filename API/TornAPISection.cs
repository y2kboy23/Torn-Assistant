using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Torn_Assistant.API
{
    public class TornAPISection
    {
        public Uri uri { get; set; }
        public DateTimeOffset uriTimestamp { get; set; }
        public JObject apiData { get; set; }
    }
}
