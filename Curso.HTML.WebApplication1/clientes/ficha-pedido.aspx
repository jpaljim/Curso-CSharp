<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ficha-pedido.aspx.cs" Inherits="Curso.HTML.WebApplication1.clientes.ficha_pedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ficha Pedidos</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-12">
            <h2>Datos del pedido <%=pedido.OrderID%></h2>
            <hr />
            <br />
            <p><b>Fecha del pedido:</b> <%= pedido.ShippedDate.Value.ToShortDateString()%></p>
            <p><b>Cliente e ID Cliente:</b> <%=pedido.ShipName %> - <a href="ficha-cliente.aspx?identificador=<%= pedido.CustomerID %>"><%=pedido.CustomerID%></a> </p>
            <p><b>País de envío:</b> <%=pedido.ShipCountry %></p>
            <p><b>Ciudad de envío:</b> <%=pedido.ShipCity %></p>
            <p><b>Enviado por:</b> <%=pedido.Shippers.CompanyName %></p>
            

        </div>
        </div>
    </form>
</body>
</html>
