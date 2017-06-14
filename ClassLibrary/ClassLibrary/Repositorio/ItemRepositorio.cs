using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
namespace ClassLibrary.Repositorio
{
    public class ItemRepositorio : Conexao
    {
        //ESSE MÉTODO CADASTRA UM ITEM NO BANCO DE DADOS E RETORNA "TRUE" CASO O ITEM SEJA
        //CADASTRADO COM SUCESSO
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
        //ESSE MÉTODO ALUALIZA UM ITEM NO BANCO DE DADOS E RETORNA "TRUE" CASO O ITEM SEJA
        //ATUALIZADO COM SUCESSO
        public bool AtualizarItem(Item item)
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

                    return true;
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
        //ESSE MÉTODO DASABILITA (EXCLUI) UM ITEM NO BANDO DE DADOS
        public bool DesabilitarItemPorId(int idItem)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DesabilitarItemPorId", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Erro ao desabilitar item: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }
        }
        //ESSE MÉTODO RETORNA UM ITEM COM DETALHES DO SEU VENDEDOR
        public Item DetalheItem(int idItem)
        {
            Abrirconexao();

            Item item = null;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

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
                        item.Id = Convert.ToInt32(Dr["Id"]);
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["Valorunitario"]), 2);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        if (!string.IsNullOrEmpty(Dr["Descricao"].ToString()))
                        {
                            item.Descricao = char.ToUpper(Convert.ToString(Dr["Descricao"])[0]) + Convert.ToString(Dr["Descricao"]).Substring(1);
                        }
                        item.Categoria = new Categoria();
                        item.Categoria.Nome = Convert.ToString(Dr["Categoria"]);
                        item.Vendedor = new Usuario();
                        item.Vendedor.Id = Convert.ToInt32(Dr["IdVendedor"]);
                        item.Vendedor.Nome = ti.ToTitleCase(Convert.ToString(Dr["Vendedor"]));
                        item.Vendedor.Latitude = Convert.ToString(Dr["Latitude"]);
                        item.Vendedor.Longitude = Convert.ToString(Dr["Longitude"]);
                        item.Vendedor.Telefone = Convert.ToString(Dr["Telefone"]);
                        item.Vendedor.Email = Convert.ToString(Dr["Email"]);

                    }

                    return item;
                }
                catch (Exception ex)
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

        public Item DetalheItemCarrinho(int idItem)
        {
            Abrirconexao();

            Item item = null;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

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
                        item.Id = Convert.ToInt32(Dr["Id"]);
                        item.Nome = ti.ToTitleCase(Convert.ToString(Dr["Nome"]));
                        item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["Valorunitario"]), 2);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        item.Vendedor = new Usuario();
                        item.Vendedor.Id = Convert.ToInt32(Dr["IdVendedor"]);

                    }

                    return item;
                }
                catch (Exception ex)
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
        //ESSE MÉTODO RECEBE POR PARAMETRO ID DE UM ITEM E ID DO USUÁRIO VENDEDOR (DONO) 
        //RETORNA ITEM != null CASO AQUELE ITEM EXISTA PARA O VENDEDOR (OBTIDO NA SESSION["sistema"])
        public Item DetalheItemVendedor(int idItem, int idUsuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("DetalheItemVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdItem", idItem);
                    Cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    Item item = null;

                    if (Dr.HasRows)
                    {
                        item = new Item();
                        Dr.Read();
                        item.Id = Convert.ToInt32(Dr["Id"]);
                        item.Codigo = Convert.ToString(Dr["Codigo"]);
                        item.Nome = Convert.ToString(Dr["Nome"]);
                        item.Descricao = Convert.ToString(Dr["Descricao"]);
                        item.ValorUnitario = Convert.ToDouble(Dr["Valorunitario"]);
                        item.Quantidade = Convert.ToDouble(Dr["Quantidade"]);
                        item.Categoria = new Categoria();
                        item.Categoria.Id = Convert.ToInt32(Dr["IdCategoria"]);
                        item.Vendedor = new Usuario();
                        item.Vendedor.Id = Convert.ToInt32(Dr["IdUsuario"]);

                    }

                    return item;
                }
                catch (Exception ex)
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

        //ESSE MÉTODO LISTA OS ITENS DO CADASTRADOS PELO USUARIO VENDEDOR
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

        //ESSE MÉTODO LISTA OS 3 ITENS MAIS VENDIDOS
        public List<Item> ListarTop3Itens()
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("Top3Itens", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;

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
                            item.ValorUnitario = Math.Round(Convert.ToDouble(Dr["Valorunitario"]), 2);
                            item.Vendedor = new Usuario();
                            item.Vendedor.Id = Convert.ToInt32(Dr["IdUsuario"]);

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
                    Dr.Close();

                    FecharConexao();
                }
            }
        }

        //ESSE MÉTODO LISTA OS ITENS CONFORME SUA CATEGORIA
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

        //ESSE MÉTODO LISTA OS ITENS CONFORME SEU NOME OU CODIGO CADASTRADOS
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

        //ESSE MÉTODO FAZ UMA PESQUISA DE ALGUM ITEM DIGITADO NA BARRA DE PESQUISAS E RETORNA ESTE ITEM CASO SEJA ENCOTRADO CADASTRADO NO SISTEMA
        public List<Item> MecanismoDeBusca(string pesquisa, Usuario comprador)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("MecanismoDeBusca", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Pesquisa", pesquisa);
                    Cmd.Parameters.AddWithValue("@IdComprador", comprador.Id);
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
                            item.Vendedor.Id = Convert.ToInt32(Dr["IdVendendor"]);
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

        //
        public List<Item> MecanismoDeBuscaCategoria(int IdCategoria, Usuario comprador)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("MecanismoDeBuscaCategoria", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                    Cmd.Parameters.AddWithValue("@IdComprador", comprador.Id);
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
                            item.Vendedor.Id = Convert.ToInt32(Dr["IdVendendor"]);
                            item.Vendedor.Nome = ti.ToTitleCase(Convert.ToString(Dr["Vendedor"]));

                            itemList.Add(item);
                        }
                    }

                    return itemList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar Item: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();
                }
            }
        }

        public List<RelatorioItem> RelatorioItem(Usuario usuario)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("RelatorioPedidos", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdVendedor", usuario.Id);

                    Dr = Cmd.ExecuteReader();

                    List<RelatorioItem> relatorio = new List<RelatorioItem>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            RelatorioItem rel = new RelatorioItem(
                                Convert.ToInt32(Dr["IdItem"]),
                                Convert.ToInt32(Dr["QuantidadeItens"]),
                                Convert.ToString(Dr["Nome"])
                            );

                            relatorio.Add(rel);
                        }
                    }

                    Dr.Close();

                    return relatorio;

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro executar relatorio: " + ex.Message);
                }
                finally
                {
                    FecharConexao();
                }
            }

        }
    }
}


