using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class Vehiclebrand
    {
        [JsonProperty("brand")]
        public string brand { get; set; }
    }


    public class Titles
    {
        [JsonProperty("titleCode")]
        public int titleCode { get; set; }

        [JsonProperty("titleDesc")]
        public string titleDesc { get; set; }
    }
}
