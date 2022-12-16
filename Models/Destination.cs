using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Destination
    {
        public int ID { get; set; }


        [Display(Name = "Destination Name")]
        public string? Title { get; set; }
       
        //public string Country { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }

        public int? CountryID { get; set; }
        public Country? Country { get; set; }

        //[Display(Name = "City")]
        public int? CityID { get; set; }
        public City? City { get; set; }
        [Display(Name = "Destination Categories")]
        public ICollection<DestinationCategory>? DestinationCategories { get; set; }
    }
}
