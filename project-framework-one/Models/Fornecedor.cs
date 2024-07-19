using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string RazaoSocial { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string NomeFantasia { get; set; }
        [Required]
        [MinLength(14, ErrorMessage = "CNPJ invalido"), MaxLength(14, ErrorMessage = "Email invalido")]
        public string CNPJ { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Telefone invalido"), MaxLength(12, ErrorMessage = "Telefone invalido")]
        public string Telefone { get; set; }
        [EmailAddress]
        [Required]
        [MinLength(6, ErrorMessage = "Email invalido"), MaxLength(30, ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Cidade { get; set; }

        public EnumUF UF { get; set; }

        public enum EnumUF
        {
            RS,
            RJ,
        }
    }
}
