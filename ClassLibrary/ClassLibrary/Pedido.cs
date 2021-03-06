﻿using System;
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

        public double Valor { get; set; }

        public StatusPedido StatusPedido { get; set; }

        public DateTime Data { get; set; }
    }

    public struct RelatorioPedido
    {
        public string Valor;
        public DateTime Data;

        public RelatorioPedido(string valor, DateTime data)
        {
            Valor = valor;
            Data = data;

        }

    }
}
