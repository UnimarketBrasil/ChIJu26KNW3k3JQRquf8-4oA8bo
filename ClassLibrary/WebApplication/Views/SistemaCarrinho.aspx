<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SistemaCarrinho.aspx.cs" Inherits="WebApplication.SistemaCarrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <h2 class="text-uppercase"><strong>Carrinho de compra</strong></h2>
        <div class="row container-fluid">
            <div id="dvMsg" runat="server" role="alert" visible="false">
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </div>
            <div id="dvCarrinhoVazio" runat="server" role="alert" visible="false">
                <asp:Label ID="lbCarrinhoVazio" runat="server">Seu carrinho de compras está vazio...<a onclick="ajudaModal.show('CARRINHO DE COMPRA',8);" class="glyphicon glyphicon-question-sign"></a></asp:Label>
            </div>
            <div id="dvFaltaLogin" runat="server" role="alert" visible="false">
                <asp:Label ID="lbFaltaLogin" runat="server"> Realize login para confirmar o pedido.<a onclick="ajudaModal.show('CARRINHO DE COMPRA',9);" class="glyphicon glyphicon-question-sign"></a></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdCarrinhoDeCompra" ShowFooter="true" OnPageIndexChanging="grdCarrinhoDeCompra_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2 col-sm-2 img-responsive" />
                    <asp:HyperLinkField DataNavigateUrlFields="Nome" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?item=" ItemStyle-CssClass="col-md-4 col-sm-4" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-2">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Quantidade"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantidade" TextMode="Number" runat="server" Text='<% #Bind("Quantidade") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2 col-sm-1" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-2">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTotal" Text="total"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-2">
                        <ItemTemplate>
                            <asp:LinkButton ForeColor="Red" ID="lnkExcluir" OnCommand="lnkExcluir_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server"><span aria-hidden="true" class="glyphicon glyphicon-trash"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                        <FooterTemplate>
                            <asp:Label runat="server" Text="Total: R$"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
        <div class="row container-fluid">
             <asp:LinkButton runat="server" ID="lkContinuarCOmprando" Text="Continuar Comprando" CssClass="btn btn-default pull-left" PostBackUrl="~/Views/Sistema.aspx" />
            <asp:Button runat="server" ID="btConfirmarPedido" Text="Confirmar Pedido" CssClass="btn btn-success pull-right" OnClick="btConfirmarPedido_Click" Visible="false"/>
        </div>
    </form>
</asp:Content>
