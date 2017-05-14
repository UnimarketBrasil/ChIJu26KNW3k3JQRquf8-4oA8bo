using System;
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
                        Cmd.ExecuteNonQuery();
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
                    Cmd.ExecuteNonQuery();
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
                    Cmd.ExecuteNonQuery();
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

        public Pedido CarregarPedido(Pedido pedido)
        {
            Abrirconexao();
            try
            {

                using (Cmd = new SqlCommand("CarregarPedido", Con))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        pedido.Data = Convert.ToDateTime(Dr["Data"]);
                        pedido.Vendedor = new Usuario();
                        pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]);
                        pedido.Comprador = new Usuario();
                        pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]);
                        pedido.Comprador.Latitude = Convert.ToString(Dr["Latitude"]);
                        pedido.Comprador.Longitude = Convert.ToString(Dr["Longitude"]);
                        pedido.Comprador.Numero = Convert.ToInt32(Dr["Numero"]);
                        pedido.Comprador.Complemento = Convert.ToString(Dr["Complemento"]);

                        Dr.Close();
                    }
                }

                using (Cmd = new SqlCommand("CarregarItemPedido", Con))
                {

                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    pedido.Item = new List<Item>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Item item = new Item();

                            item.Nome = Convert.ToString(Dr["Nome"]);
                            item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                            item.ValorUnitario = Convert.ToDouble(Dr["ValorUnitario"]);

                            pedido.Item.Add(item);
                        }
                    }

                    Dr.Close();

                    return pedido;
                }
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

        public List<Pedido> ListarPedidoVendedor(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarPedidoVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Pedido> pedidoList = new List<Pedido>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Pedido pedido = new Pedido();
                            pedido.Id = Convert.ToInt32(Dr["Id"]);
                            pedido.Codigo = Convert.ToString(Dr["Codigo"]);
                            pedido.Comprador = new Usuario();
                            pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);

                            pedidoList.Add(pedido);
                        }
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
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Pedido> pedidoList = new List<Pedido>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Pedido pedido = new Pedido();
                            pedido.Id = Convert.ToInt32(Dr["Id"]);
                            pedido.Codigo = Convert.ToString(Dr["Codigo"]);
                            pedido.Vendedor = new Usuario();
                            pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);

                            pedidoList.Add(pedido);
                        }
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
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Pedido> pedidoList = new List<Pedido>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Pedido pedido = new Pedido();
                            pedido.Id = Convert.ToInt32(Dr["Id"]);
                            pedido.Codigo = Convert.ToString(Dr["Codigo"]);
                            pedido.Comprador = new Usuario();
                            pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);

                            pedidoList.Add(pedido);
                        }

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
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Pedido> pedidoList = new List<Pedido>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Pedido pedido = new Pedido();
                            pedido.Id = Convert.ToInt32(Dr["Id"]);
                            pedido.Codigo = Convert.ToString(Dr["Codigo"]);
                            pedido.Vendedor = new Usuario();
                            pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);

                            pedidoList.Add(pedido);
                        }
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
