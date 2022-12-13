namespace Proiect_Web_Onetiu_Malan.Models
{
    public class DestinationCategory
    {
        public int ID { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
