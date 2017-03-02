<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SistemaCadastrar.aspx.cs" Inherits="WebApplication.SistemaCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Sessão Cadastar-->
    <section id="cadastrar" class="bg-blue roomy-70">
        <div class="row">
            <div>
                <div class="col-md-6" style="margin-top:75px">
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="height: 368px; width: 550px">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">
                                <img src="Style/images/about-img1.jpg" />
                            </div>
                            <div class="item">
                                <img src="Style/images/about-img1.jpg" />
                            </div>
                            <div class="item">
                                <img src="Style/images/about-img1.jpg" />
                            </div>
                        </div>

                        <!-- Controls -->
                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="sm-m-top-50">
                        <h2 class="text-uppercase"><strong>Cadastre-se</strong></h2>
                        <form class="form-horizontal">
                            <fieldset>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label"></label>
                                    <div class="col-lg-10">
                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="optionsRadios" id="optionsRadiosComprar" value="option1" checked="">
                                                Comprar
                                            </label>
                                            <label>
                                                <input type="radio" name="optionsRadios" id="optionsRadiosVender" value="option2">
                                                Vender
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCpfCnpj" class="col-lg-2 control-label">CPF/CNPJ</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputCpfCnpj" placeholder="CPF/CNPJ" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputNome" class="col-lg-2 control-label">Nome</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputNome" placeholder="Nome" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputDataNasc" class="col-lg-2 control-label">Data de Nasc.</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputDataNasc" placeholder="dd/mm/aaaa" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputEmail" placeholder="Email">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputEmailConf" class="col-lg-2 control-label">Confirmar Email</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputEmailConf" placeholder="Confirmar Email">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputTel" class="col-lg-2 control-label">Telefone</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputTel" placeholder="Telefone" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputSenha" class="col-lg-2 control-label">Senha</label>
                                    <div class="col-lg-10">
                                        <input type="password" class="form-control" id="inputSenha" placeholder="Senha">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputSenhaConf" class="col-lg-2 control-label">Confirmar Senha</label>
                                    <div class="col-lg-10">
                                        <input type="password" class="form-control" id="inputSenhaConf" placeholder="Confirmar Senha">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <div class="checkbox">
                                            <script src='https://www.google.com/recaptcha/api.js'></script>
                                            <div class="g-recaptcha" data-sitekey="6Lc-HRcUAAAAAG-oWXYAcgOnqXQ7TEHGEESB_PiZ"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <div>
                                            <button type="button" id="myButton" data-loading-text="Loading..." class="btn btn-primary">
                                                Cadastrar!
                                            </button>
                                            <script>
                                                $('#myButton').on('click', function () {
                                                    var $btn = $(this).button('loading')
                                                    //$btn.button('reset')
                                                })
                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </form>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
