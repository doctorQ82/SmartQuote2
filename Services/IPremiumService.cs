using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartQuote.Data;
using SmartQuote.Models;

namespace SmartQuote.Services
{
    public interface IPremiumService
    {
        IEnumerable<TbTitle> TitleRead();

        IEnumerable<VwVehiclebrand> BrandRead();

        IEnumerable<VehicleModelViewModel> ModelRead(string data);

        IEnumerable<VehicleCarYearViewModel> CarYear(string data);

        IEnumerable<VehicleSubModelViewModel> SubModelRead(string data);

        IEnumerable<VehicleCarEngineViewModel> EngineCCRead(string data);

        IEnumerable<ViewPolicyPlanV2>  GetPolicyPlan(int runNo);

        IEnumerable<CarYearViewModel> CarRegisYear();

        WSResult GetToken();

        string SendEmailToCustomerService(int rnNo, string repairing);
        string CustomerRegister(Register data);

        WSResult GetApiToken();

        ResponseCreate QuotationCreate(QTCreate data);
    }
}
