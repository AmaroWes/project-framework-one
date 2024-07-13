using System.ComponentModel.DataAnnotations;

namespace project_framework_one.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public int PratoId { get; set; }
        public Prato Prato { get; set; }
        [Required]
        public int EntregadorId { get; set; }
        public Entregador Entregador { get; set; }
    }
}
