using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassLibrary
{
    public class Conexao
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        protected void Abrirconexao()
        {
            try
            {
                string constr = System.Configuration.ConfigurationManager.AppSettings["conexao"];
                Con = new SqlConnection(constr);
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao conectar ao banco: " + ex.Message);
            }
        }

        protected void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fechar conexao com o banco: " + ex.Message);
            }
        }
    }
}
