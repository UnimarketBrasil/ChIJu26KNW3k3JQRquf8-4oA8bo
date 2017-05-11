using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class CategoriaRepositorio : Conexao
    {
        public List<Categoria> ListarCategoria()
        {
            Abrirconexao();

            List<Categoria> categoriaList = new List<Categoria>();

            using (Cmd = new SqlCommand("CarregarCategoria", Con))
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
                            Categoria cat = new Categoria();
                            cat.Id = Convert.ToInt32(Dr["Id"]);
                            cat.Nome = Convert.ToString(Dr["Nome"]);

                            categoriaList.Add(cat);
                        }
                    }

                    return categoriaList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ao Listar Usuario: " + ex.Message);
                }
                finally
                {
                    Dr.Close();

                    FecharConexao();
                }
            }
        }
    }
}
