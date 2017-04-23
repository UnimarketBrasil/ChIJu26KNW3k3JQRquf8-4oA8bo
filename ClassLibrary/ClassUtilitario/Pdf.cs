using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using ClassLibrary;

namespace ClassUtilitario
{
    public class Pdf : PdfPageEventHelper
    {
        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        // string Logo { get; set; }

        //public override void OnStartPage(PdfWriter writer, Document doc)
        //{
        //    base.OnStartPage(writer, doc);

        //    BaseColor preto = new BaseColor(0, 0, 0);
        //    Font font = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
        //    Font titulo = FontFactory.GetFont("Verdana", 12, Font.BOLD, preto);
        //    float[] sizes = new float[] { 1f, 3f, 1f };

        //    PdfPTable table = new PdfPTable(3);
        //    table.TotalWidth = doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin);
        //    table.SetWidths(sizes);

        //    #region Logo Empresa
        //    Image foot;
        //    if (File.Exists(BasePath + @"\PublicResources\" + PageSubLogo))
        //    {
        //        foot = Image.GetInstance(BasePath + @"\PublicResources\" + PageSubLogo);
        //    }
        //    else
        //    {
        //        foot = Image.GetInstance(BasePath + @"\Content\tne_mascote.png");
        //    }
        //    foot.ScalePercent(60);

        //    PdfPCell cell = new PdfPCell(foot);
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.BorderWidthBottom = 1.5f;
        //    cell.PaddingTop = 10f;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);

        //    PdfPTable micros = new PdfPTable(1);
        //    cell = new PdfPCell(new Phrase(SubTitulo, corpo));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    micros.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(Titulo, titulo));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    micros.AddCell(cell);

        //    cell = new PdfPCell(micros);
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.BorderWidthBottom = 1.5f;
        //    cell.PaddingTop = 10f;
        //    table.AddCell(cell);
        //    #endregion

        //    #region Página
        //    micros = new PdfPTable(1);
        //    cell = new PdfPCell(new Phrase("Página: " + (doc.PageNumber).ToString(), font));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    micros.AddCell(cell);

        //    cell = new PdfPCell(micros);
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.BorderWidthBottom = 1.5f;
        //    cell.PaddingTop = 10f;
        //    table.AddCell(cell);
        //    #endregion

        //    table.WriteSelectedRows(0, -1, doc.LeftMargin, (doc.PageSize.Height - 10), writer.DirectContent);
        //}

        //public override void OnEndPage(PdfWriter writer, Document doc)
        //{
        //    base.OnEndPage(writer, doc);

        //    BaseColor preto = new BaseColor(0, 0, 0);
        //    Font font = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
        //    Font negrito = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);
        //    float[] sizes = new float[] { 1.0f, 3.5f, 1f };

        //    PdfPTable table = new PdfPTable(3);
        //    table.TotalWidth = doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin);
        //    table.SetWidths(sizes);

        //    #region Coluna TNE
        //    Image foot = Image.GetInstance(BasePath + @"\Content\tne_mascote.png");
        //    foot.ScalePercent(60);

        //    PdfPCell cell = new PdfPCell(foot);
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.PaddingLeft = 10f;
        //    cell.PaddingTop = 10f;
        //    table.AddCell(cell);

        //    PdfPTable micros = new PdfPTable(1);
        //    cell = new PdfPCell(new Phrase("TNE", negrito));
        //    cell.Border = 0;
        //    micros.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Treta never ends", font));
        //    cell.Border = 0;
        //    micros.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("www.tretaneverends.com.br", font));
        //    cell.Border = 0;
        //    micros.AddCell(cell);

        //    cell = new PdfPCell(micros);
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.PaddingTop = 10f;
        //    table.AddCell(cell);
        //    #endregion

        //    #region Página
        //    micros = new PdfPTable(1);
        //    cell = new PdfPCell(new Phrase(DateTime.Today.ToString("dd/MM/yyyy"), font));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    micros.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(DateTime.Now.ToString("HH:mm:ss"), font));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    micros.AddCell(cell);

        //    cell = new PdfPCell(micros);
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Border = 0;
        //    cell.BorderWidthTop = 1.5f;
        //    cell.PaddingTop = 10f;
        //    table.AddCell(cell);
        //    #endregion

        //    table.WriteSelectedRows(0, -1, doc.LeftMargin, 70, writer.DirectContent);
        //}

        public virtual void PedidoPdf(Pedido pedido)
        {
            try
            {
                using (Document documento = new Document(PageSize.A4, 20, 10, 80, 80))
                {
                    var saida = new MemoryStream();
                    var preto = new BaseColor(0, 0, 0);
                    var fundo = new BaseColor(200, 200, 200);
                    Font corpo = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
                    Font titulo = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);
                    PdfWriter escrever = PdfWriter.GetInstance(documento, saida);

                    documento.AddAuthor("Unimarket Brasil");
                    documento.AddTitle(Titulo);
                    documento.AddSubject(SubTitulo);

                    documento.Open();

                    #region Cabeçalho do Relatório
                    var tabela = new PdfPTable(5);
                    float[] colsW = { 10, 10, 10, 10, 10 };
                    tabela.SetWidths(colsW);
                    tabela.HeaderRows = 1;
                    tabela.WidthPercentage = 100f;

                    tabela.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
                    tabela.DefaultCell.BorderColor = preto;
                    tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
                    tabela.DefaultCell.Padding = 10;
                    tabela.DefaultCell.BackgroundColor = fundo;

                    var DadosVendedor = pedido.Vendedor = new Usuario();
                    var DadosComprador = pedido.Comprador = new Usuario();
                    var endereco = new GeoCodificacao();
                    //Colspan = 5;              

                    tabela.AddCell(new Phrase(DadosVendedor.Nome + DadosVendedor.Telefone, titulo));
                    //tabela.AddCell(new Phrase(endereco.ObterEndereco(DadosVendedor), titulo));

                    tabela.AddCell(new Phrase(DadosComprador.Nome + DadosComprador.Telefone, titulo));
                    //.AddCell(new Phrase(endereco.ObterEndereco(DadosComprador), titulo));
                    

                    tabela.AddCell(new Phrase("CÓDIGO", titulo));
                    tabela.AddCell(new Phrase("ITEM", titulo));
                    tabela.AddCell(new Phrase("VALOR (UN)", titulo));
                    tabela.AddCell(new Phrase("QUANTIDADE", titulo));
                    tabela.AddCell(new Phrase("TOTAL", titulo));
                    #endregion

                    tabela.DefaultCell.Padding = 5;

                    foreach (var itemPedido in pedido.Item)
                    {
                        tabela.AddCell(new Phrase(itemPedido.Codigo, corpo));
                        tabela.AddCell(new Phrase(itemPedido.Nome, corpo));
                        tabela.AddCell(new Phrase(string.Format("{0:0.00}", itemPedido.ValorUnitario), corpo));
                        tabela.AddCell(new Phrase(itemPedido.Quantidade.ToString(), corpo));
                        tabela.AddCell(new Phrase(string.Format("{0:0.00}", (itemPedido.ValorUnitario * itemPedido.Quantidade)), corpo));
                    }

                    documento.Add(tabela);

                    documento.Close();

                    return;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Operação invalida: " + ex.Message);
            }
        }

        public virtual void PdfUsuario(List<Usuario> usuario)
        {
            try
            {
                using (Document documento = new Document(PageSize.A4, 20, 10, 80, 80))
                {
                    var saida = new MemoryStream();
                    var preto = new BaseColor(0, 0, 0);
                    var fundo = new BaseColor(200, 200, 200);
                    Font corpo = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
                    Font titulo = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);
                    PdfWriter escrever = PdfWriter.GetInstance(documento, saida);

                    documento.AddAuthor("Unimarket Brasil");
                    documento.AddTitle(Titulo);
                    documento.AddSubject(SubTitulo);

                    documento.Open();

                    #region Cabeçalho do Relatório
                    var tabela = new PdfPTable(5);
                    float[] colsW = { 10, 10, 10, 10, 10 };
                    tabela.SetWidths(colsW);
                    tabela.HeaderRows = 1;
                    tabela.WidthPercentage = 100f;

                    tabela.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
                    tabela.DefaultCell.BorderColor = preto;
                    tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
                    tabela.DefaultCell.Padding = 10;
                    tabela.DefaultCell.BackgroundColor = fundo;

                    tabela.AddCell(new Phrase("ID", titulo));
                    tabela.AddCell(new Phrase("NOME", titulo));
                    tabela.AddCell(new Phrase("EMAIL", titulo));
                    tabela.AddCell(new Phrase("TIPO USUÁRIO", titulo));
                    tabela.AddCell(new Phrase("STATUS USUÁRIO", titulo));
                    #endregion

                    tabela.DefaultCell.Padding = 5;

                    foreach (var user in usuario)
                    {
                        tabela.AddCell(new Phrase(user.Id.ToString(), corpo));
                        tabela.AddCell(new Phrase(user.Email, corpo));
                        tabela.AddCell(new Phrase(user.Nome, corpo));
                        tabela.AddCell(new Phrase(user.Tipousuario.Nome));
                        tabela.AddCell(new Phrase(user.StatusUsuario.Nome, corpo));
                    }

                    documento.Add(tabela);

                    documento.Close();

                    return;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Operação invalida: " + ex.Message);
            }
        }
    }

}