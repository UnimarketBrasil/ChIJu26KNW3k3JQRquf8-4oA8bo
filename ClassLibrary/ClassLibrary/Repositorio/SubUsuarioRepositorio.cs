﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class SubUsuarioRepositorio : Conexao
    {
        public void CadastrarUsuario(SubUsuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CadastrarSubUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Usuario.Id);
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

        public void AtualizarSubUsuario(SubUsuario user)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarSubUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdSubUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    Cmd.Parameters.AddWithValue("@Email", user.Email);

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

        public void AtualizarSenhaSubUsuario(int idSubUsuario, string senha)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarSenhaSubUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", senha);
                    Cmd.Parameters.AddWithValue("@Senha", senha);

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

        public SubUsuario CarregarSubUsuario(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CarregarSubUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    SubUsuario user = null;

                    if (Dr.Read())
                    {
                        user = new SubUsuario();
                        user.Id = Convert.ToInt32(Dr["SubUsuario.Id"]);
                        user.Nome = Convert.ToString(Dr["SubUsuario.Email"]);
                        user.Email = Convert.ToString(Dr["SubUsuario.Nome"]);
                    }

                    Dr.Close();

                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro oa carregar usuario: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }
    }
}