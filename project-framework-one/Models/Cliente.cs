using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Nome { get; set; }
        [EmailAddress]
        [Required]
        [MinLength(6, ErrorMessage = "Email invalido"), MaxLength(30, ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Telefone invalido"), MaxLength(12, ErrorMessage = "Telefone invalido")]
        public string Telefone { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Endereço invalido"), MaxLength(35, ErrorMessage = "Endereço invalido")]
        public string Endereco { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Bairro" +
            " invalido"), MaxLength(35, ErrorMessage = "Bairro invalido")]
        public string Bairro { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Cep invalido"), MaxLength(35, ErrorMessage = "CEP invalido")]
        public string CEP { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Cidade invalido"), MaxLength(35, ErrorMessage = "Cidade invalido")]
        public string Cidade { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "UF invalido"), MaxLength(35, ErrorMessage = "UF invalido")]
        public string UF { get; set; }
        [Required]
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
