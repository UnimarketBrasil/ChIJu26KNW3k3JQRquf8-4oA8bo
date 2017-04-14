<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaLogin.aspx.cs" Inherits="WebApplication.SistemaLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Sessão Login-->
    <section id="login" class="bg-blue roomy-70">
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <div class="sm-m-top-50">
                    <h2 class="text-uppercase"><strong>Login</strong></h2>
                    <form class="form-horizontal">
                        <fieldset>
                            <div class="form-group">
                                <label for="inputEmail" class="col-lg-2 control-label">E-mail</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" id="inputEmail" placeholder="E-mail">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword" class="col-lg-2 control-label">Senha</label>
                                <div class="col-lg-10">
                                    <input type="password" class="form-control" id="inputPassword" placeholder="Senha">
                                    <div class="checkbox">
                                        <button type="submit" class="btn btn-primary">Entrar</button>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </form>
                </div>
            </div>
            <div class="col-md-2">
            </div>
        </div>
    </section>
</asp:Content>
