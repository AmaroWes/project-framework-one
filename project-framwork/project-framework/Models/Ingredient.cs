using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [Required]
        public EnumType Type { get; set; }

        public enum EnumType
        {
            Verdura,
            Legume,
            Fruta,
            Carne
        }
    }
}
