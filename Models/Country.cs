namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Country
    {
        public int ID {get; set; }

        public string? Name { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
        
    
    }
}
