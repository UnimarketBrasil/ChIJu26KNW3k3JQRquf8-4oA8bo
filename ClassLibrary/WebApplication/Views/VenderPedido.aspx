<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderPedido.aspx.cs" Inherits="WebApplication.SistemaListaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Meus Pedidos</strong></h2>
    <hr />
    <form runat="server">
        <div class="row container-fluid">
            <asp:BulletedList ID="blTabs" DisplayMode="LinkButton" runat="server" CssClass="nav nav-tabs" OnClick="blTabs_Click">
                <asp:ListItem>Todos</asp:ListItem>
                <asp:ListItem>Pendêntes</asp:ListItem>
                <asp:ListItem>Cancelados</asp:ListItem>
                <asp:ListItem>Finalizados</asp:ListItem>
            </asp:BulletedList>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdPedido" OnPageIndexChanging="grdPedido_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-CssClass="col-md-3" />
                    <asp:BoundField DataField="Comprador.Nome" HeaderText="Comprador" ItemStyle-CssClass="col-md-4" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-CssClass="col-md-2" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2">
                        <ItemTemplate>
                            <asp:LinkButton ID="detalhePedido" CssClass="btn btn-primary btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="Detalhes" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:LinkButton ID="pdfPedido" CssClass="btn btn-success btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="Finalizar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:LinkButton ID="pdfPedido" CssClass="btn btn-danger btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="Cancelar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-md-1">
                        <ItemTemplate>
                            <asp:LinkButton ID="pdfPedido" CssClass="btn btn-info btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="PDF" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>
