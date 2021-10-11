using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartQuote.Data;
using SmartQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartQuote.Models;
using System.Globalization;

namespace SmartQuote.Controllers
{
    public class PlanController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlanController(IConfiguration configuration, ILogger<PlanController> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._config = configuration;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;

        }


        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Read_Title()
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.TitleRead());
        }

        public JsonResult Read_Brand()
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.BrandRead());
        }

        public JsonResult Read_Model(string Brands)
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.ModelRead(Brands));
        }

        //public JsonResult Read_CarYear(string Models)
        //{
        //    PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
        //    return Json(serv.CarYear(Models));
        //}

        public JsonResult Read_SubModel(string Models)
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.SubModelRead(Models));
        }

        public JsonResult Read_EngineCC(string SubModels)
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.EngineCCRead(SubModels));
        }

        public JsonResult Read_CarRegisYear()
        {
            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            return Json(serv.CarRegisYear());
        }

        public ActionResult Inquiry()
        {
            Register reg = new Register();
            reg.Title = Request.Form["Title"];
            reg.FirstName = Request.Form["firstName"];
            reg.LastName = Request.Form["lastname"];
            reg.Telephone = Request.Form["phone_number"];
            reg.email = Request.Form["email"];

            string SubModels = Request.Form["SubModels"];
            string[] slVehicle = SubModels.Split("|");

            reg.Vehicle_Brand = slVehicle[0].ToString();
            reg.Vehicle_Model = slVehicle[1].ToString();
            reg.Vehicle_Year = Convert.ToInt32(slVehicle[2].ToString());
            reg.Vehicle_SubModel = slVehicle[3].ToString();
            reg.Vehicle_CC = Convert.ToInt32(slVehicle[4].ToString());
            //reg.VehicleKey = slVehicle[5].ToString();

            string CarYear = Request.Form["CarYear"];
            reg.CarRegis_Year = Convert.ToInt32(CarYear);

            string PolicyExpire = Request.Form["PolicyExpire"];

            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                                                                 "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy","dd/M/yyyy"};

            DateTime d;
            string strExpire = string.Empty;

            if (DateTime.TryParseExact(PolicyExpire, formats, new CultureInfo("en-US"),
                DateTimeStyles.None, out d))
            {
                strExpire = d.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            }

            reg.Policy_Expiry = strExpire.ToString();

            string UseCarKM = Request.Form["UseCarKM"];
            reg.UseDistance = Convert.ToInt32(UseCarKM);

            string fciCustomer = Request.Form["fciCustomer"];
            string fciConsent = Request.Form["fciConsent"];

            //string condition = Request.Form["condition"];

            fciCustomer = fciCustomer == "on"? "true": "false";
            fciConsent = fciConsent == "on" ? "true" : "false";

            if (Convert.ToBoolean(fciCustomer))
            {
                reg.IsFCI = true;
            }
            else {
                reg.IsFCI = false;
            }

            if (Convert.ToBoolean(fciConsent))
            {
                reg.IsConsent = true;
            }
            else {
                reg.IsConsent = false;
            }

            PremiumService serv = new PremiumService(_config, _logger, this._httpContextAccessor);
            
            string result = serv.CustomerRegister(reg);

            string[] slResult = result.Split("|");

            if (slResult[0].ToString() == "Success")
            {
                string strId = slResult[1].ToString().PadLeft(8, '0');
                string encryt = Crypto.EncryptMd5(strId);

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(30); 
                _httpContextAccessor.HttpContext.Response.Cookies.Append("_smtencrypt", encryt, options);

                return RedirectToAction("list", "Product");
            }
            else {
                return RedirectToAction("Index", "Plan");
            }
           
      
        }
       }
    }
