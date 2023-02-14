namespace Front_end.Models
{
    public class CustomerAddress
    {

        public CustomerAddress()
        {
            this.Address = "newss";
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
    }
}
