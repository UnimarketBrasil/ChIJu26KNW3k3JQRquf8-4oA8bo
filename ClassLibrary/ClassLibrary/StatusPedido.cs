using System;

namespace ClassLibrary
{
    public class StatusPedido
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public StatusPedido(int id)
        {
            Id = id;
        }
    }
}
