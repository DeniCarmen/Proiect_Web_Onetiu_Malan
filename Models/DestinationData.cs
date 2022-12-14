namespace Proiect_Web_Onetiu_Malan.Models
{
    public class DestinationData
    {
        public IEnumerable<Destination> Destinations { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DestinationCategory> DestinationCategories { get; set; }
    }
}
