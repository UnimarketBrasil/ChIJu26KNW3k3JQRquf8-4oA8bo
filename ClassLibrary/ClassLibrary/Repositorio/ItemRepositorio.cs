using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
namespace ClassLibrary.Repositorio
{
    public class ItemRepositorio : Conexao
    {
        public bool CadastrarItem(Item item)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("CadastrarItem", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Codigo", item.Codigo);
                    Cmd.Parameters.AddWithValue("@Nome", item.Nome);
                    Cmd.Parameters.AddWithValue("@Descricao", item.Descricao);
                    Cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
                    Cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    Cmd.Parameters.AddWithValue("@IdCategoria", item.Categoria.Id);
                    Cmd.Parameters.AddWithValue("@IdUsuario", item.Vendedor.Id);
                    Cmd.ExecuteNonQuery();

                    item.Id = int.Parse(Cmd.ExecuteScalar().ToString());

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Erro ao cadastrar item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public void AtualizarItem(Item item)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("AtualizarItem", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", item.Id);
                    Cmd.Parameters.AddWithValue("@Codigo", item.Codigo);
                    Cmd.Parameters.AddWithValue("@Nome", item.Nome);
                    Cmd.Parameters.AddWithValue("@Descricao", item.Descricao);
                    Cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
                    Cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    Cmd.Parameters.AddWithValue("@IdCategoria", item.Categoria.Id);
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public void DesabilitarItemPorId(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DesabilitarItemPorId", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao desabilitar item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public Item DetalheItem(int idItem)
        {
            Abrirconexao();

            Item item = null;

            using (Cmd = new SqlCommand("DetalheItem", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    if (Dr.HasRows)
                    {
                        item = new Item();

                        Dr.Read();
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = Convert.ToString(Dr["Nome"]);
                        item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["Valorunitario"]), 2);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        item.Descricao = Convert.ToString(Dr["Descricao"]);
                        item.Categoria = new Categoria();
                        item.Categoria.Nome = Convert.ToString(Dr["Categoria"]);
                        item.Vendedor = new Usuario();
                        item.Vendedor.Nome = Convert.ToString(Dr["Vendedor"]);
                        item.Vendedor.Latitude = Convert.ToString(Dr["Latitude"]);
                        item.Vendedor.Longitude = Convert.ToString(Dr["Longitude"]);
                        item.Vendedor.Telefone = Convert.ToString(Dr["Telefone"]);
                        item.Vendedor.Email = Convert.ToString(Dr["Email"]);

                    }

                    return item;
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro o carregar Item: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();

                }
            }
        }
        public Item DetalheItemVendedor(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItemVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    Item item = null;

                    if (Dr.HasRows)
                    {
                        item = new Item();
                        Dr.Read();
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = Convert.ToString(Dr["Nome"]);
                        item.Descricao = Convert.ToString(Dr["Descricao"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Valorunitario"]);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        //item.Categoria = new Categoria(Convert.ToString(Dr["Categoria.Nome"]));
                    }

                    Dr.Close();

                    return item;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro o carregar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public Item DetalheItemComprador(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItemCompradador", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    Item item = null;

                    if (Dr.HasRows)
                    {
                        item = new Item();
                        Dr.Read();
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = Convert.ToString(Dr["Nome"]);
                        item.Descricao = Convert.ToString(Dr["Descricao"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Valorunitario"]);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        //item.Categoria = new Categoria(Convert.ToString(Dr["Categoria.Nome"]));
                        item.Comprador = new Usuario();
                        item.Comprador.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                    }

                    Dr.Close();

                    return item;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public List<Item> ListarItem(int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarItem", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Item> itemList = new List<Item>();
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Item item = new Item();
                            item.Id = Convert.ToInt32(Dr["Id"]);
                            item.Codigo = Convert.ToString(Dr["Codigo"]);
                            item.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                            item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["Valorunitario"]), 2);
                            item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);

                            itemList.Add(item);
                        }

                    }

                    Dr.Close();

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public List<Item> ListarItemPorCategoria(Usuario user, int idCategoria)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarItemPorCategoria", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    Cmd.Parameters.AddWithValue("@LatitudeComprador", user.Latitude);
                    Cmd.Parameters.AddWithValue("@Longitudeomprador", user.Longitude);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Item> itemList = new List<Item>();

                    while (Dr.HasRows)
                    {
                        Item item = new Item();
                        Dr.Read();
                        item.Id = Convert.ToInt32(Dr["Id"]);
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = Convert.ToString(Dr["Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Valorunitario"]);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);

                        itemList.Add(item);
                    }

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public List<Item> ListarItemPorNomeOuCodigo(Usuario user, string codigo)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarItemPorNoMeOuCodigo", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", user.Id);
                    Cmd.Parameters.AddWithValue("@Codigo", codigo);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Item> itemList = new List<Item>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Item item = new Item();
                            item.Id = Convert.ToInt32(Dr["Id"]);
                            item.Codigo = Convert.ToString(Dr["Codigo"]);
                            item.Nome = Convert.ToString(Dr["Nome"]);
                            item.ValorUnitario = Convert.ToDouble(Dr["Valorunitario"]);
                            item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);

                            itemList.Add(item);
                        }
                    }

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }

        public List<Item> MecanismoDeBusca(string pesquisa, Usuario comprador)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("MecanismoDeBusca", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Pesquisa", pesquisa);
                    Cmd.Parameters.AddWithValue("@LatitudeComprador", comprador.Latitude);
                    Cmd.Parameters.AddWithValue("@LongitudeComprador", comprador.Longitude);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<Item> itemList = new List<Item>();
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Item item = new Item();
                            item.Id = Convert.ToInt32(Dr["Id"]);
                            item.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                            item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["ValorUnitario"]), 2);
                            item.Vendedor = new Usuario();
                            item.Vendedor.Nome = ti.ToTitleCase(Convert.ToString(Dr["Vendedor"]));

                            itemList.Add(item);
                        }
                    }

                    Dr.Close();

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }
    }
}


