<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" Inherits="WebApplication.Sistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container">
            <div class="">
                <h1 class="text-uppercase"><strong>Seja bem vindo!</strong></h1>
                <div id="dvMsg" runat="server" role="alert" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong class="glyphicon glyphicon-info-sign"></strong>
                    <asp:Label ID="lbMsg" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div role="main" class="col-sm-8">
                    <div id="Banner" class="carousel slide" data-ride="carousel" style="width: 400px; margin: 0 auto">
                        <!-- Banner Rotativo -->
                        <ol class="carousel-indicators">
                            <li data-target="#Banner" data-slide-to="0" class="active"></li>
                            <li data-target="#Banner" data-slide-to="1"></li>
                            <li data-target="#Banner" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <div class="item active">
                                <asp:Image ID="imgTop1" runat="server" CssClass="img-responsive" width="100%"/>
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop1"><asp:Label runat="server" ID="nomeItem1"></asp:Label></a></h3>
                                    <p><asp:Label runat="server" ID="precoItem1"></asp:Label></p>
                                </div>
                            </div>

                            <div class="item">
                                <asp:Image ID="imgTop2" runat="server" CssClass="img-responsive" width="100%"/>
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop2"><asp:Label runat="server" ID="nomeItem2"></asp:Label></a></h3>
                                    <p><asp:Label runat="server" ID="precoItem2"></asp:Label></p>
                                </div>
                            </div>

                            <div class="item">
                                <asp:Image ID="imgTop3" runat="server" CssClass="img-responsive" width="100%"/>
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop3"><asp:Label runat="server" ID="nomeItem3"></asp:Label></a></h3>
                                    <p><asp:Label runat="server" ID="precoItem3"></asp:Label></p>
                                </div>
                            </div>

                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#Banner" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#Banner" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
                <aside runat="server" id="sdLogin" role="complementary" class="col-sm-4">
                    <h2 class="text-uppercase"><strong>Login</strong></h2>
                    <div id="dvPrimeiraEtapa" class="row" runat="server">
                        <div class="form-group">
                            <label for="txtEmail" class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoCompleteType="Email" placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtSenha" class="col-sm-2 control-label">Senha</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10 col-sm-offset-2">
                                <asp:Label runat="server">Ainda não possui cadastro? <a href="SistemaCadastrar.aspx">Crie uma conta!</a></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10 col-sm-offset-2">
                                <div>
                                    <asp:Button ID="btLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </form>
</asp:Content>
