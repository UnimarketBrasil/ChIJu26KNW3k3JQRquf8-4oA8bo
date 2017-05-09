<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaDetalheItem.aspx.cs" Inherits="WebApplication.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" oninput="calc_total();">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading text-center">
                <asp:Label runat="server" ID="lbNomeProduto" Text="Nome Do Seu Produto"></asp:Label>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Image ID="imProduto" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group well well-sm">
                            <asp:Label runat="server" Text="Preço: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbValorUnitario" Text="R$ 190.00"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Quantidade:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantidade" TextMode="Number" MaxLength="1" Text="1" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Total: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbTotal" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton ID="btnLixeira" runat="server" CssClass="btn btn-default"><span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success"><span aria-hidden="true" class="glyphicon glyphicon-plus-sign"></span>&nbsp;COMPRAR</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Vendedor:"></asp:Label>
                            <asp:Label runat="server" ID="lbNomeVendedor" Text="Jão da Silva"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Endereço:"></asp:Label>
                            <asp:Label runat="server" ID="lbEndereco" Text="Rua blá blá"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Telefone:"></asp:Label>
                            <asp:Label runat="server" ID="lbTelefone" Text="(41) 1234-5678"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="E-mail:"></asp:Label>
                            <asp:Label runat="server" ID="lbEmailVendedor" Text="jose@jose.com"></asp:Label>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-8">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lbDescricao" Text="Um produto muito bom"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function calc_total() {
            var qtd = parseInt(document.getElementById('<% Response.Write(txtQuantidade.ClientID); %>').value);
            var preco = parseFloat(document.getElementById('<% Response.Write(lbValorUnitario.ClientID); %>').innerText.replace(",","."));
            var tot = (qtd * preco);
            tot = tot.toFixed(2);
            tot = tot.replace(".", ",");
                document.getElementById('<% Response.Write(lbTotal.ClientID);%>').innerHTML = tot;
        }
	</script>
</asp:Content>
