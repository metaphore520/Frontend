using Front_end.Models;

namespace Front_end.ApiModel
{
    public class GetCustomerApiModel
    {
        public List<CustomerModel> Customers { get; set; }

    }

    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

    }
}
