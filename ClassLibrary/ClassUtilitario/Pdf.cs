using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClassLibrary;

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
                    
                    var endereco = new GeoCodificacao();

                    Usuario u = new Usuario();
                    u.Latitude = pedido.Comprador.Latitude;
                    u.Longitude = pedido.Comprador.Longitude;

                    string e = endereco.ObterEndereco(u);

                    documento.Open();

                    var tbl = new PdfPTable(3);
                    tbl.WidthPercentage = 100f;

                    tbl.AddCell(fCell(pedido.Vendedor.Nome, Element.ALIGN_LEFT));
                    tbl.AddCell(fCell(pedido.Comprador.Nome, Element.ALIGN_LEFT));
                    tbl.AddCell(fCell((e + pedido.Comprador.Numero), Element.ALIGN_LEFT));

                    documento.Add(tbl);


                    var tabela = new PdfPTable(5);
                    float[] colsW = { 5, 20, 5, 5, 5 };
                    tabela.SetWidths(colsW);
                    tabela.HeaderRows = 1;
                    tabela.WidthPercentage = 100f;

                    pedido.Vendedor = new Usuario();
                    var cell = fCell(pedido.Vendedor.Nome, Element.ALIGN_LEFT);
                    cell.Colspan = 5;
                    tabela.AddCell(cell);

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
                    
                    var tabela = new PdfPTable(5);
                    float[] colsW = { 5, 10, 10, 10, 5 };
                    tabela.SetWidths(colsW);
                    tabela.HeaderRows = 1;
                    tabela.WidthPercentage = 100f;

                    tabela.AddCell(tCell("ID", Element.ALIGN_LEFT));
                    tabela.AddCell(tCell("EMAIL", Element.ALIGN_LEFT));
                    tabela.AddCell(tCell("NOME", Element.ALIGN_LEFT));
                    tabela.AddCell(tCell("TIPO", Element.ALIGN_RIGHT));
                    tabela.AddCell(tCell("STATUS", Element.ALIGN_RIGHT));

                    foreach (var user in usuario)
                    {
                        tabela.AddCell(fCell(user.Id.ToString(), Element.ALIGN_LEFT));
                        tabela.AddCell(fCell(user.Email, Element.ALIGN_LEFT));
                        tabela.AddCell(fCell(user.Nome, Element.ALIGN_LEFT));
                        tabela.AddCell(fCell(user.Tipousuario.Nome, Element.ALIGN_RIGHT));
                        tabela.AddCell(fCell(user.StatusUsuario.Nome, Element.ALIGN_RIGHT));
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