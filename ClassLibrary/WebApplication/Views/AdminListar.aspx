<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminListar.aspx.cs" Inherits="WebApplication.AdminListar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Usuarios Cadastrados</strong></h2>
    <hr />
    <form runat="server">
        <div class="container-fluid">
            <p>&nbsp;</p>
            <div class="row">
                <asp:GridView ID="grdAdmin" OnRowDataBound="grdAdmin_RowDataBound" OnPageIndexChanging="grdAdmin_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-CssClass="col-xs-4" />
                        <asp:HyperLinkField DataNavigateUrlFields="Id" HeaderText="Nome/Razão Social" DataTextField="Nome" ItemStyle-CssClass="col-xs-4" DataNavigateUrlFormatString="AdminDetalheUsuario.aspx?idUsuario={0}" />
                        <asp:BoundField DataField="TipoUsuario.Nome" HeaderText="Tipo Usuario" ItemStyle-CssClass="col-xs-2" />
                        <asp:BoundField  DataField="StatusUsuario.Nome" HeaderText="Status do Usuario" ItemStyle-CssClass="col-xs-1" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btStatus" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StatusUsuario.Nome")  +", "+ DataBinder.Eval(Container.DataItem, "Id") %>' OnCommand="btStatus_Command" CommandName="Detail" ControlStyle-CssClass="col-xs-1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                    <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
