using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ClassUtilitario.Pdf
{
    public class Pdf
    {
        protected Document doc;
        PdfWriter writer;
        MemoryStream output;

        public string PageTitle { get; set; }

        public string PageSubTitle { get; set; }

        public string PageSubLogo { get; set; }

        public string BasePath { get; set; }

        public MemoryStream GetOutput()
        {
            MontaCorpoDados();

            if (output == null || output.Length == 0)
            {
                throw new Exception("Sem dados para exibir.");
            }

            try
            {
                writer.Flush();

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

        public virtual void MontaCorpoDados<T>(T Lista)
        {                     
            doc = new Document(PageSize.A4, 20, 10, 80, 40);          
            
            output = new MemoryStream();
            writer = PdfWriter.GetInstance(doc, output);

            doc.AddAuthor("UNIMARKET Brasil");
            doc.AddTitle(PageTitle);
            doc.AddSubject(PageTitle);

            var footer = new MSPDFFooter();
            footer.PageTitle = PageTitle;
            footer.PageSubTitle = PageSubTitle;
            footer.BasePath = BasePath;

            writer.PageEvent = footer;

            doc.Open();

            return;
        }

        protected PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento, float Espacamento, int Borda, BaseColor CorBorda, BaseColor CorFundo)
        {
            var cell = new PdfPCell(new Phrase(Texto, Fonte));
            cell.HorizontalAlignment = Alinhamento;
            cell.Padding = Espacamento;
            cell.Border = Borda;
            cell.BorderColor = CorBorda;
            cell.BackgroundColor = CorFundo;

            return cell;
        }

        protected PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento, float Espacamento, int Borda, BaseColor CorBorda)
        {
            return getNewCell(Texto, Fonte, Alinhamento, Espacamento, Borda, CorBorda, new BaseColor(255, 255, 255));
        }
        protected PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento = 0, float Espacamento = 5, int Borda = 0)
        {
            return getNewCell(Texto, Fonte, Alinhamento, Espacamento, Borda, new BaseColor(0, 0, 0), new BaseColor(255, 255, 255));
        }
    }
}
