﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class PedidoRepositorio : Conexao
    {
        public void RealizarPedido(Pedido pedido)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("RealizarPedido", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@CodigoPedido", pedido.Codigo);
                    Cmd.Parameters.AddWithValue("@IdVendedor", pedido.Vendedor.Id);
                    Cmd.Parameters.AddWithValue("@IdComprador", pedido.Comprador.Id);
                    Cmd.Parameters.AddWithValue("@IdStatusPedido", pedido.StatusPedido.Id);
                    Cmd.ExecuteNonQuery();

                    pedido.Id = int.Parse(Cmd.ExecuteScalar().ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao realizar pedido : " + ex.Message);
                }
            }

            using (Cmd = new SqlCommand("CadastrarItemPedido", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var i in pedido.Item)
                    {
                        Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                        Cmd.Parameters.AddWithValue("@IdItem", i.Id);
                        Cmd.Parameters.AddWithValue("@Quantidade", i.Quantidade);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar item pedido : " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public void FinalizarPedido(int idPedido)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("FinalizarPedido", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public void CancelarPedido(int idPedido)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CancelarPedido", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cancelar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public Pedido CarregarPedido(int idPedido)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CarregarPedido", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                    Pedido pedido = null;
                    while (Dr.Read())
                    { 
                        pedido = new Pedido();
                        pedido.Id = Convert.ToInt32(Dr["Item.Nome"]);
                        pedido.Codigo = Convert.ToString(Dr["Item.Quantidade"]);
                        pedido.Comprador.Nome = Convert.ToString(Dr["Item.Valorunitario"]);
                    }

                    Dr.Close();

                    return pedido;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao carregar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public List<Pedido> ListarPedidoVendedor(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarPedidoVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    List<Pedido> pedidoList = new List<Pedido>();

                    while (Dr.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.Id = Convert.ToInt32(Dr["Pedido.Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Pedido.Codigo"]);
                        pedido.Comprador.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                        pedidoList.Add(pedido);
                    }

                    return pedidoList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public List<Pedido> ListarPedidoComprador(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarPedidoComprador", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    List<Pedido> pedidoList = new List<Pedido>();

                    while (Dr.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.Id = Convert.ToInt32(Dr["Pedido.Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Pedido.Codigo"]);
                        pedido.Vendedor.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                        pedidoList.Add(pedido);
                    }

                    Dr.Close();

                    return pedidoList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public List<Pedido> ListarPedidoPeloStatusVendedor(int idUsuario, int idStatus)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarPedidoPeloStatusVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.Parameters.AddWithValue("@IdStatus", idStatus);
                    List<Pedido> pedidoList = new List<Pedido>();

                    while (Dr.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.Id = Convert.ToInt32(Dr["Pedido.Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Pedido.Codigo"]);
                        pedido.Comprador.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                        pedidoList.Add(pedido);
                    }

                    Dr.Close();

                    return pedidoList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

        public List<Pedido> ListarPedidoPeloStatusComprador(int idUsuario, int idStatus)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarPedidoPeloStatusComprador", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.Parameters.AddWithValue("@IdStatus", idStatus);
                    List<Pedido> pedidoList = new List<Pedido>();

                    while (Dr.Read())
                    {
                        Pedido pedido = new Pedido();
                        pedido.Id = Convert.ToInt32(Dr["Pedido.Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Pedido.Codigo"]);
                        pedido.Vendedor.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                        pedidoList.Add(pedido);
                    }

                    Dr.Close();

                    return pedidoList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar pedido: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }

    }
}