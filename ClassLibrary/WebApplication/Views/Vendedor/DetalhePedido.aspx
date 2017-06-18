<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="DetalhePedido.aspx.cs" Inherits="WebApplication.DetalhePedidoVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="panel panel-default">
            <div class="panel-heading text-center">
                <asp:Label runat="server" ID="lbNumPedido" Text="Pedido:"></asp:Label>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Comprador:"></asp:Label>
                            <asp:Label runat="server" ID="lbComprador" Text="" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group well well-sm">
                            <asp:Label runat="server" Text="Valor Total: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbValorTotal" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Status:"></asp:Label>
                            <asp:Label runat="server" ID="lbStatus" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Endereço:"></asp:Label>
                            <asp:Label runat="server" ID="lbEndereco" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Número/Complemento:"></asp:Label>
                            <asp:Label runat="server" ID="lbNumComplemento" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Telefone:"></asp:Label>
                            <asp:Label runat="server" ID="lbTelefone" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="E-mail:"></asp:Label>
                            <asp:Label runat="server" ID="lbEmailComprador" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <asp:GridView ID="grdItens" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="300" Visible="false" />
                            <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="80" ControlStyle-Height="80" />
                            <asp:BoundField DataField="Nome" HeaderText="Total" ItemStyle-Width="300" />
                            <asp:BoundField DataField="ValorUnitario" HeaderText="Preço" ItemStyle-Width="300" />
                            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ItemStyle-Width="300" />
                            <asp:BoundField DataField="ValorTotal" HeaderText="Total" ItemStyle-Width="300" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <asp:LinkButton ID="btVoltar" runat="server" CssClass="btn btn-default pull-right" OnClientClick="javascript:window.history.go(-1);"><span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
