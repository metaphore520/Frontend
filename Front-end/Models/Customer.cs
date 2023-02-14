namespace Front_end.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public byte[] CustomerPhoto { get; set; }
    }
    public class CustomerTemp
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
 
    }
}
