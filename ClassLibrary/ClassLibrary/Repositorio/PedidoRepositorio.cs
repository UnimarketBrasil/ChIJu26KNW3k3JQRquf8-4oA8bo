using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class PedidoRepositorio : Conexao
    {
        //ESSE MÉTODO CADASTRA UM NOVO PEDIDO NO BANCO DE DADOS
        public void RealizarPedido(Pedido pedido)
        {
            try
            {
                Abrirconexao();

                using (Cmd = new SqlCommand("RealizarPedido", Con))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    
                    Cmd.Parameters.AddWithValue("@IdVendedor", pedido.Vendedor.Id);
                    Cmd.Parameters.AddWithValue("@IdComprador", pedido.Comprador.Id);

                    pedido.Id = int.Parse(Cmd.ExecuteScalar().ToString());

                    foreach (var i in pedido.Item)
                    {
                        Cmd = new SqlCommand("CadastrarItemPedido", Con);
                        Cmd.CommandType = CommandType.StoredProcedure;

                        Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                        Cmd.Parameters.AddWithValue("@IdItem", i.Id);
                        Cmd.Parameters.AddWithValue("@Quantidade", i.Quantidade);
                        Cmd.Parameters.AddWithValue("@ValorUnitario", i.ValorUnitario);
                        Cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao realizar pedido : " + ex.Message);
            }

        }

        //ESTE METODO FINALIZA O PEDIDO DO USUARIO COMPRADOR E RETORNA "TRUE" CASO SEJA REALIZADO COM SUCESSO
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

        //ESTE METODO RECEBE O ID DO PEDIDO E CANCELA O PEDIDO REALIZADO PELO USUARIO COMPRADOR
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

        //ESTE METODO CARREGA UM PEDIDO PELO ID
        //SERÁ MOSTRADO NAS TELAS DETALHE DE PEDIDO (VENDEDOR/COMPRADOR)
        public Pedido CarregarPedidoComprador(Pedido pedido)
        {
            Abrirconexao();
            try
            {

                using (Cmd = new SqlCommand("CarregarPedidoComprador", Con))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                    Cmd.Parameters.AddWithValue("@IdComprador", pedido.Comprador.Id);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        pedido.Id = Convert.ToInt32(Dr["Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Codigo"]);
                        pedido.Valor = Convert.ToDouble(Dr["Valor"]);

                        pedido.Vendedor = new Usuario();
                        pedido.Vendedor.Id = Convert.ToInt32(Dr["IdVendedor"]);
                        pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]);
                        pedido.Vendedor.Latitude = Convert.ToString(Dr["LatVendedor"]);
                        pedido.Vendedor.Longitude = Convert.ToString(Dr["LongVendedor"]);
                        pedido.Vendedor.Numero = Convert.ToInt32(Dr["NumVendedor"]);
                        pedido.Vendedor.Complemento = Convert.ToString(Dr["ComplVendedor"]);
                        pedido.Vendedor.Telefone = Convert.ToString(Dr["Telefone"]);
                        pedido.Vendedor.Email = Convert.ToString(Dr["Email"]);

                        pedido.Data = Convert.ToDateTime(Dr["Data"]);
                        pedido.StatusPedido = new StatusPedido();
                        pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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

                            item.Id = Convert.ToInt32(Dr["Id"]);
                            item.Nome = Convert.ToString(Dr["Nome"]);
                            item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                            item.ValorUnitario = Convert.ToDouble(Dr["ValorUnitario"]);
                            item.ValorTotal = Convert.ToDouble(Dr["ValorTotal"]);

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

        //ESTE METODO CARREGA UM PEDIDO PELO ID
        //SERÁ MOSTRADO NAS TELAS DETALHE DE PEDIDO (VENDEDOR/COMPRADOR)
        public Pedido CarregarPedidoVendedor(Pedido pedido)
        {
            Abrirconexao();
            try
            {

                using (Cmd = new SqlCommand("CarregarPedidoVendedor", Con))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdPedido", pedido.Id);
                    Cmd.Parameters.AddWithValue("@IdVendedor", pedido.Vendedor.Id);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        Dr.Read();
                        pedido.Id = Convert.ToInt32(Dr["Id"]);
                        pedido.Codigo = Convert.ToString(Dr["Codigo"]);

                        pedido.Comprador = new Usuario();
                        pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]);
                        pedido.Comprador.Latitude = Convert.ToString(Dr["LatComprador"]);
                        pedido.Comprador.Longitude = Convert.ToString(Dr["LongComprador"]);
                        pedido.Comprador.Numero = Convert.ToInt32(Dr["NumComprador"]);
                        pedido.Comprador.Complemento = Convert.ToString(Dr["ComplComprador"]);
                        pedido.Comprador.Telefone = Convert.ToString(Dr["Telefone"]);
                        pedido.Comprador.Email = Convert.ToString(Dr["Email"]);

                        pedido.Data = Convert.ToDateTime(Dr["Data"]);
                        pedido.StatusPedido = new StatusPedido();
                        pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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

                            item.Id = Convert.ToInt32(Dr["Id"]);
                            item.Nome = Convert.ToString(Dr["Nome"]);
                            item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                            item.ValorUnitario = Convert.ToDouble(Dr["ValorUnitario"]);
                            item.ValorTotal = Convert.ToDouble(Dr["ValorTotal"]);

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

        //ESTE METODO LISTA TODOS OS PEDIDOS RECEBIDOS PELO USUARIO VENDEDPOR E RETORNA "TRUE" CASO POSSUA PEDIDOS A SEREM EXIBIDOS
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
                            pedido.Data = Convert.ToDateTime(Dr["Data"]);
                            pedido.Comprador = new Usuario();
                            pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);
                            pedido.StatusPedido = new StatusPedido();
                            pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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

        //ESTE METODO LISTA TODOS OS PEDIDOS REALIZADO PELO USUARIO COMPRADOR E RETORNA TRUE
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
                            pedido.Data = Convert.ToDateTime(Dr["Data"]);
                            pedido.Vendedor = new Usuario();
                            pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);
                            pedido.StatusPedido = new StatusPedido();
                            pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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

        //ESTE METODO LISTA OS PEDIDOS PELO STATUS E APRESENTA AO USUARIO VENDEDOR
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
                            pedido.Data = Convert.ToDateTime(Dr["Data"]);
                            pedido.Comprador = new Usuario();
                            pedido.Comprador.Nome = Convert.ToString(Dr["Comprador"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);
                            pedido.StatusPedido = new StatusPedido();
                            pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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

        //ESTE METODO LISTA OS PEDIDOS PELO STATUS E APRESENTA AO USUARIO COMPRADOR
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
                            pedido.Data = Convert.ToDateTime(Dr["Data"]);
                            pedido.Vendedor = new Usuario();
                            pedido.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]).ToUpper();
                            pedido.Valor = Math.Round(Convert.ToDouble(Dr["Valor"]), 2);
                            pedido.StatusPedido = new StatusPedido();
                            pedido.StatusPedido.Nome = Convert.ToString(Dr["Status"]);

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
