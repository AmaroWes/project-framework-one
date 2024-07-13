using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Nota
    {
        public int Id { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
    }
}
