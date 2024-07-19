using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Invalid name, too long")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public EnumUf UF { get; set; }

        [Required]
        public EnumPayment Payment { get; set; }

        public enum EnumUf : int
        {
            RS = 0,
            RJ = 1,
            SP = 2
        }

        public enum EnumPayment : int
        {
            Debito = 0,
            Credito = 1,
            Pix = 2
        }
    }
}
