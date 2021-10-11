using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class ViewCarYearModel
    {
        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }
    }

    public class ViewCarSubModel
    {
        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("year")]
        public int year { get; set; }
    }

    public class ViewEngineCCModel
    {
        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("year")]
        public int year { get; set; }

        [JsonProperty("subModel")]
        public string subModel { get; set; }
    }
}

