using System;

using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Usuario : Conexao
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

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public string Complemento { get; set; }

        public double AreaAtuacao { get; set; }

        public TipoUsuario Tipousuario { get; set; }

        public StatusUsuario StatusUsuario { get; set; }

        public DateTime DateCadastro { get; set; }

        //Insert Usuario
        public void CadastrarUsuario(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CadastrarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Sobrenome", user.Sobrenome);
                    Cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    Cmd.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    Cmd.Parameters.AddWithValue("@Nascimentp", user.Nascimento);
                    Cmd.Parameters.AddWithValue("@Genero", user.Genero);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Latitude", "0");
                    Cmd.Parameters.AddWithValue("@Longitude", "0");
                    Cmd.Parameters.AddWithValue("@Complemento", "");
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", "0");
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", "1");
                    Cmd.Parameters.AddWithValue("@IdStatusUsuario", "1");
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar usuario: " + ex.Message.ToString());
                }
                finally
                {
                    FecharConexao();
                }
            }
        }
    }
}
