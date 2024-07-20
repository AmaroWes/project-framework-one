using System.ComponentModel.DataAnnotations;

namespace Aluroni.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Invalid legal name, too long")]
        public string LegalName { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage = "Invalid trade name, too long")]
        public string TradeName { get; set; }

        [Required]
        [MinLength(14, ErrorMessage = "Invalid CNPJ, too shot"), MaxLength(14, ErrorMessage = "Invalid CNPJ, too long")]
        public string CNPJ { get; set; }

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

        public enum EnumUf
        {
            RS,
            RJ,
            SP
        }
    }
}
