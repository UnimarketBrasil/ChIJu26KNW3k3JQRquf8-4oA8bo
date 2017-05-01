<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaRecuperarSenha.aspx.cs" Inherits="WebApplication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <form  runat="server">
            <asp:PasswordRecovery ID="recuperaçãoSenha" runat="server"></asp:PasswordRecovery>
        </form>
    </div>
</asp:Content>
