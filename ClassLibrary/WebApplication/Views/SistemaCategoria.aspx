<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaCategoria.aspx.cs" Inherits="WebApplication.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="row container-fluid">
            <div id="divMsg" runat="server" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <strong class="glyphicon glyphicon-info-sign"></strong>
                <asp:Label ID="msgPesquisa" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdItens" CssClass="table table-hover table-striped" GridLines="None" runat="server" OnPageIndexChanging="grdItens_PageIndexChanging" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="col-md-2" Visible="false" />
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="80" ControlStyle-Height="80" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Nome" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?id={0}" ItemStyle-CssClass="col-md-2" />
                    <asp:BoundField DataField="Vendedor.Nome" HeaderText="Vendedor" ItemStyle-CssClass="col-md-2" />
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Preço" ItemStyle-CssClass="col-md-2" />
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>
