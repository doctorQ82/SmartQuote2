using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public sealed class ClsSetting
    {
        public string token { get; set; }

        public string GetTitle { get; set; }

        public string GetBrand { get; set; }

        public string GetModel { get; set; }

        public string CarYear { get; set; }

        public string SubModel { get; set; }

        public string VehicleCC { get; set; }

        public string VehicleSumInsure { get; set; }

        public string VehiclePolicyDetail { get; set; }

        public string PolicyPlan { get; set; }

        public string SendEmail { get; set; }

        public string Register { get; set; }

        public string ApiUser { get; set; }

        public string ApiPassword { get; set; }

        public string eBaoToken { get; set; }
        public string eBaoCreate { get; set; }
        public string eBaoApiUser { get; set; }
        public string eBaoApiPassword { get; set; }
        public string LinkPage { get; set; }
    }
}


