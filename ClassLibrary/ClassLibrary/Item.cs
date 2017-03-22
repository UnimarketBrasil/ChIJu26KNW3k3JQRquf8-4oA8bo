using System;

namespace ClassLibrary
{
    public class Item
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double ValorUnitario { get; set; }

        public string Quantidade { get; set; }

        public Categoria Categoria { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Desabilitado { get; set; }
    }
}
