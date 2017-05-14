<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDetalheUsuario.aspx.cs" Inherits="WebApplication.AdminDetalheUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading text-center">
                    <asp:Label runat="server" ID="lbNomeProduto" Text="Dados do Usuário"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="container-fluid">
                        <div runat="server" id="dvPessoaJuridica">
                            <div class="row">
                                <div class="col-xs-4 form-group">
                                    <asp:Label runat="server" Text="CNPJ:"></asp:Label>
                                    <asp:Label runat="server" ID="lbCnpj" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-xs-8 form-group">
                                    <asp:Label runat="server" Text="Razão Social:"></asp:Label>
                                    <asp:Label runat="server" ID="lbRazao" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="dvPessoaFisica">
                            <div class="row">
                                <div class="col-xs-4 form-group">
                                    <asp:Label runat="server" Text="CPF:"></asp:Label>
                                    <asp:Label runat="server" ID="lbCpf" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-xs-8 form-group">
                                    <asp:Label runat="server" Text="Nome:"></asp:Label>
                                    <asp:Label runat="server" ID="lbNome" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3 form-group">
                                    <asp:Label runat="server" Text="Data de Nascimento:"></asp:Label>
                                    <asp:Label runat="server" ID="lbDtNasc" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-xs-4 form-group">
                                    <asp:Label runat="server" Text="Genero:"></asp:Label>
                                    <asp:Label runat="server" ID="lbGenero" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="col-xs-5 form-group">
                                    <asp:Label runat="server" Text="E-mail:"></asp:Label>
                                    <asp:Label runat="server" ID="lbEmail" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 form-group">
                                <asp:Label runat="server" Text="Telefone:"></asp:Label>
                                <asp:Label runat="server" ID="lbTelefone" CssClass="form-control"></asp:Label>
                            </div>
                            <div class="col-xs-4 form-group">
                                <asp:Label runat="server" Text="Tipo de Usuário:"></asp:Label>
                                <asp:Label runat="server" ID="lbTipoUsuario" CssClass="form-control"></asp:Label>
                            </div>
                            <div class="col-xs-4 form-group">
                                <asp:Label runat="server" Text="Status do Usuário:"></asp:Label>
                                <asp:Label runat="server" ID="lbStatusUsuario" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 form-group">
                                <asp:Label runat="server" Text="Endereço:"></asp:Label>
                                <asp:Label runat="server" ID="lbEndereco" CssClass="form-control"></asp:Label>
                            </div>
                            <div class="col-xs-4 form-group">
                                <asp:Label runat="server" Text="Complemento:"></asp:Label>
                                <asp:Label runat="server" ID="lbComplemento" CssClass="form-control"></asp:Label>
                            </div>
                            <div class="col-xs-2 form-group">
                                <asp:Label runat="server" Text="Área de atuação:"></asp:Label>
                                <asp:Label runat="server" ID="lbAreaAtuacao" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 form-group">
                                <asp:Label runat="server" Text="Data/Hora do cadastro:"></asp:Label>
                                <asp:Label runat="server" ID="lbDataCadastro" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 form-group">
                                <ul class="list-group">
                                    <li class="list-group-item">
                                        <span class="badge">
                                            <asp:Label runat="server" ID="lbItensCadastrados"></asp:Label></span>
                                        Itens Cadastrados
                                    </li>
                                    <li class="list-group-item">
                                        <span class="badge">
                                            <asp:Label runat="server" ID="lbPedidosPendentes"></asp:Label></span>
                                        Pedidos Pendentes
                                    </li>
                                    <li class="list-group-item">
                                        <span class="badge">
                                            <asp:Label runat="server" ID="lbPedidosFinalizados"></asp:Label></span>
                                        Pedidos Finalizados
                                    </li>
                                    <li class="list-group-item">
                                        <span class="badge">
                                            <asp:Label runat="server" ID="lbPedidosCancelados"></asp:Label></span>
                                        Pedidos Cancelados
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="row">
                            Histórioco de mensagens:
                        </div>
                        <div class="row">
                            SubUsuários::
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
