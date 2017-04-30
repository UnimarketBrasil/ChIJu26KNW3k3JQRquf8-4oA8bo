﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class UsuarioRepositorio : Conexao
    {
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
                    Cmd.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    Cmd.Parameters.AddWithValue("@Nascimento", user.Nascimento);
                    Cmd.Parameters.AddWithValue("@Genero", user.Genero);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    //throw new Exception("Erro ao cadastrar usuario: " + ex.Message);
                    return false;
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public bool AtualizarUsuarioPJ(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarUsuarioPJ", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    //throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public bool AtualizarUsuarioPF(Usuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarUsuarioPF", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Sobrenome", user.Sobrenome);
                    Cmd.Parameters.AddWithValue("@Genero", user.Genero);
                    Cmd.Parameters.AddWithValue("@Nascimento", user.Nascimento);
                    Cmd.Parameters.AddWithValue("@Telefone", user.Telefone);
                    Cmd.Parameters.AddWithValue("@Latitude", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitude", user.Longitude);
                    Cmd.Parameters.AddWithValue("@Complemento", user.Complemento);
                    Cmd.Parameters.AddWithValue("@AreaAtuacao", user.AreaAtuacao);
                    Cmd.Parameters.AddWithValue("@IdTipoUsuario", user.Tipousuario.Id);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    //return false;
                    throw new Exception("Erro ao atualizar usuario: " + ex.Message);
                    return false;
                }
                finally
                {
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
                        user.Nome = Convert.ToString(Dr["Nome"]);
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.AreaAtuacao = Convert.ToDouble(Dr["AreaAtuacao"]);
                        user.StatusUsuario = new StatusUsuario(Convert.ToInt32(Dr["IdStatusUsuario"]));
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
                    //                    throw new Exception("Erro ao cadastrar usuario: " + ex.Message);
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
                        user.Email = Convert.ToString(Dr["Email"]);
                        user.Nome = Convert.ToString(Dr["Nome"]);
                        user.Sobrenome = Convert.ToString(Dr["Sobrenome"]);
                        user.CpfCnpj = Convert.ToString(Dr["CpfCnpj"]);
                        user.Nascimento = Convert.ToDateTime(Dr["Nascimento"]);
                        user.Genero = Convert.ToInt32(Dr["Genero"]);
                        user.Telefone = Convert.ToString(Dr["Telefone"]);
                        user.Latitude = Convert.ToString(Dr["Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Longitude"]);
                        user.Complemento = Convert.ToString(Dr["Complemento"]);
                        user.AreaAtuacao = Convert.ToInt32(Dr["AreaAtuacao"]);
                        user.Tipousuario = new TipoUsuario(Convert.ToInt32(Dr["IdTipoUsuario"]));
                    }

                    Dr.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Erro ao Carregar usuario: " + ex.Message);
                }
                finally
                {
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
                        Dr.Read();
                        user = new Usuario();
                        user.Nome = Convert.ToString(Dr["Usuario.Nome"]);
                        user.Sobrenome = Convert.ToString(Dr["Usuario.Sobrenome"]);
                        user.Email = Convert.ToString(Dr["Usuario.Email"]);
                        user.Telefone = Convert.ToString(Dr["Usuario.Telefone"]);
                        user.Latitude = Convert.ToString(Dr["Usuario.Latitude"]);
                        user.Longitude = Convert.ToString(Dr["Usuario.Longitude"]);
                        user.Complemento = Convert.ToString(Dr["Usuario.Complemento"]);
                        user.AreaAtuacao = Convert.ToInt32(Dr["Usuario.AreaAtuacao"]);
                        user.Tipousuario.Nome = Convert.ToString(Dr["TipoUsuario.Nome"]);
                        user.StatusUsuario.Nome = Convert.ToString(Dr["StatusUsuario.Nome"]);
                        Cmd.ExecuteNonQuery();
                    }

                    Dr.Close();

                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public List<Usuario> ListarUsuario()
        {
            Abrirconexao();

            List<Usuario> usuarioList = new List<Usuario>();

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
                            user.Id = Convert.ToInt32(Dr["Usuario.Id"]);
                            user.Email = Convert.ToString(Dr["Usuario.Email"]);
                            user.Nome = Convert.ToString(Dr["Usuario.Nome"]);
                            user.Tipousuario.Nome = Convert.ToString(Dr["TipoUsuario.Nome"]);
                            user.StatusUsuario.Nome = Convert.ToString(Dr["StatusUsuario.Nome"]);

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
