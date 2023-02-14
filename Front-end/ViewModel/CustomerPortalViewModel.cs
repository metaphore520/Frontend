using Front_end.Models;

namespace Front_end.ViewModel
{
    public class CustomerPortalViewModel
    {
        public CustomerPortalViewModel()
        {
            this.CustomerName = "";
            this.FatherName = "";
            this.MotherName = "";
        }
        // Customer Data
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public IFormFile CustomerPhoto { get; set; }
        public string AllAddress { get; set; }
    }
    public class Addresses
    {
        public Addresses()
        {
            //this.alladdress = new List<CustomerAddress>();
        }
        public List<CustomerAddress> alladdress { get; set; }
    }
}
