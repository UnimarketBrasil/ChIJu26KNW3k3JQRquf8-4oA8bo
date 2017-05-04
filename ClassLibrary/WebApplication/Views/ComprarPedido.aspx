<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="ComprarPedido.aspx.cs" Inherits="WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="nav nav-tabs">
        <li class="active"><a href="#todos" data-toggle="tab" aria-expanded="true">Todos</a></li>
        <li class=""><a href="#pendentes" data-toggle="tab" aria-expanded="true">Pendêntes</a></li>
    </ul>
    <div id="myTabContent" class="tab-content">
        <div class="tab-pane fade active in" id="todos">
            <p>Todos</p>
        </div>
        <div class="tab-pane fade " id="pendentes">
            <p>Pendêntes</p>
        </div>
    </div>
</asp:Content>
