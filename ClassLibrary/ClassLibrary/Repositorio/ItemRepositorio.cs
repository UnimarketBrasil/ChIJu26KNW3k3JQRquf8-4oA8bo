using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositorio
{
    class ItemRepositorio : Conexao
    {
        //Insert Item
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
                    Cmd.Parameters.AddWithValue("@Categoria", item.Categoria.Id);
                    Cmd.Parameters.AddWithValue("@Usuario", item.Usuario.Id);

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

        //Update Item
        public void AtualizarItem(Item item)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("Atualizar", Con))
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
        }//

        //List Item
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
        //Detalhe do item
        public Item DetalheItem(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItem", Con))
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

                    return item;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao detalhar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }//

        //BuscarItem
        public Item PesquisarItemPorCodigo(int idUsuario, int codigo)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItem", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.Parameters.AddWithValue("@Codigo", codigo);

                    Item item = null;

                    if (Dr.Read())
                    {
                        item = new Item();
                        item.Codigo = Convert.ToString(Dr["Item.Codigo"]);
                        item.Nome = Convert.ToString(Dr["Item.Nome"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Item.Valorunitario"]);
                        item.Quantidade = Convert.ToString(Dr["Item.Quantidade"]);
                    }

                    return item;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao buscar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }//

        //Desable Item por Id
        public void DesebilitarItemPorId(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DesabilitarItemPorId", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Id", idItem);
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

        //Select Produtos
        public List<Item> MecanismoDeBusca(string produto, Usuario comprador)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("MecanismoDeBusca", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Pesquisa", produto);
                    Cmd.Parameters.AddWithValue("@LatitudeComprador", comprador.Latitude);
                    Cmd.Parameters.AddWithValue("@LongitudeComprador", comprador.Longitude);
                    List<Item> itemList = new List<Item>();

                    while (Dr.Read())
                    {
                        Item item = new Item();
                        item.Id = Convert.ToInt32(Dr["Item.Id"]);
                        item.Codigo = Convert.ToString(Dr["Item.Nome"]);
                        item.Nome = Convert.ToString(Dr["Item.ValorUnitario"]);

                        itemList.Add(item);
                    }

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao buscar Item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }//
    }
}

    
 