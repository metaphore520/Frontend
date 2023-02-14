using Front_end.Models;

namespace Front_end.Models
{
    public class GetCustomerByIdApiModel
    {
        public Customer Customer { get; set; }
        public List<CustomerAddress> Addresses { get; set; }
    }
}
