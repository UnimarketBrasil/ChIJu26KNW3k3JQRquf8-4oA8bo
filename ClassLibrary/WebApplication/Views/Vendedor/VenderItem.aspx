<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderItem.aspx.cs" Inherits="WebApplication.VenderItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <label class="h2 col-sm-2"><strong>MEUS ITENS</strong></label><a onclick="ajudaModal.show('MEUS ITENS',4);" class='col-sm-1 btn btn-info btn-sm glyphicon glyphicon-question-sign small'>AJUDA</a>
            </div>
            <hr />
            <p>&nbsp;</p>
            <div class="row table-responsive">
                <asp:GridView ID="grdDetalheVendedor" OnPageIndexChanging="grdDetalheVendedor_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" Visible="false" />
                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2" />
                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="VenderDetalheItem.aspx?idItem={0}" ItemStyle-CssClass="col-md-4" />
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
