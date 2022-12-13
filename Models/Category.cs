namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<DestinationCategory>? DestinationCategories { get; set; }
    }
}
