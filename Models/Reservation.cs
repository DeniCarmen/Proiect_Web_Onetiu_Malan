using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_Web_Onetiu_Malan.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? DestinationID { get; set; }
        public Destination? Destination { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
