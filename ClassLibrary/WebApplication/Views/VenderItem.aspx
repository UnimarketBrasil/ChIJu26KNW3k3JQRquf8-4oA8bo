<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderItem.aspx.cs" Inherits="WebApplication.SistemaHomeVendedor" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Meus Itens</strong></h2>
    <hr />
    <form runat="server">
        <div class="container">
            <div class="tab-pane fade active in" id="produtos">
                <div class="form-group">
                    <a href="VenderDetalheItem.aspx" class="col-lg-2 control-label btn btn-success"><strong>+</strong>Novo Item</a>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-7">
                        <input type="text" class="form-control" id="inputproduto" placeholder="Código ou Nome do Item">
                    </div>
                    <div class="col-lg-1">
                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div>
                <asp:GridView ID="grdDetalheVendedor" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" Visible="false" />
                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2" />
                        <asp:HyperLinkField DataNavigateUrlFields="Nome" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?item=" ItemStyle-CssClass="col-md-4" />
                        <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
