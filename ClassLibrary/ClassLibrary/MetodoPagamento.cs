﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MetodoPagamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public TipoMetodosPagamento tMetodoPgto { get; set; }

        public bool Desabilitado { get; set; }
    }
}
