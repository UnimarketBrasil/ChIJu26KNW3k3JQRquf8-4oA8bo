<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SistemaConcluirCadastro.aspx.cs" Inherits="WebApplication.SistemaConcluirCadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GoogleMapsAPI.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Sessão Localização-->
    <section id="login" class="bg-blue roomy-70">
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="form-controle col-md-10">
                <div class="sm-m-top-70">
                    <h2 class="text-uppercase"><strong>Sua Localização</strong></h2>
                    <form class="form-horizontal form-group">
                        <fieldset>
                            <div class="form-group">
                                <div class="col-lg-7">
                                    <input id="address" class="form-control" type="search" placeholder="Curitiba, Paraná">
                                </div>
                                <input id="submit" class="btn btn-primary col-lg-2" type="button" value="Localizar">
                            </div>
                            <div id="RaioVender" class="form-group" runat="server">
                                <label for="inputRaio" class="col-lg-7">
                                    <h4>Distância máxima para entrega</h4>
                                </label>
                                <div class="col-lg-2">
                                    <select class="form-control" id="inputRaio">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                    </select>
                                </div>
                            </div>
                            <div id="map" style="width: 775px; height: 500px;"></div>
                            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAErShX6RRNkCAj2d3E9bxaEEGKSpIHZ1A&callback=initMap"
                                async defer></script>
                        </fieldset>
                    </form>
                </div>
            </div>
            <div class="col-md-2">
            </div>
        </div>
        <div class="col-lg-9 text-right">
            <a href="#" class="btn btn-primary">Concluir</a>
        </div>
    </section>
</asp:Content>
