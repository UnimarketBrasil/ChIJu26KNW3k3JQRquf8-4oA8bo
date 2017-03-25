using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassUtilitario
{
    public class IsEmail : Conexao
    {
        public bool  ValidarEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Depois alterar para bool
        public void ValidarEmailCpfCnpj(Usuario user)
        {
            bool valido = true;
            DataTable dt = new DataTable();
            Abrirconexao();

            using (Cmd = new SqlCommand("CadastrarUsuario", Con))
            {
                try
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Email", user.Email);
                    Cmd.Parameters.AddWithValue("@CpfCnpj", user.CpfCnpj);
                    Cmd.ExecuteNonQuery();

                    SqlDataAdapter sda = new SqlDataAdapter(Cmd);
                    sda.Fill(dt);

                    if (dt.Rows.Count <= 0)
                    {

                    }

                }
                catch
                {
                    //throw new Exception("Erro ao cadastrar usuario: " + ex.Message.ToString());
                    valido = false;
                }
                finally
                {
                    FecharConexao();
                }
            }
        }
    }
}
