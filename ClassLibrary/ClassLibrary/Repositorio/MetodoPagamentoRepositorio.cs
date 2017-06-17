using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Repositorio
{
    public class MetodoPagamentoRepositorio : Conexao
    {
        public List<MetodoPagamento> ListarMetodoPagamento(int idVendedor)
        {
            Abrirconexao();

            using (Cmd = new SqlCommand("ListarMetPgtoVendedor", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IdUsuario", idVendedor);
                    Cmd.ExecuteNonQuery();

                    Dr = Cmd.ExecuteReader();

                    List<MetodoPagamento> mPagamentoList = new List<MetodoPagamento>();

                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            MetodoPagamento mPagamento = new MetodoPagamento();
                            mPagamento.Id = Convert.ToInt32(Dr["Id"]);
                            mPagamento.tMetodoPgto = new TipoMetodosPagamento();
                            mPagamento.tMetodoPgto.Id = Convert.ToInt32(Dr["IdTipoMetodo"]);
                            mPagamento.Nome = Convert.ToString(Dr["Nome"]);

                            mPagamentoList.Add(mPagamento);
                        }

                    }

                    return mPagamentoList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro o carregar Metodo de Pagamento: " + ex.Message);
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
