using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Nome { get; set; }
        [Required]
        public int Qtde { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Tipo { get; set; }
    }
}
