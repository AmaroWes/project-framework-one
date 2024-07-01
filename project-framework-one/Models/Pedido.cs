namespace project_framework_one.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Prato Prato { get; set; }
        public Entregador Entregador { get; set; }
    }
}
