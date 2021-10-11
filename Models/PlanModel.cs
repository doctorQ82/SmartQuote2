using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class PlanModel
    {
        public string RunNo { get; set; }
        public string RepairType { get; set; }

        public string totalPremium1 { get; set; }
        public string totalPremium2 { get; set; }
      
        public string UseDistance { get; set; }

        public string premium_Percent { get; set; }

        public string totalPremium3 { get; set; }

        public string SumInsured { get; set; }

        public string TPBI_Person { get; set; }

        public string TPBI_Accident { get; set; }

        public string TPPD_Accident { get; set; }

        public string ShowTool1 { get; set; }

        public string ShowTool2 { get; set; }

        public string ImagePath { get; set; }

    }
}
