<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaPesquisa.aspx.cs" Inherits="WebApplication.WebForm4" %>

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
            <asp:GridView ID="lbItens" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="80" ControlStyle-Height="80"/>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="300" Visible="false" />
                    <asp:HyperLinkField DataNavigateUrlFields="Nome" DataTextField="Nome" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?item="/>
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Preço" ItemStyle-Width="300" />
                    <asp:BoundField DataField="Usuario.Nome" HeaderText="Vendedor" ItemStyle-Width="300" />
                    
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
