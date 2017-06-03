using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Senha { get; set; }

        public string HashConfirmacao { get; set; }

        public string CpfCnpj { get; set; }

        public int Genero { get; set; }

        public string Telefone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string CEP { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public double AreaAtuacao { get; set; }

        public List<MetodoPagamento> MetodoPagamento { get; set; }

        public TipoUsuario Tipousuario { get; set; }

        public StatusUsuario StatusUsuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public int QtdadeItens { get; set; }

        public int QtdPedidosPendente { get; set; }

        public int QtdPedidosFinanlizado { get; set; }

        public int QtdPedidosCancelado { get; set; }

        public DateTime UltimoAcesso { get; set; }

    }

}
