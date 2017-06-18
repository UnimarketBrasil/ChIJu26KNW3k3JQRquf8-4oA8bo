<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderPedido.aspx.cs" Inherits="WebApplication.SistemaListaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><strong>MEUS PEDIDOS</strong><a onclick="ajudaModal.show('MEUS PEDIDOS',7);" class='glyphicon glyphicon-question-sign small' style="color: #2780e3"></a></h2>
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
        <div class="row container-fluid table-responsive"">
            <asp:GridView ID="grdPedido" OnRowDataBound="grdPedido_RowDataBound" OnPageIndexChanging="grdPedido_PageIndexChanging" CssClass="table table-hover table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-CssClass="col-sm-1" />
                    <asp:BoundField DataField="Data" HeaderText="Data e Hora do Pedido" ItemStyle-CssClass="col-sm-2" />
                    <asp:BoundField DataField="Comprador.Nome" HeaderText="Comprador" ItemStyle-CssClass="ol-sm-3" />
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Status"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbStatus" Text='<%# Bind("StatusPedido.Nome") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-CssClass="col-sm-1" />
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <ItemTemplate>
                            <asp:LinkButton ID="detalhePedido" CssClass="btn btn-primary btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/Vendedor/DetalhePedido.aspx?idPedido=") + DataBinder.Eval(Container.DataItem, "Id" )%>'  Text="Detalhes" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <ItemTemplate>
                            <asp:Button ID="btfinalizar" CssClass="btn btn-success btn-xs" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' OnCommand="btfinalizar_Command" Text="Finalizar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <ItemTemplate>
                            <asp:Button ID="btcancelar" CssClass="btn btn-danger btn-xs" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' OnCommand="btcancelar_Command" Text="Cancelar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <ItemTemplate>
                            <asp:LinkButton ID="pdfPedido" CssClass="btn btn-info btn-xs" OnCommand="pdfPedido_Command" runat="server" CommandName="Pedido" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' Text="PDF"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>
