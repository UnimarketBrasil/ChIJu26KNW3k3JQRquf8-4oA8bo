<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SistemaErro.aspx.cs" Inherits="WebApplication.SistemaErro" %>

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
        <div class="jumbotron">
            <h1>UNIMARKET Brasil</h1>
            <p>Não foi possível atender sua solicitação, tente novamente mais tarde.</p>
            <p><asp:Button ID="btErro" runat="server" CssClass="btn btn-primary btn-lg" draggable="false" Text="Página inicial" OnClick="btErro_Click" /></p>
        </div>
    </form>

</body>
</html>
