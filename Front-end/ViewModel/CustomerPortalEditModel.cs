using Front_end.Models;

namespace Front_end.ViewModel
{
    public class CustomerPortalEditModel
    {
        public CustomerPortalEditModel()
        {
            this.CustomerName = "";
            this.FatherName = "";
            this.MotherName = "";
        }
        // Customer Data

        public bool FileUploaded { get; set; }
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public IFormFile CustomerPhoto { get; set; }
        public byte[] CustomerPhotoByte { get; set; }
        public string AllAddress { get; set; }
    }
    public class AddressesEditModel
    {
        public List<CustomerAddress> alladdress { get; set; }
    }
}
