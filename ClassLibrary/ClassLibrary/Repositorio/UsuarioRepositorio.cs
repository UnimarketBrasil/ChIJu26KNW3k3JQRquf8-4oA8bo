using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositorio
{
    class UsuarioRepositorio : Conexao
    {
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
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    Cmd.Parameters.AddWithValue("@IdStatusUsuario", user.Tipousuario.Id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        //Update Usuario
        public void AtualizarUsuario(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Sobrenome", user.Sobrenome);
                    Cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        //List Usuario
        public List<Usuario> ListarUsuario()
        {
            Abrirconexao();

            List<Usuario> usuarioList = new List<Usuario>();

            using (Cmd = new SqlCommand("ListarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;

                    while (Dr.Read())
                    {
                        Usuario user = new Usuario();
                        user.Id = Convert.ToInt32(Dr["Usuario.Id"]);
                        user.Email = Convert.ToString(Dr["Usuario.Email"]);
                        user.Nome = Convert.ToString(Dr["Usuario.Nome"]);
                        user.Tipousuario.Nome = Convert.ToString(Dr["TipoUsuario.Nome"]);
                        user.StatusUsuario.Nome = Convert.ToString(Dr["StatusUsuario.Nome"]);

                        usuarioList.Add(user);
                    }

                    return usuarioList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar Usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        //Desable Usuario
        public void AlterarStatusUsuario(int idUsuario, int idStatusUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AlterarStatusUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.Parameters.AddWithValue("@IdStatuUsuario", idStatusUsuario);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        // public Usuario DetalheUsuario(int id)

        // public Usuario CarregarUsuario(int idUsuario)

    }
}
