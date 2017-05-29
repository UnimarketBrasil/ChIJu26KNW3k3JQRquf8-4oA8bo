<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="ComprarPedido.aspx.cs" Inherits="WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><strong>MEUS PEDIDOS</strong><a onclick="ajudaModal.show('MEUS PEDIDOS',6);" class='glyphicon glyphicon-question-sign small' style="color: #2780e3"></a></h2>
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
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-CssClass="col-sm-1" />
                    <asp:BoundField DataField="Data" HeaderText="Data e Hora do Pedido" ItemStyle-CssClass="col-sm-2" />
                    <asp:BoundField DataField="Vendedor.Nome" HeaderText="Vendedor" ItemStyle-CssClass="col-sm-3" />
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Status"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbStatus" Text='<%# Bind("StatusPedido.Nome") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-CssClass="col-sm-2" />
                    <asp:TemplateField ItemStyle-CssClass="col-sm-2">
                        <ItemTemplate>
                            <asp:LinkButton ID="detalhePedido" CssClass="btn btn-primary btn-xs" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/Views/SistemaDetalheItem.aspx")%>' Text="Detalhes" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-sm-1">
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
    <!--Script-->
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>

    <script src='http://code.jquery.com/jquery-2.1.3.min.js'></script>
    <script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js'></script>
    <script type="text/javascript" src="../../Scripts/ajudamodal.js"></script>
</asp:Content>
