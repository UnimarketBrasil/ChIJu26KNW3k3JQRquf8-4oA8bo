<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminListar.aspx.cs" Inherits="WebApplication.AdminListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Usuarios Cadastrados</strong></h2>
    <hr />
    <form runat="server">
        <div class="container-fluid">
            <p>&nbsp;</p>
            <div class="row">
                <asp:GridView ID="grdAdmin" OnPageIndexChanging="grdAdmin_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="TipoUsuario.Nome" HeaderText="Tipo Usuario" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="StatusUsuario.Nome" HeaderText="Status do Usuario" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2" />
                    </Columns>
                    <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                    <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
