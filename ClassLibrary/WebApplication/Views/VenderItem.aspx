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
                    <a href="SistemaNovoItem.aspx" class="col-lg-2 control-label btn btn-success"><strong>+</strong>Novo Item</a>
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-7">
                        <input type="text" class="form-control" id="inputproduto" placeholder="Código ou!">
                    </div>
                    <div class="col-lg-1">
                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                    </div>
                </div>
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Nome</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>1</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td><a href="#" class="btn btn-warning btn-xs">Alterar</a> &nbsp;<a href="#" class="btn btn-danger btn-xs"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></a></td>
                        </tr>
                        <tr class="active">
                            <td>4</td>
                            <td>Column contant</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </section>
</asp:Content>
