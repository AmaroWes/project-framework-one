using System.ComponentModel.DataAnnotations;

namespace Aluroni.Models
{
    public class Invoce
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public int DeliverymanId { get; set; }
        public Deliveryman Deliveryman { get; set; }

        [Required]
        public string Bill { get; set; }

        public double Amount { get; set; }
    }
}
