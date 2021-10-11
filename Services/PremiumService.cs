using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartQuote.Data;
using SmartQuote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace SmartQuote.Services
{
    public class PremiumService : BaseService, IPremiumService
    {

        #region "declare variable"
        public string _token { get; set; }

        public string _title { get; set; }

        public string _Brand { get; set; }

        public string _Model { get; set; }

        public string _CarYear { get; set; }

        public string _SubModel { get; set; }

        public string _VehicleCC { get; set; }

        public string _VehicleSumInsure { get; set; }

        public string _VehiclePolicyDetail { get; set; }

        public string _PolicyPlan { get; set; }

        public string _SendEmail { get; set; }
        
        public string _Register { get; set; }

        public string ApiUser { get; set; }

        public string ApiPassword { get; set; }
        public string _eBaoToken { get; set; }
        public string _eBaoCreate { get; set; }
        public string _eBaoApiUser { get; set; }
        public string _eBaoApiPassword { get; set; }

        public string LinkPage { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        public PremiumService(IConfiguration _config, ILogger logger, IHttpContextAccessor httpContextAccessor)
        {
            var section = _config.GetSection("settings").Get<ClsSetting>();
            this._token = section.token.ToString();
            this._title = section.GetTitle.ToString();
            this._Brand = section.GetBrand.ToString();
            this._Model = section.GetModel.ToString();

            this._CarYear = section.CarYear.ToString();
            this._SubModel = section.SubModel.ToString();
            this._VehicleCC = section.VehicleCC.ToString();

            this._VehicleSumInsure = section.VehicleSumInsure.ToString();
            this._VehiclePolicyDetail = section.VehiclePolicyDetail.ToString();
            this._Register = section.Register.ToString();

            this._PolicyPlan = section.PolicyPlan.ToString();
            this._SendEmail = section.SendEmail.ToString();

            this.ApiUser = section.ApiUser.ToString();
            this.ApiPassword = section.ApiPassword.ToString();

            this._eBaoToken = section.eBaoToken.ToString();
            this._eBaoCreate = section.eBaoCreate.ToString();
            this._eBaoApiUser = section.eBaoApiUser.ToString();
            this._eBaoApiPassword = section.eBaoApiPassword.ToString();
            this.LinkPage = section.LinkPage.ToString();

            this._httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<VwVehiclebrand> BrandRead()
        {
            WSResult result = GetToken();
            string token = string.Empty;
            if (result.StatusCode == "200")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(30);
                token = result.Token;
                _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", token, options);
            }

            List<VwVehiclebrand> Brands = new List<VwVehiclebrand>();
            var client = new RestClient(this._Brand);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<Vehiclebrand>>(response.Content.ToString());

                foreach (var item in resp)
                {
                    VwVehiclebrand t = new VwVehiclebrand();
                    t.Make = item.brand;
                    Brands.Add(t);
                }

            }

            return Brands;
        }

        public IEnumerable<CarYearViewModel> CarRegisYear()
        {
            List<CarYearViewModel> CarYear = new List<CarYearViewModel>();

            string sYear = DateTime.Now.ToString("yyyy", new CultureInfo("en-US"));
            int StartYear = int.Parse(sYear);
            StartYear = StartYear - 14;

            int EndYear = int.Parse(sYear);

            for (int i = EndYear; i >= StartYear; i--)
            {
                CarYearViewModel car = new CarYearViewModel();
                car.CarYearRegis = i;
                CarYear.Add(car);
            }

            return CarYear;
        }

        public IEnumerable<VehicleModelViewModel> ModelRead(string data)
        {

            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            string url = this._Model + String.Format("?brand={0}", data.ToString());

            List<VehicleModelViewModel> Models = new List<VehicleModelViewModel>();
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<VehicleModelViewModel>>(response.Content.ToString());

                foreach (var item in resp)
                {
                    VehicleModelViewModel t = new VehicleModelViewModel();
                    t.ModelCode = item.ModelCode;
                    t.ModelDesc = item.ModelDesc.ToString();
                    Models.Add(t);
                }

            }


            return Models;
        }

        public IEnumerable<VehicleSubModelViewModel> SubModelRead(string data)
        {
            var entities = new List<VehicleSubModelViewModel>();           
            string[] slData = data.Split("|");

            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            ViewCarSubModel param = new ViewCarSubModel();
            param.brand = slData[0].ToString();
            param.model = slData[1].ToString();
            //param.year = Convert.ToInt32(slData[2]);

            string postText = JsonConvert.SerializeObject(param);

            List<VehicleSubModelViewModel> subModel = new List<VehicleSubModelViewModel>();
            var client = new RestClient(this._SubModel);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<VehicleSubModelViewModel>>(response.Content.ToString());

                foreach (var item in resp)
                {
                    VehicleSubModelViewModel t = new VehicleSubModelViewModel();
                    t.SubModel = item.SubModel;
                    t.SubModelDesc = item.SubModelDesc.ToString();
                    subModel.Add(t);
                }

            }

            return subModel;
        }

        public IEnumerable<TbTitle> TitleRead()
        {

            WSResult result = GetToken();
            string token = result.Token;

            List<TbTitle> titles = new List<TbTitle>();
            var client = new RestClient(this._title);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<Titles>>(response.Content.ToString());

                foreach(var item in resp)
                {
                    TbTitle t = new TbTitle();
                    t.TitleCode = item.titleCode;
                    t.TitleDesc = item.titleDesc.ToString();
                    titles.Add(t);
                }

            }

            return titles;
        }

        public WSResult GetToken()
        {
            WSResult result = new WSResult();
            string _token = string.Empty;

            var client = new RestClient(this._token);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            Logon log = new Logon();
            log.Username = this.ApiUser.ToString();
            log.Password = this.ApiPassword.ToString();

            string postText = JsonConvert.SerializeObject(log);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<WSResult>(response.Content.ToString());

            }

            return result;
        }

        public IEnumerable<VehicleCarYearViewModel> CarYear(string data)
        {
            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            string[] slData = data.Split("|");

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            ViewCarYearModel param = new ViewCarYearModel();
            param.brand = slData[0].ToString();
            param.model = slData[1].ToString();
            string postText = JsonConvert.SerializeObject(param);

            List<VehicleCarYearViewModel> carYear = new List<VehicleCarYearViewModel>();
            var client = new RestClient(this._CarYear);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", postText, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<VehicleCarYearViewModel>>(response.Content.ToString());

                foreach (var item in resp)
                {
                    VehicleCarYearViewModel t = new VehicleCarYearViewModel();
                    t.yearCode = item.yearCode;
                    t.year = item.year.ToString();
                    carYear.Add(t);
                }

            }

            return carYear;
        }

        public IEnumerable<VehicleCarEngineViewModel> EngineCCRead(string data)
        {

            var entities = new List<VehicleSubModelViewModel>();
            string[] slData = data.Split("|");

            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            ViewEngineCCModel param = new ViewEngineCCModel();
            param.brand = slData[0].ToString();
            param.model = slData[1].ToString();
            param.year = Convert.ToInt32(slData[2]);
            param.subModel = slData[3].ToString();

            string postText = JsonConvert.SerializeObject(param);

            List<VehicleCarEngineViewModel> engineCC = new List<VehicleCarEngineViewModel>();
            var client = new RestClient(this._VehicleCC);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resp =
     JsonConvert.DeserializeObject<List<VehicleCarEngineViewModel>>(response.Content.ToString());

                foreach (var item in resp)
                {
                    VehicleCarEngineViewModel t = new VehicleCarEngineViewModel();
                    t.CCCode = item.CCCode;
                    t.CC = item.CC.ToString();
                    engineCC.Add(t);
                }

            }

            return engineCC;
        }

        public string CustomerRegister(Register data)
        {
            string strResult = string.Empty;

            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            string postText = JsonConvert.SerializeObject(data);
            var client = new RestClient(this._Register);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                strResult =
     JsonConvert.DeserializeObject<string>(response.Content.ToString());

            }

            return strResult;
        }

        public IEnumerable<ViewPolicyPlanV2> GetPolicyPlan(int runNo)
        {

            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            string url = this._PolicyPlan + String.Format("?RunNo={0}", runNo);

            List<ViewPolicyPlanV2> plan = new List<ViewPolicyPlanV2>();
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                plan =JsonConvert.DeserializeObject<List<ViewPolicyPlanV2>>(response.Content.ToString());
            }

            return plan;
        }

        public string SendEmailToCustomerService(int rnNo, string repairing)
        {
            string _result = string.Empty;
            string token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];

            if (String.IsNullOrEmpty(token))
            {
                WSResult result = GetToken();

                if (result.StatusCode == "200")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(30);
                    string Token = result.Token;
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("_smartkey", Token, options);
                }

                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }
            else
            {
                token = _httpContextAccessor.HttpContext.Request.Cookies["_smartkey"];
            }

            string url = this._SendEmail + String.Format("?RunNo={0}&RepairType={1}", rnNo, repairing);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            string apikey = String.Format("Bearer {0}", token);
            request.AddHeader("Authorization", apikey);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                _result = response.Content.ToString();
            }

            return _result;
        }

        public WSResult GetApiToken()
        {
            WSResult result = new WSResult();
            string _token = string.Empty;

            var client = new RestClient(this._eBaoToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            Logon log = new Logon();
            log.Username = this._eBaoApiUser.ToString();
            log.Password = this._eBaoApiPassword.ToString();

            string postText = JsonConvert.SerializeObject(log);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<WSResult>(response.Content.ToString());

            }

            return result;
        }

        public ResponseCreate QuotationCreate(QTCreate data)
        {
            ResponseCreate result = new ResponseCreate();
            WSResult _token = GetApiToken();

            QTCreate qt = new QTCreate();
            qt.rnNo = data.rnNo;
            qt.ReapirType = data.ReapirType.ToString();

            string postText = JsonConvert.SerializeObject(qt);

            var client = new RestClient(this._eBaoCreate);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            string _authen = String.Format("Bearer {0}", _token.Token);
            request.AddHeader("Authorization", _authen);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<ResponseCreate>(response.Content.ToString());
            }

            return result;
        }
    }
}
