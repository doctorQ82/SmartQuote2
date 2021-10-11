using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartQuote.Models;
using SmartQuote.Services;

namespace SmartQuote.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string _eBaoToken { get; set; }
        public string _eBaoCreate { get; set; }
        public string _eBaoApiUser { get; set; }
        public string _eBaoApiPassword { get; set; }
        public string LinkPage { get; set; }
        public ProductController(IConfiguration configuration, ILogger<ProductController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;

            var section = _config.GetSection("settings").Get<ClsSetting>();
            this.LinkPage = section.LinkPage.ToString();
            this._httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult Search(string rnNo)
        {
            string _runNo = EncodingForBase64.Base64Decode(rnNo);
            string strValue = _runNo.ToString();
            string[] slValue = strValue.ToString().Split("|");

            string RepairType = string.Empty;
            RepairType = slValue[1].ToString();
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            serv.SendEmailToCustomerService(Convert.ToInt32(slValue[0]), RepairType);

            Task.Delay(5000).Wait();
            return RedirectToAction("list", "Product");
        }



        public IActionResult QuotationCreate(string Id)
        {
            string _runNo = EncodingForBase64.Base64Decode(Id);
            string strValue = _runNo.ToString();
            string[] slValue = strValue.ToString().Split("|");

            string RepairType = string.Empty;
            RepairType = slValue[1].ToString();

            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);

            QTCreate data = new QTCreate();
            data.rnNo = Convert.ToInt32(slValue[0]);
            data.ReapirType = RepairType.ToString();

            ResponseCreate response = serv.QuotationCreate(data);

            if (response.success == true)
            {
                string policyId = response.data.policyId;
                string url = this.LinkPage + policyId;
                return Redirect(url);
            }
            else
            {
                return RedirectToAction("list", "Product");
            }
        }

        public IActionResult list()
        {
            Array array;
            string _smartkey = _httpContextAccessor.HttpContext.Request.Cookies["_smtencrypt"];
            string decryt = Crypto.DecryptMd5(_smartkey);
            int RunNo = Convert.ToInt32(decryt);

            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            IEnumerable<ViewPolicyPlanV2> plans = serv.GetPolicyPlan(RunNo);

            List<PlanModel> planModel = new List<PlanModel>();

            int iCount = 1;
            foreach (var item in plans)
            {
                string RepairType = item.Reparing;

                PlanModel plan = new PlanModel();
                string sType = RepairType.ToString();
                if (RepairType.ToString() == "Dealer")
                {
                    RepairType = "ซ่อมศูนย์/อู่";
                    plan.ImagePath = "~/Image/dealer.png";

                }
                else if (RepairType.ToString() == "Garage")
                {
                    RepairType = "ซ่อมอู่ทั่วไป";
                    plan.ImagePath = "~/Image/garage.png";
                }


                string keys = RunNo.ToString() + "|" + item.Reparing.ToString();
                string _runNo = EncodingForBase64.Base64Encode(keys);

                plan.RunNo = _runNo;
                plan.RepairType = RepairType.ToString();
                plan.premium_Percent = string.Format("{0:#,0.00}", item.Premium_Percent);
                plan.totalPremium1 = string.Format("{0:#,0.00}", item.TotalPremium);
                plan.totalPremium2 = string.Format("{0:#,0.00}", item.TotalPremiumPeriod);
                plan.UseDistance = string.Format("{0:#,0}", item.UseDistance);
                plan.totalPremium3 = string.Format("{0:#,0.00}", item.TotalPremiumYear);
                plan.SumInsured = string.Format("{0:#,0.00}", item.SumInsure);
                plan.TPBI_Person = string.Format("{0:#,0}", item.TPBI_PERSON);
                plan.TPBI_Accident = string.Format("{0:#,0}", item.TPBI_ACCIDENT);
                plan.TPPD_Accident = string.Format("{0:#,0}", item.TPPD_Accident);

                plan.ShowTool1 = "autohide1" + iCount.ToString();
                plan.ShowTool2 = "autohide2" + iCount.ToString();

                planModel.Add(plan);
                iCount++;
            }

            array = planModel.ToArray();
            ViewBag.Plans = array;
            return View();
        }

    }
}
