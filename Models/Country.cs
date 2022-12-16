using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Country
    {
        public int ID {get; set; }

        [Display(Name = "Country Name")]
        public string? Name { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
        
    
    }
}
