<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pinta-ficha.aspx.cs" Inherits="Curso.HTML.WebApplication1.pinta_ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Demo | Pinta Ficha</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Ficha del cliente</h1>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <p><b>Identificador:</b> <%=Cliente.ID %></p>
                    <p><b>Empresa:</b> <%=Cliente.Empresa %></p>
                    <p><b>Contacto:</b> <%=Cliente.Contacto %> (<%=Cliente.Cargo %>)</p>
                  
                    <br />
                    <p><b>Direccion:</b> <%=Cliente.Direccion %></p>
                    <p><b>País:</b> <%=Cliente.Pais %></p>
                    <p><b>Provincia:</b> <%=Cliente.Provincia %></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
