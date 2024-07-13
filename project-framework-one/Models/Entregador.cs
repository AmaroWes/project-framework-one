using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Entregador
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Nome { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "CPF invalido"), MaxLength(11, ErrorMessage = "CPF invalido")]
        public string Cpf { get; set; }
        [Required]
        [MinLength(9, ErrorMessage = "CNH invalido"), MaxLength(9, ErrorMessage = "CNH invalido")]
        public string Cnh { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Telefone invalido"), MaxLength(12, ErrorMessage = "Telefone invalido")]
        public string Telefone { get; set; }
        [Required]
        public float taxa { get; set; }
    }
}
