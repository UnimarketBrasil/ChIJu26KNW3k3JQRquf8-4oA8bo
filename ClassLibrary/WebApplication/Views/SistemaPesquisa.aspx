<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaPesquisa.aspx.cs" Inherits="WebApplication.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <form runat="server">
            <asp:GridView ID="lbItens" CssClass="table table-hover table-bordered" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Nome" HeaderText="Produto" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Preço por Unidade" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Usuario.Nome" HeaderText="Vendedor" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>
