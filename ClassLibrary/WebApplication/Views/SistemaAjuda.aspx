<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SistemaAjuda.aspx.cs" Inherits="WebApplication.Views.SistemaAjuda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.cosmo.css" rel="stylesheet" />
    <link href="../Content/bootstrap.cosmo.min.css" rel="stylesheet" />
    <title>Unimarket Brasil</title>
</head>
<body>
    <form runat="server">
        <div class="jumbotron" style="position: fixed">
            <h1>UNIMARKET Brasil</h1>
            <p>Como podemos ajudar você...</p>
        </div>
        <div class="jumbotron">
            <h1>Uni</h1>
            <p>com</p>
        </div>
        <div runat="server" id="dvAjuda" class="panel panel-default container">
            <div class="panel-heading">
                <asp:Label runat="server" ID="lbAjudaCabecalho"></asp:Label>
            </div>
            <div class="panel-body">
                <asp:Label runat="server" ID="lbAjudaCorpo"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

