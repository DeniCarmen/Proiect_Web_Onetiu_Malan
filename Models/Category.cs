using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category Type")]
        public string CategoryName { get; set; }
        public ICollection<DestinationCategory>? DestinationCategories { get; set; }
    }
}
