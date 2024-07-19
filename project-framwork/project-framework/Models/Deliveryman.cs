using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Deliveryman
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Invalid name, too long")]
        public string Name { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Invalid CPF, too shot"), MaxLength(11, ErrorMessage = "Invalid CPF, too long")]
        public string CPF { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Invalid CNH, too shot"), MaxLength(9, ErrorMessage = "Invalid CNH, too long")]
        public string CNH { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public float PaymentRate { get; set; }

    }
}
