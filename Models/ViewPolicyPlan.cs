using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{

    public class ViewPolicyPlan
    {

        [JsonProperty("Brand", Order = 1)]
        public string Brand { get; set; }

        [JsonProperty("Model", Order = 2)]
        public string Model { get; set; }

        [JsonProperty("Year", Order = 3)]
        public int Year { get; set; }

        [JsonProperty("SubModel", Order = 4)]
        public string SubModel { get; set; }

        [JsonProperty("CC", Order = 5)]
        public string CC { get; set; }

        [JsonProperty("Reparing", Order = 6)]
        public string Reparing { get; set; }

        [JsonProperty("SumInsure", Order = 7)]
        public decimal SumInsure { get; set; }

        [JsonProperty("FirstPremium", Order = 8)]
        public decimal FirstPremium { get; set; }

        [JsonProperty("Premium_Percent", Order = 9)]

        public decimal Premium_Percent { get; set; }

        [JsonProperty("TPBI_PERSON", Order = 10)]
        public decimal TPBI_PERSON { get; set; }

        [JsonProperty("TPBI_ACCIDENT", Order = 11)]
        public decimal TPBI_ACCIDENT { get; set; }

        [JsonProperty("TPPD_Accident", Order = 12)]
        public decimal TPPD_Accident { get; set; }

        [JsonProperty("UseDistance", Order = 13)]
        public int UseDistance { get; set; }

        [JsonProperty("NetPremium", Order = 14)]
        public decimal NetPremium { get; set; }

        [JsonProperty("CarYear", Order = 19)]
        public int CarYear { get; set; }

        [JsonProperty("rnNo", Order = 20)]
        public int rnNo { get; set; }

    }

    public class ViewPolicyPlanV2
    {
        [JsonProperty("Brand", Order = 1)]
        public string Brand { get; set; }

        [JsonProperty("Model", Order = 2)]
        public string Model { get; set; }

        [JsonProperty("Year", Order = 3)]
        public int Year { get; set; }

        [JsonProperty("SubModel", Order = 4)]
        public string SubModel { get; set; }

        [JsonProperty("CC", Order = 5)]
        public string CC { get; set; }

        [JsonProperty("Reparing", Order = 6)]
        public string Reparing { get; set; }

        [JsonProperty("SumInsure", Order = 7)]
        public decimal SumInsure { get; set; }

        [JsonProperty("FirstPremium", Order = 8)]
        public decimal FirstPremium { get; set; }

        [JsonProperty("Duty", Order = 9)]
        public decimal Duty { get; set; }

        [JsonProperty("Vat", Order = 10)]
        public decimal Vat { get; set; }

        [JsonProperty("TotalPremium", Order = 11)]
        public decimal TotalPremium { get; set; }

        [JsonProperty("Premium_Percent", Order = 12)]
        public decimal Premium_Percent { get; set; }

        [JsonProperty("TPBI_PERSON", Order = 13)]
        public decimal TPBI_PERSON { get; set; }

        [JsonProperty("TPBI_ACCIDENT", Order = 14)]
        public decimal TPBI_ACCIDENT { get; set; }

        [JsonProperty("TPPD_Accident", Order = 15)]
        public decimal TPPD_Accident { get; set; }

        [JsonProperty("rnNo", Order = 16)]
        public Int32 rnNo { get; set; }

        [JsonProperty("UseDistance", Order = 17)]
        public int UseDistance { get; set; }

        [JsonProperty("NetPremiumPeriod", Order = 18)]
        public decimal NetPremiumPeriod { get; set; }

        [JsonProperty("DutyPeriod", Order = 19)]
        public decimal DutyPeriod { get; set; }

        [JsonProperty("VatPeriod", Order = 20)]
        public decimal VatPeriod { get; set; }

        [JsonProperty("TotalPremiumPeriod", Order = 21)]
        public decimal TotalPremiumPeriod { get; set; }

        [JsonProperty("NetPremiumYear", Order = 22)]
        public decimal NetPremiumYear { get; set; }

        [JsonProperty("DutyYear", Order = 23)]
        public decimal DutyYear { get; set; }

        [JsonProperty("VatYear", Order = 24)]
        public decimal VatYear { get; set; }

        [JsonProperty("TotalPremiumYear", Order = 25)]
        public decimal TotalPremiumYear { get; set; }

        [JsonProperty("CarYear", Order = 26)]
        public int CarYear { get; set; }
    }
}

