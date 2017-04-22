using System;

namespace ClassLibrary
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Senha { get; set; }

        public string CpfCnpj { get; set; }

        public DateTime Nascimento { get; set; }

        public int Genero { get; set; }

        public string Telefone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Complemento { get; set; }

        public double AreaAtuacao { get; set; }

        public TipoUsuario Tipousuario { get; set; }

        public StatusUsuario StatusUsuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public Usuario()
        {

        }
        public Usuario(int id)
        {
            this.Id = id;
        }

    }

}
