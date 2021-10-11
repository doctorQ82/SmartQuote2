using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class VehicleModelViewModel
    {
        public string ModelCode { get; set; }

        public string ModelDesc { get; set; }
    }

    public class VehicleSubModelViewModel
    {
        public string SubModel { get; set; }

        public string SubModelDesc { get; set; }
    }


    public class VehicleCarYearViewModel
    {
        public string yearCode { get; set; }

        public string year { get; set; }
    }


    public class VehicleCarEngineViewModel
    {
        public string CCCode { get; set; }

        public string CC { get; set; }
    }


}
