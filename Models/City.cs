using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web_Onetiu_Malan.Models
{
    public class City
    {
        public int ID { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
