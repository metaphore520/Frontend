using Front_end.Models;

namespace Front_end.ApiModel
{
    public class PostCustomerApiModel
    {
        public PostCustomerApiModel()
        {
            this.Customer = new Customer();
            this.CustomerAddresses = new List<CustomerAddress>();
        }

        public Customer Customer { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }

    }
    public class PostCustomerApiModelNew
    {
        public PostCustomerApiModelNew()
        {
            this.Customer = new Customer();
            this.CustomerAddresses = "";
        }

        public Customer Customer { get; set; }

        public string CustomerAddresses { get; set; }

    }
}
