namespace Proiect_Web_Onetiu_Malan.Models
{
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
