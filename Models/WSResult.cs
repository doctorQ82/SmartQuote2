using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{

    public class WSResult
    {
        [JsonProperty(Order = 1)]
        public bool IsError { get; set; }

        [JsonProperty(Order = 2)]
        public string Key { get; set; }

        [JsonProperty(Order = 3)]
        public string Token { get; set; }

        [JsonProperty(Order = 4)]
        public string StatusCode { get; set; }

        [JsonProperty(Order = 5)]
        public string ErrorMessage { get; set; }
    }

    public class Logon
    {
        [Required]
        [JsonProperty(Order = 1)]
        public string Username { get; set; }

        [Required]
        [JsonProperty(Order = 2)]
        public string Password { get; set; }
    }


    public class QTCreate
    {
        [JsonProperty(Order = 1)]
        public Int32 rnNo { get; set; }

        [JsonProperty(Order = 2)]
        public string ReapirType { get; set; }
    }

    public class ResponseCreate
    {
        [JsonProperty(Order = 1)]
        public bool success { get; set; }

        [JsonProperty(Order = 2)]
        public string errorCode { get; set; }

        [JsonProperty(Order = 3)]
        public List<string> errorParams { get; set; }
        public string message { get; set; }

        [JsonProperty(Order = 4)]
        public ResponseDetail data { get; set; }
    }
    public class ResponseDetail
    {
        [JsonProperty(Order = 1)]
        public string processStatus { get; set; }

        [JsonProperty(Order = 2)]
        public string processMsg { get; set; }

        [JsonProperty(Order = 3)]
        public string policyId { get; set; }

        [JsonProperty(Order = 4)]
        public string quoteNo { get; set; }

        [JsonProperty(Order = 5)]
        public string policyNo { get; set; }

        [JsonProperty(Order = 6)]
        public string paymentRedirectURL { get; set; }

        [JsonProperty(Order = 7)]
        public List<string> subPolicyResults { get; set; }
    }



}
