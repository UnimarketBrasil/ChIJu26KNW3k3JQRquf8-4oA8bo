using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    class ItemRepositorio : Conexao
    {
        public void CadastrarItem(Item item)
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
                    Cmd.Parameters.AddWithValue("@IdUsuario", item.Usuario.Id);

                }
                catch (Exception ex)
                {
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

        public Item DetalheItemVendedor(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItemVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);

                    Item item = null;

                    if (Dr.Read())
                    {
                        item = new Item();
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.Descricao = Convert.ToString(Dr["Item.Descricao"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);
                        item.Categoria.Descricao = Convert.ToString(Dr["Categoria.Nome"]);
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

                    Item item = null;

                    if (Dr.Read())
                    {
                        item = new Item();
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.Descricao = Convert.ToString(Dr["Item.Descricao"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);
                        item.Categoria.Descricao = Convert.ToString(Dr["Categoria.Nome"]);
                        item.Usuario.Nome = Convert.ToString(Dr["Usuario.Nome"]);
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

                    List<Item> itemList = new List<Item>();

                    while (Dr.Read())
                    {
                        Item item = new Item();
                        item.Id = Convert.ToInt32(Dr["Item.Id"]);
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);

                        itemList.Add(item);
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

                    List<Item> itemList = new List<Item>();

                    while (Dr.Read())
                    {
                        Item item = new Item();
                        item.Id = Convert.ToInt32(Dr["Item.Id"]);
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);

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

                    List<Item> itemList = new List<Item>();

                    while (Dr.Read())
                    {
                        Item item = new Item();
                        item.Id = Convert.ToInt32(Dr["Item.Id"]);
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);

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

                    List<Item> itemList = new List<Item>();

                    while (Dr.Read())
                    {
                        Item item = new Item();
                        item.Id = Convert.ToInt32(Dr["Item.Id"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.ValorUnitario"]);
                        item.Usuario.Nome = Convert.ToString(Dr["Usuario.Nome"]);

                        itemList.Add(item);
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

    
 