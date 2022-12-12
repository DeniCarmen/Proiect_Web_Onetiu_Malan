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
        public string Title { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        public int? CityID { get; set; }
        public City? City { get; set; }
    }
}
