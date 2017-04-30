<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderItem.aspx.cs" Inherits="WebApplication.SistemaHomeVendedor" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="itens" runat="server">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#produtos" data-toggle="tab" aria-expanded="true">Itens</a></li>
        </ul>
        <div id="mytabcontent" class="tab-content">
            <div class="tab-pane fade active in" id="produtos">
                <div class="form-group">
                    <a href="VenderDetalheItem.aspx" class="col-lg-2 control-label btn btn-success"><strong>+</strong>Novo Item</a>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-7">
                        <input type="text" class="form-control" id="inputproduto" placeholder="Código ou!">
                    </div>
                    <div class="col-lg-1">
                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                    </div>
                </div>
                <asp:GridView ID="grdDetalheVendedor" class="table table-striped table-hover " runat="server" AutoGenerateColumns="false" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-Width="100" />
                        <asp:BoundField DataField="Nome" HeaderText="Produto" ItemStyle-Width="100" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ItemStyle-Width="100" />
                        <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ItemStyle-Width="100" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </section>
</asp:Content>
