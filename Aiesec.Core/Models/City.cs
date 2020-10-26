namespace Aiesec.Database.Models
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Postcode { get; set; }
    }
}