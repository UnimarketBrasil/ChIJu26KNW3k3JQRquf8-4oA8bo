using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views.Vendedor
{
    public partial class VenderRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/Logout.aspx");
            

           
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetChartData()
        {

            Usuario user = (Usuario)Session["sistema"];
            PedidoRepositorio consulta = new PedidoRepositorio();

            List<RelatorioPedido> data = new List<RelatorioPedido>();
            DateTime inicio = new DateTime(2017, 04, 01);
            DateTime fim = new DateTime(2017, 07, 01);
            data = consulta.RelatorioPedido(user, inicio, fim);

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                    "Product Category",
                    "Revenue Amount"
                };
            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.Valor, i.Data };
            }

            return chartData;
        }

    }
    
}