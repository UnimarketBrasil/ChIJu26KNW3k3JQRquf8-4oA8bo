using System;
using System.Data.SqlClient;

namespace ClassLibrary
{
    //ESTE METODO REALIZA A CONEXAO ENTRE O BANCO DE DADOS E O SISTEMA
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
