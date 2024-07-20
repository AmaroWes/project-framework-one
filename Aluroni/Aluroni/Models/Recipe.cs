using System.ComponentModel.DataAnnotations;

namespace Aluroni.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
