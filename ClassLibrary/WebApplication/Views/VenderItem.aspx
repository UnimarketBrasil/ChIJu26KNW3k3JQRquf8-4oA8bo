<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderItem.aspx.cs" Inherits="WebApplication.VenderItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Meus Itens</strong></h2>
    <hr />
    <form runat="server">
        <div class="container-fluid">
            <div class="row fade active in" id="produtos">
                <div class="form-group">
                    <a href="VenderDetalheItem.aspx" draggable="false" class="col-lg-2 col-md-2 col-sm-2 col-xs-3 btn btn-success"><strong>+</strong>Novo Item</a>
                    <div class="col-lg-7 col-lg-offset-2 col-md-7 col-md-offset-2 col-sm-7 col-sm-offset-2 col-xs-6">
                        <input type="text" class="form-control" id="inputproduto" placeholder="Código ou Nome do Item">
                    </div>
                    <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1">
                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div class="row">
                <asp:GridView ID="grdDetalheVendedor" OnPageIndexChanging="grdDetalheVendedor_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" Visible="false" />
                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2" />
                        <asp:HyperLinkField DataNavigateUrlFields="Nome" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?item=" ItemStyle-CssClass="col-md-4" />
                        <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                    </Columns>
                    <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                    <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
