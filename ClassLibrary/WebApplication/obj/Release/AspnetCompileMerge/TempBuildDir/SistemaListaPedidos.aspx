<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SistemaListaPedidos.aspx.cs" Inherits="WebApplication.SistemaListaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-uppercase"><strong>Meus Pedidos</strong></h2>
    <hr />
    <section id="comprador" runat="server">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#todoscomprador" data-toggle="tab" aria-expanded="true">Todos</a></li>
            <li class=""><a href="#pendentescomprador" data-toggle="tab" aria-expanded="false">Pendêntes</a></li>
            <li class=""><a href="#canceladoscomprador" data-toggle="tab" aria-expanded="false">Cancelados</a></li>
            <li class=""><a href="#finalizadoscomporador" data-toggle="tab" aria-expanded="false">Finalizados</a></li>
        </ul>
        <div id="mytabcontentcomprador" class="tab-content">
            <div class="tab-pane fade active in" id="todoscomprador">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Vendedor</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>1</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>4</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="pendentescomprador">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Vendedor</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>2</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="canceladoscomprador">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Vendedor</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>3</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>5</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>6</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="finalizadoscomporador">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Vendedor</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>7</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </section>
    <section id="vendedor" runat="server">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#todosvendedor" data-toggle="tab" aria-expanded="true">Todos</a></li>
            <li class=""><a href="#pendentesvendedor" data-toggle="tab" aria-expanded="false">Pendêntes</a></li>
            <li class=""><a href="#canceladosvendedor" data-toggle="tab" aria-expanded="false">Cancelados</a></li>
            <li class=""><a href="#finalizadosvendedor" data-toggle="tab" aria-expanded="false">Finalizados</a></li>
        </ul>
        <div id="mytabcontentvendedor" class="tab-content">
            <div class="tab-pane fade active in" id="todosvendedor">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Comprador</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>1</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>4</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="pendentesvendedor">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Comprador</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>2</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="canceladosvendedor">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Comprador</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>3</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>5</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                        <tr class="active">
                            <td>6</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="finalizadosvendedor">
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Cód</th>
                            <th>Comprador</th>
                            <th>Valor</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="active">
                            <td>7</td>
                            <td>Column content</td>
                            <td>Column content</td>
                            <td>Column content</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </section>
</asp:Content>
