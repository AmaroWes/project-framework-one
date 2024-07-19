using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
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
        public float Price { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public void AddIngredient(string ingredient)
        {
            this.Ingredients += "," + ingredient;
        }

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
