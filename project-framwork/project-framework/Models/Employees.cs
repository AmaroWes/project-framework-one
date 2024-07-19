using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string password { get; set; }
    }
}
