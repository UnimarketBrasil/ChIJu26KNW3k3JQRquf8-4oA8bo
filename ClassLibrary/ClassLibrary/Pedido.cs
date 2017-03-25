using System.Collections.Generic;

namespace ClassLibrary
{
    public class Pedido
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public Usuario Comprador { get; set; }

        public Usuario Vendedor { get; set; }

        public List<Item> Item { get; set; }

        public StatusPedido StatusPedido { get; set; }
    }
}
