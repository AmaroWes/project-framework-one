using System.ComponentModel.DataAnnotations;

namespace Aluroni.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public EnumCategory Category { get; set; }

        [Required]
        public int Serving { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public double Price { get; set; }

        public enum EnumCategory
        {
            Massa,
            Salada,
            Sopa,
            Carne,
            Outros
        }
    }
}
