using Front_end.ApiModel;
using Front_end.Contracts;
using Front_end.Models;
using Front_end.Services;
using Front_end.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class CustomerPortalController : Controller
    {
        private readonly IConfiguration _configuration;
        IFetchDataService _dataService;
        HttpClient client = new HttpClient();

        public CustomerPortalController(IConfiguration configuration,IFetchDataService dataService)
        {
            this._configuration = configuration;
            this._dataService = dataService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerPortal()
        {
            GetPortalPageDataVM pagedata = await this._dataService.GetPortalPageData();
            ViewBag.CustomerList = pagedata.GetCustomerApiModel.Customers;
            ViewBag.Countries = pagedata.listCountry;
            return View();
        }
        [HttpPost]
        public async Task AddCustomer(CustomerPortalViewModel dataBodyJson)
        {
            string ApiRoot = this._configuration["ApiRoot"];
            PostCustomerApiModel posted_customer = new PostCustomerApiModel();
            PostCustomerApiModelNew posted_customerNew = new PostCustomerApiModelNew();
            HelperService.MapCustomerPortalViewModel(dataBodyJson, posted_customer);

            posted_customerNew.CustomerAddresses = JsonConvert.SerializeObject(posted_customer.CustomerAddresses);
            posted_customerNew.Customer = posted_customer.Customer;
            var serializedTodo = JsonConvert.SerializeObject(posted_customerNew);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");
            string url1 = ApiRoot + "addCustomer/";
            var response = client.PostAsync(url1, requestContent);
            response.Wait();
        }
        [HttpPost]
        public async Task EditCustomer(CustomerPortalEditModel dataBodyJson)
        {
            string ApiRoot = this._configuration["ApiRoot"];
            PostCustomerApiModel posted_customer = new PostCustomerApiModel();
            PostCustomerApiModelNew posted_customerNew = new PostCustomerApiModelNew();
            HelperService.MapCustomerPortalEditModel(dataBodyJson, posted_customer);
            posted_customerNew.CustomerAddresses = JsonConvert.SerializeObject(posted_customer.CustomerAddresses);
            posted_customerNew.Customer = posted_customer.Customer;
            var serializedTodo = JsonConvert.SerializeObject(posted_customerNew);
            var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");
            string url1 = ApiRoot + "editCustomer/";
            var response = client.PostAsync(url1, requestContent);
        }
        [HttpGet]
        public async Task<GetCustomerByIdApiModel> GetCustomerById(int id)
        {
            GetDataApiModel postData = new GetDataApiModel(id);
            string url2 = this._configuration["ApiRoot"] + $"getCustomerById?id={id}";
            GetCustomerByIdApiModel model =
                       JsonConvert.DeserializeObject<GetCustomerByIdApiModel>(await client.GetStringAsync(url2));

            return model;
        }
        [HttpGet]
        public async Task DeleteCustomerById(int id)
        {
            string url2 = this._configuration["ApiRoot"] + $"deleteCustomerById?id={id}";
            await client.GetStringAsync(url2);
        }   
        [HttpPost]
        public async Task PostPdf2(CustomerPortalViewModel dataBodyJson)
        {
            try
            {
                //var customer = new CustomerTemp();

                //var httpClient = new HttpClient();
                //customer.CountryId = 9;
                //customer.CustomerName = "sss";
                //customer.FatherName = "aaaaaa";
                //customer.MotherName = "asaw";
                //customer.MaritalStatus = 3;
                //customer.Id = 1;
                //var serializedTodo = JsonConvert.SerializeObject(customer);
                //string url = "https://localhost:7252/customer/addCustomer2";
                //var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");
                //await httpClient.PostAsync(url, requestContent);
                //}
                string ApiRoot = this._configuration["ApiRoot"];
                PostCustomerApiModel posted_customer = new PostCustomerApiModel();
                PostCustomerApiModelNew posted_customerNew = new PostCustomerApiModelNew();
                HelperService.MapCustomerPortalViewModel(dataBodyJson, posted_customer);
                posted_customerNew.CustomerAddresses = JsonConvert.SerializeObject(posted_customer.CustomerAddresses);
                posted_customerNew.Customer = posted_customer.Customer;
                var serializedTodo = JsonConvert.SerializeObject(posted_customerNew);
                var requestContent = new StringContent(serializedTodo, Encoding.UTF8, "application/json");
                string url1 = ApiRoot + "addCustomer/";
                var response = client.PostAsync(url1, requestContent);
                response.Wait();
                Console.WriteLine(response.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}




