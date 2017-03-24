﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class SubUsuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Desabilitado { get; set; }
    }
}
