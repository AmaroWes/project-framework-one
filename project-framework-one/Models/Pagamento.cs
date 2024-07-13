using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}
