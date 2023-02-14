using Front_end.ApiModel;
using Front_end.Contracts;
using Front_end.Models;
using Newtonsoft.Json;

namespace Front_end.Services
{
    public class FetchDataService : IFetchDataService
    {
        private readonly IConfiguration _configuration;
        public FetchDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<GetPortalPageDataVM> GetPortalPageData()
        {
            HttpClient client = new HttpClient();
            string url = this._configuration["ApiRoot"] + "getAllCountry/";
            var listCountry = JsonConvert.DeserializeObject<List<Country>>(await client.GetStringAsync(url));
            string url2 = this._configuration["ApiRoot"] + "getAllCustomer/";
            GetCustomerApiModel model =
            JsonConvert.DeserializeObject<GetCustomerApiModel>(await client.GetStringAsync(url2));

            GetPortalPageDataVM pageData = new GetPortalPageDataVM();

            pageData.GetCustomerApiModel = model;
            pageData.listCountry = listCountry;
            return pageData;
        }






    }

    public class GetPortalPageDataVM
    {
        public List<Country> listCountry { get; set; }
        public GetCustomerApiModel GetCustomerApiModel { get; set; }
    }






}
