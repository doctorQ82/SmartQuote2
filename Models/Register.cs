using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class Register
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string email { get; set; }
        public string Vehicle_Brand { get; set; }
        public string Vehicle_Model { get; set; }
        public int Vehicle_Year { get; set; }
        public string Vehicle_SubModel { get; set; }
        public int Vehicle_CC { get; set; }
        public int CarRegis_Year { get; set; }
        public string Policy_Expiry { get; set; }
        public int UseDistance { get; set; }

        public string VehicleKey { get; set; }
        
        public bool IsFCI { get; set; }
        public bool IsConsent { get; set; }
    }
}
