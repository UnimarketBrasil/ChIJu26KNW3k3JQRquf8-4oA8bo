<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaCarrinho.aspx.cs" Inherits="WebApplication.SistemaCarrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Carrinho de compra</strong></h2>
    <form runat="server">
        <div class="row container-fluid">
            <div id="divMsg" runat="server" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdCarrinhoDeCompra" OnPageIndexChanging="grdCarrinhoDeCompra_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" Visible="false" />
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2" />
                    <asp:HyperLinkField DataNavigateUrlFields="Nome" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?item=" ItemStyle-CssClass="col-md-4" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Quantidade"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ItemStyle-CssClass="col-md-2" ID="txtQuantidade" TextMode="Number" runat="server" Text='<% #Bind("Quantidade") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-1">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTotal" Text="total"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ForeColor="Red" ID="lnkExcluir" OnCommand="lnkExcluir_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'  runat="server"><span aria-hidden="true" class="glyphicon glyphicon-trash"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>
