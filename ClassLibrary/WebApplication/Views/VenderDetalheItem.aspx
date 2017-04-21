<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderDetalheItem.aspx.cs" Inherits="WebApplication.SistemaNovoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Novo Produto</h4>
            </div>
            <div class="panel-body">
                <form runat="server">
                    <div class="row">
                        <div class="col-xs-6 col-sm-2 col-md-2 col-lg-2 form-group">
                            <label for="iputnome">Imagem do Item</label>
                            <a href="#" class="thumbnail">
                                <img src="Style/images/work-img1.jpg" />
                            </a>
                            <a href="#">
                                <asp:FileUpload ID="InputFoto" runat="server" />
                            </a>
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
                            <asp:DropDownList ID="dpCategoria" runat="server" CssClass="form-control">
                                <asp:ListItem Text="banana"> </asp:ListItem>
                            </asp:DropDownList>
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
                            <label for="<%=txtValorTotal.ClientID%>">Valor Total</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtValorTotal" CssClass="form-control" placeholder="Valor Total" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                                <asp:Button runat="server" CssClass="btn btn-danger glyphicon glyphicon-trash"></asp:Button>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <button type="reset" class="btn btn-default">Cancelar</button>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <button type="submit" class="btn btn-primary">Salvar</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
