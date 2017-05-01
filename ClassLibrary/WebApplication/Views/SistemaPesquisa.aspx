<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaPesquisa.aspx.cs" Inherits="WebApplication.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="divMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong class="glyphicon glyphicon-info-sign"></strong>
            <asp:Label ID="msgPesquisa" runat="server"></asp:Label>
        </div>
        <div>
            <form runat="server">
                <asp:GridView ID="lbItens" class="table table-striped table-hover " runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="300" />
                        <asp:BoundField DataField="Nome" HeaderText="Produto" ItemStyle-Width="300" />
                        <asp:BoundField DataField="ValorUnitario" HeaderText="Preço por Unidade" ItemStyle-Width="300" />
                        <asp:BoundField DataField="Usuario.Nome" HeaderText="Vendedor" ItemStyle-Width="300" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="verDetalheProduto" CssClass="btn btn-primary btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="Ver Detalhes" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
