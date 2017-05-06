﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="ComprarPedido.aspx.cs" Inherits="WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Meus Pedidos</strong></h2>
    <hr />
    <form runat="server">
        <asp:BulletedList ID="blTabs" DisplayMode="LinkButton" runat="server" CssClass="nav nav-tabs" OnClick="blTabs_Click">
            <asp:ListItem>Todos</asp:ListItem>
            <asp:ListItem>Pendêntes</asp:ListItem>
            <asp:ListItem>Cancelados</asp:ListItem>
            <asp:ListItem>Finalizados</asp:ListItem>
        </asp:BulletedList>
        <asp:GridView ID="grdPedido" class="table table-striped table-hover " runat="server" AutoGenerateColumns="false" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-Width="100" />
                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" ItemStyle-Width="100" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
        <hr />
    </form>
</asp:Content>
