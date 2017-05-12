<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderDetalheItem.aspx.cs" Inherits="WebApplication.SistemaNovoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap-fileinput.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
        <div class="panel panel-default">
            <div id="dvHeadNovo" runat="server" class="panel-heading">
                <h4>Novo Produto</h4>
            </div>
            <div id="dvHeadAlterar" runat="server" class="panel-heading">
                <h4>Alterar Produto</h4>
            </div>
            <div class="panel-body">
                <form runat="server">
                    <div class="row">
                        <div class="col-xs-6 col-sm-2 col-md-2 col-lg-2 form-group">
                            <label for="iputnome">Imagem do Item</label>
                            <div class="col-md-4 col-sm-6">
                                <div class="form-group">
                                    <asp:Image ID="imItem" class="img-responsive" runat="server" />
                                </div>
                            </div>
                            <div>
                                <asp:FileUpload ID="InputFoto" CssClass="file" runat="server" />
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7 form-group">
                            <label for="<%=txtNome.ClientID%>">Nome do Item</label>
                            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Nome do Produto" required="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 form-group">
                            <label for="<%=txtCod.ClientID%>">Código do Item</label>
                            <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" placeholder="Cód" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="form-group">Informações do Item</h4>
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-7 col-lg-7 form-group">
                            <label for="<%=dpCategoria.ClientID%>">Categoria</label>
                            <asp:DropDownList ID="dpCategoria" runat="server" CssClass="form-control" DataTextField="Nome" DataValueField="Id" />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3 form-group">
                            <label for="<%=txtQuantidade.ClientID %>">Quantidade</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtQuantidade" CssClass="form-control" placeholder="Quantidade" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                            <label for="<%=txtValorUnitario.ClientID%>">Valor Unitário</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtValorUnitario" CssClass="form-control" placeholder="Valor Unitário" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                            <label for="<%=txtDescricao.ClientID%>">Descrição</label>
                            <div class="input-group">
                                <textarea runat="server" id="txtDescricao" cols="127" rows="3" maxlength="800" style="resize: none; width: 100%"></textarea>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                            <label for="<%=lbValorTotal.ClientID%>">Valor Total</label>
                            <div class="input-group">
                                <asp:Label runat="server" ID="lbValorTotal" CssClass="form-control" Text="Valor Total"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div id="dvExcluirItem" runat="server" class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                                <asp:LinkButton ID="btnLixeira" runat="server" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <button type="reset" class="btn btn-default">Cancelar</button>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <asp:Button runat="server" ID="btSalvarrItem" Text="Salvar" CssClass="btn btn-primary" OnClick="bt_CadastrarItem"></asp:Button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
