using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace ClassLibrary.Repositorio
{
    public class UsuarioRepositorio : Conexao
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        public bool CadastrarUsuario(Usuario user)
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
                    Cmd.Parameters.AddWithValue("@HashConfirmacao", user.HashConfirmacao);
                    Cmd.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    Cmd.Parameters.AddWithValue("@Genero", user.Genero);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@CEP", user.CEP);
                    Cmd.Parameters.AddWithValue("@Numero", user.Numero);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    user.Id = int.Parse(Cmd.ExecuteScalar().ToString());

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    //Dr.Close();

                    FecharConexao();
                }
            }
        }

        public bool AtualizarUsuario(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Sobrenome", user.Sobrenome);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@Numero", user.Numero);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public string ValidarEmailCpfCnpj(Usuario user)
        {
            Abrirconexao();

            String existe = null;

            using (Cmd = new SqlCommand("ValidaEmailCpfCnpj", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        existe = Convert.ToString(Dr["Existe"]);
                    }

                    return existe;
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                }
            }
        }

        public bool ConfirmarCadastro(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ConfirmarCadastro", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@HashConfirmacao", user.HashConfirmacao);

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        user.Id = Convert.ToInt32(Dr["Id"]);
                        user.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.Numero = Convert.ToInt32(Dr["Numero"]);
                        user.AreaAtuacao = Convert.ToDouble(Dr["AreaAtuacao"]);
                        user.StatusUsuario = new StatusUsuario();
                        user.StatusUsuario.Id = Convert.ToInt32(Dr["IdStatusUsuario"]);
                        user.Tipousuario = new TipoUsuario();
                        user.Tipousuario.Id = Convert.ToInt32(Dr["IdTipoUsuario"]);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();
                }
            }
        }


        public void IncluirEndereco(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("IncluirEndereco", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao incluir endereco: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public void BloquearUsuario(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("BloquearUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao bloquear usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public void DesbloquearUsuario(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DesbloquearUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao bloquear usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public void AtualizarSenha(Usuario user, string novaSenha)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarSenha", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@SenhaAtual", user.Senha);
                    Cmd.Parameters.AddWithValue("@NovaSenha", novaSenha);
                    Cmd.ExecuteNonQuery();

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

        public bool RecuperarSenha(string email)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("RecuperarSenha", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", email);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    bool retorno = false;

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        retorno = Convert.ToBoolean(Dr["@Retorno"]);
                    }

                    Dr.Close();

                    return retorno;

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

        public bool LoginUsuario(Usuario user)
        {
            bool login;
            Abrirconexao();

            using (Cmd = new SqlCommand("LoginUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();


                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        user.Id = Convert.ToInt32(Dr["Id"]);
                        user.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.AreaAtuacao = Convert.ToDouble(Dr["AreaAtuacao"]);
                        user.StatusUsuario = new StatusUsuario();
                        user.StatusUsuario.Id = Convert.ToInt32(Dr["IdStatusUsuario"]);
                        user.Tipousuario = new TipoUsuario(Convert.ToInt32(Dr["IdTipoUsuario"]));
                        login = true;
                    }
                    else
                    {
                        login = false;
                    }

                    Dr.Close();

                    return login;

                }
                catch
                {
                    return false;
                    //throw new Exception("Erro ao cadastrar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public bool CarregarUsuario(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CarregarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();

                        user.Id = Convert.ToInt32(Dr["Id"]);
                        user.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        user.Sobrenome = ti.ToTitleCase(Convert.ToString(Dr["Sobrenome"]));
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Genero = Convert.ToInt32(Dr["Genero"]);
                        user.Telefone = Convert.ToString(Dr["Telefone"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.Complemento = Convert.ToString(Dr["Complemento"]);
                        user.Numero = Convert.ToInt32(Dr["Numero"]);
                        user.AreaAtuacao = Convert.ToDouble(Dr["AreaAtuacao"]);
                        user.StatusUsuario = new StatusUsuario();
                        user.StatusUsuario.Id = Convert.ToInt32(Dr["IdStatusUsuario"]);
                        user.Tipousuario = new TipoUsuario(Convert.ToInt32(Dr["IdTipoUsuario"]));
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Erro ao Carregar usuario: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();
                }
            }

        }

        public Usuario DetalheUsuario(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    Usuario user = null;

                    if (Dr.HasRows)
                    {
                        user = new Usuario();
                        Dr.Read();
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        user.Sobrenome = ti.ToTitleCase(Convert.ToString(Dr["Sobrenome"]));
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.Genero = Convert.ToInt32(Dr["Genero"]);
                        user.Telefone = Convert.ToString(Dr["Telefone"]);
                        user.DataCadastro = Convert.ToDateTime(Dr["DataCadastro"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.Complemento = Convert.ToString(Dr["Complemento"]);
                        user.AreaAtuacao = Convert.ToInt32(Dr["AreaAtuacao"]);
                        user.QtdadeItens = Convert.ToInt32(Dr["QtdadeItens"]);
                        user.QtdPedidosPendente = Convert.ToInt32(Dr["PedidosPendente"]);
                        user.QtdPedidosFinanlizado = Convert.ToInt32(Dr["PedidosFinalizado"]);
                        user.QtdPedidosCancelado = Convert.ToInt32(Dr["PedidosCancelado"]);
                        user.Tipousuario = new TipoUsuario();
                        user.Tipousuario.Nome = Convert.ToString(Dr["TipoUsuario"]);
                        user.StatusUsuario = new StatusUsuario();
                        user.StatusUsuario.Nome = Convert.ToString(Dr["StatusUsuario"]);
                    }

                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar usuario: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();
                }
            }

        }

        public List<Usuario> ListarUsuario()
        {
            Abrirconexao();

            List<Usuario> usuarioList = new List<Usuario>();
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

            using (Cmd = new SqlCommand("ListarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Usuario user = new Usuario();
                            user.Id = Convert.ToInt32(Dr["Id"]);
                            user.Email = Convert.ToString(Dr["Email"]).ToLower();
                            user.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                            user.Tipousuario = new TipoUsuario();
                            user.Tipousuario.Nome = Convert.ToString(Dr["TipoUsuario"]);
                            user.StatusUsuario = new StatusUsuario();
                            user.StatusUsuario.Nome = Convert.ToString(Dr["StatusUsuario"]);

                            usuarioList.Add(user);
                        }
                    }

                    Dr.Close();

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
    }
}
