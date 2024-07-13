using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Prato
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Nome { get; set; }
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Categoria { get; set; }
        [Required]
        public int Qtde { get; set; }
        [Required]
        public int Peso { get; set; }
        [Required]
        public float Preco { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
