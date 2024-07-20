using System.ComponentModel.DataAnnotations;

namespace Aluroni.Models
{
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
