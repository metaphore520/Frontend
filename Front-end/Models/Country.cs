namespace Front_end.Models
{
    public class Country
    {
        public Country(string name,int id)
        {
            this.CountryName = name;
            this.Id = id;
        }
        public int Id { get; set; }
        public string CountryName { get; set; } = "";
    }



}
