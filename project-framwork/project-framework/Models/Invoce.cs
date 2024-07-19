using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Invoce
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required] 
        public int DeliverymanId { get;}
        public Deliveryman Deliveryman { get; set; }

        public float Amount { get; set; }
    }
}
