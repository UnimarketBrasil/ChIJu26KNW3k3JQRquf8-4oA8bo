<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderDetalheItem.aspx.cs" Inherits="WebApplication.SistemaNovoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Novo Produto</h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-6 col-sm-2 col-md-2 col-lg-2 form-group">
                    <label for="iputnome">Imagem do Item</label>
                    <a href="#" class="thumbnail">
                        <img src="Style/images/work-img1.jpg" />
                    </a>
                    <a href="#">
                        <input type="file" id="inputimagem" class="form-group" />
                    </a>
                </div>
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7 form-group">
                    <label for="iputnome">Nome do Item</label>
                    <input type="text" id="inputnome" class="form-control" maxlength="120" />
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 form-group">
                    <label for="inputcodigo">Código do Item</label>
                    <input type="text" id="inputcodigo" class="form-control" maxlength="20" />
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
                    <label for="selectcategoria">Categoria</label>
                    <select class="form-control" id="select">
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                    </select>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3 form-group">
                    <label for="inputquantidade">Quantidade</label>
                    <div class="input-group">
                        <input type="text" class="form-control" id="inputquantidade" maxlength="14" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                    <label for="inputvalorunitario">Valor Unitário</label>
                    <div class="input-group">
                        <input type="text" class="form-control" id="inputvalorunitario" maxlength="14" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                    <label for="selectcategoria">Descrição</label>
                    <div class="input-group">
                        <textarea id="inputdescricao" cols="127" rows="3" maxlength="800" style="resize: none; width: 100%"></textarea>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                    <label for="inputvalortotal">Valor Total</label>
                    <div class="input-group">
                        <input type="text" class="form-control" id="inputvalortotal" maxlength="14" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                <button type="reset" class="btn btn-danger">
                    <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                </button>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                <button type="reset" class="btn btn-default">Cancelar</button>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                <button type="submit" class="btn btn-primary">Salvar</button>
            </div>
        </div>
    </div>
</asp:Content>
