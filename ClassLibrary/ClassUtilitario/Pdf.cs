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
using ClassLibrary.Repositorio;

namespace ClassUtilitario
{
    public class Pdf : PdfPageEventHelper
    {
        public string Titulo { get; set; }

        protected PdfPCell fCell(string Texto, int Alinhamento)
        {
            var preto = new BaseColor(0, 0, 0);
            Font corpo = FontFactory.GetFont("Verdana", 9, Font.NORMAL, preto);

            var cell = new PdfPCell(new Phrase(Texto, corpo));
            cell.HorizontalAlignment = Alinhamento;
            cell.Border = PdfPCell.BOTTOM_BORDER;
            cell.BorderColor = new BaseColor(0, 0, 0);
            cell.BackgroundColor = new BaseColor(255, 255, 255);
            cell.Padding = 10;

            return cell;
        }

        protected PdfPCell tCell(string Texto, int Alinhamento)
        {
            var preto = new BaseColor(0, 0, 0);
            Font titulo = FontFactory.GetFont("Verdana", 10, Font.BOLD, preto);

            var cell = new PdfPCell(new Phrase(Texto, titulo));
            cell.HorizontalAlignment = Alinhamento;
            cell.Border = PdfPCell.BOTTOM_BORDER;
            cell.BorderColor = new BaseColor(0, 0, 0);
            cell.BackgroundColor = new BaseColor(200, 200, 200);
            cell.Padding = 10;

            return cell;
        }

        public virtual void PedidoPdf(Pedido pedido, MemoryStream saida)
        {
            try
            {
                using (Document documento = new Document(PageSize.A4, 20, 10, 80, 80))
                {
                    var preto = new BaseColor(0, 0, 0);
                    var fundo = new BaseColor(200, 200, 200);
                    Font titulo = FontFactory.GetFont("Verdana", 9, Font.BOLD, preto);
                    Font corpo = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
                    PdfWriter escrever = PdfWriter.GetInstance(documento, saida);

                    documento.AddAuthor("UNIMARET Brasil");
                    documento.AddTitle(Titulo);
                    documento.AddSubject(Titulo);

                    var footer = new formatacao();
                    footer.Titulo = Titulo;

                    documento.Open();

                    var tabela = new PdfPTable(5);
                    float[] colsW = { 5, 20, 5, 5, 5 };
                    tabela.SetWidths(colsW);
                    tabela.HeaderRows = 1;
                    tabela.WidthPercentage = 100f;

                    pedido.Vendedor = new Usuario();
                    var cell = fCell(pedido.Vendedor.Nome, Element.ALIGN_LEFT);
                    cell.Colspan = 5;
                    tabela.AddCell(cell);

                    //clienteOld = d.cliente.RazaoSocial;

                    //var DadosVendedor = pedido.Vendedor = new Usuario();
                    //var DadosComprador = pedido.Comprador = new Usuario();
                    //var endereco = new GeoCodificacao();

                    //tabela.AddCell(new Phrase(DadosVendedor.Nome + DadosVendedor.Telefone, titulo));
                    //tabela.AddCell(new Phrase(DadosComprador.Nome + DadosComprador.Telefone, titulo));

                    tabela.AddCell(tCell("CÓDIGO", Element.ALIGN_LEFT));
                    tabela.AddCell(tCell("ITEM", Element.ALIGN_LEFT));
                    tabela.AddCell(tCell("Val.(UN)", Element.ALIGN_RIGHT));
                    tabela.AddCell(tCell("QTD", Element.ALIGN_RIGHT));
                    tabela.AddCell(tCell("TOTAL", Element.ALIGN_RIGHT));

                    foreach (var itemPedido in pedido.Item)
                    {

                        tabela.AddCell(fCell(itemPedido.Codigo, Element.ALIGN_LEFT));
                        tabela.AddCell(fCell(itemPedido.Nome, Element.ALIGN_LEFT));
                        tabela.AddCell(fCell(string.Format("{0:0.00}", itemPedido.ValorUnitario), Element.ALIGN_RIGHT));
                        tabela.AddCell(fCell(itemPedido.Quantidade.ToString(), Element.ALIGN_RIGHT));
                        tabela.AddCell(fCell(string.Format("{0:0.00}", (itemPedido.ValorUnitario * itemPedido.Quantidade)), Element.ALIGN_RIGHT));
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

        public virtual void PdfUsuario(List<Usuario> usuario, MemoryStream saida)
        {
            try
            {
                using (Document documento = new Document(PageSize.A4, 20, 10, 80, 80))
                {
                    var preto = new BaseColor(0, 0, 0);
                    var fundo = new BaseColor(200, 200, 200);
                    Font corpo = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
                    Font titulo = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);
                    PdfWriter escrever = PdfWriter.GetInstance(documento, saida);

                    documento.AddAuthor("Unimarket Brasil");
                    documento.AddTitle("Usuarios");
                    documento.AddSubject("Usuarios");

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


    public class formatacao : PdfPageEventHelper
    {
        public string Titulo { get; set; }

        public override void OnOpenDocument(PdfWriter writer, Document doc)
        {
            base.OnOpenDocument(writer, doc);
        }

        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            base.OnStartPage(writer, doc);

            ImprimeCabecalho(writer, doc);
        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            base.OnEndPage(writer, doc);

            ImprimeRodape(writer, doc);
        }

        private void ImprimeRodape(PdfWriter writer, Document doc)
        {
            BaseColor preto = new BaseColor(0, 0, 0);
            Font font = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
            Font negrito = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);
            float[] sizes = new float[] { 1.0f, 3.5f, 1f };

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin);
            table.SetWidths(sizes);


            #region Coluna TNE
            //Image imagem = Image.GetInstance(BasePath + @"\Content\tne_mascote.png");
            //imagem.ScalePercent(60);

            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.PaddingLeft = 10f;
            cell.PaddingTop = 10f;
            table.AddCell(cell);

            PdfPTable micros = new PdfPTable(1);
            cell = new PdfPCell(new Phrase("UNIMARKET", negrito));
            cell.Border = 0;
            micros.AddCell(cell);
            cell = new PdfPCell(new Phrase("unimarket.academico.trilema.com.br", font));
            cell.Border = 0;
            micros.AddCell(cell);

            cell = new PdfPCell(micros);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.PaddingTop = 10f;
            table.AddCell(cell);
            #endregion

            #region Página
            micros = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(DateTime.Today.ToString("dd/MM/yyyy"), font));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            micros.AddCell(cell);
            cell = new PdfPCell(new Phrase(DateTime.Now.ToString("HH:mm:ss"), font));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            micros.AddCell(cell);

            cell = new PdfPCell(micros);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.PaddingTop = 10f;
            table.AddCell(cell);
            #endregion

            table.WriteSelectedRows(0, -1, doc.LeftMargin, 70, writer.DirectContent);

        }

        private void ImprimeCabecalho(PdfWriter writer, Document doc)
        {
            BaseColor preto = new BaseColor(0, 0, 0);
            Font font = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
            Font titulo = FontFactory.GetFont("Verdana", 12, Font.BOLD, preto);
            float[] sizes = new float[] { 1f, 3f, 1f };

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin);
            table.SetWidths(sizes);

            #region Logo Empresa
            //Image foot;
            //if (File.Exists(BasePath + @"\PublicResources\" + PageSubLogo))
            //{
            //    foot = Image.GetInstance(BasePath + @"\PublicResources\" + PageSubLogo);
            //}
            //else
            //{
            //    foot = Image.GetInstance(BasePath + @"\Content\tne_mascote.png");
            //}
            //foot.ScalePercent(60);

            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.BorderWidthBottom = 1.5f;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            PdfPTable micros = new PdfPTable(1);

            cell = new PdfPCell(new Phrase(Titulo, font));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            micros.AddCell(cell);
            cell = new PdfPCell(new Phrase(Titulo, titulo));
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            micros.AddCell(cell);

            cell = new PdfPCell(micros);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.BorderWidthBottom = 1.5f;
            cell.PaddingTop = 10f;
            table.AddCell(cell);
            #endregion

            #region Página

            cell = new PdfPCell(micros);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            cell.BorderWidthTop = 1.5f;
            cell.BorderWidthBottom = 1.5f;
            cell.PaddingTop = 10f;
            table.AddCell(cell);
            #endregion

            table.WriteSelectedRows(0, -1, doc.LeftMargin, (doc.PageSize.Height - 10), writer.DirectContent);

        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
}