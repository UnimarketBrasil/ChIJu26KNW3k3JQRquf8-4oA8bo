using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Item
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double ValorUnitario { get; set; }

        public double Quantidade { get; set; }

        public double ValorTotal { get; set; }

        public string Imagem { get; set; }

        public Categoria Categoria { get; set; }

        public Usuario Comprador { get; set; }

        public Usuario Vendedor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Desabilitado { get; set; }

    }
}
