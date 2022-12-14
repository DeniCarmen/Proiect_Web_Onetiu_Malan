using System.Security.Policy;

namespace Proiect_Web_Onetiu_Malan.Models.ViewModels
{
    public class CityIndexData
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
    }
}
