using ClassLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilitario
{
    public class PedidoPdf
    {
        Document doc;
        PdfWriter writer;
        MemoryStream output;

        protected virtual void MontarCorpoDados(Pedido pedido)
        {
            doc = new Document(PageSize.A4, 20, 10, 80, 40);
            output = new MemoryStream();
            writer = PdfWriter.GetInstance(doc, output);
            doc.AddAuthor("UNIMARKET Brasil");
            doc.AddTitle("PEDIDO");
            doc.AddSubject("PEDIDO");

            doc.Open();

            PdfPTable tabela = new PdfPTable(5);
            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            Font fonteCorpo = FontFactory.GetFont("Verdana", 8, Font.NORMAL, preto);
            Font fonteTitulo = FontFactory.GetFont("Verdana", 8, Font.BOLD, preto);

            float[] colsW = { 10, 10, 10, 10, 10 };
            tabela.SetWidths(colsW);
            tabela.HeaderRows = 1;
            tabela.WidthPercentage = 100f;

            tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            tabela.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            tabela.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
            tabela.DefaultCell.BackgroundColor = fundo;
            tabela.DefaultCell.BorderColor = preto;
            tabela.DefaultCell.Padding = 10;

            tabela.AddCell(Formataco("Codigo", fonteTitulo));
            tabela.AddCell(Formataco("Item", fonteTitulo));
            tabela.AddCell(Formataco("Quantidade", fonteTitulo));
            tabela.AddCell(Formataco("Valor Unitario", fonteTitulo));
            tabela.AddCell(Formataco("Total Item", fonteTitulo));

            foreach (var dados in pedido.Item)
            {
 
                tabela.AddCell(Formataco(dados.Codigo, fonteCorpo));
                tabela.AddCell(Formataco(dados.Nome, fonteCorpo));
                tabela.AddCell(Formataco(dados.Quantidade.ToString(), fonteCorpo));
                tabela.AddCell(Formataco(dados.ValorUnitario.ToString(), fonteCorpo));
                tabela.AddCell(Formataco((dados.ValorUnitario * dados.Quantidade).ToString(), fonteCorpo));
            }

            doc.Add(tabela);

            return;
        }

        protected PdfPCell Formataco(string Texto, Font fonte)
        {
            var coluna = new PdfPCell(new Phrase(Texto, fonte));

            return coluna;
        }

        protected MemoryStream GetOutput(Pedido pedido)
        {
            MontarCorpoDados(pedido);

            if (output == null || output.Length == 0)
            {
                throw new Exception("Sem dados para exibir.");
            }

            try
            {
                writer.Flush();

                doc.AddHeader("content-disposition", "attachment; filename=Pedido.pdf");

                if (writer.PageEmpty)
                {
                    doc.Add(new Paragraph("Nenhum registro para listar."));
                }

                doc.Close();
            }
            catch { }
            finally
            {
                doc = null;
                writer = null;
            }

            return output;
        }


       // public FileStream getPedido(Pedido pedido)    
        //FileStream arquivo = new FileStream; ("Pedido.pdf",FileMode.Truncate(p.GetOutput(pedido).GetBuffer()) );


    }
}
