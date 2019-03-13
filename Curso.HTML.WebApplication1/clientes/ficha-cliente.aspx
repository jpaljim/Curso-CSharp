<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ficha-cliente.aspx.cs" Inherits="Curso.HTML.WebApplication1.clientes.ficha_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Datos del Cliente</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        table {
            text-align:center;
        }
    </style>
</head>
<body>

    <div class="container">
        <div class="col-md-12">
            <p><b>ID:</b> <%= cliente.CustomerID%></p>
            <p><b>Company Name:</b> <%= cliente.CompanyName%></p>
            <p><b>Name:</b> <%= cliente.ContactTitle%></p>
            <p>Address: <%= cliente.Address%></p>
            <p>Region: <%= cliente.Region %></p>
            <p>Ciudad: <%= cliente.City %></p>
            <p>Postal Code: <%= cliente.PostalCode%></p>
            <p>Country: <%= cliente.Country%></p>
            <p>Phone: <%= cliente.Phone%></p>
            <p>Fax: <%= cliente.Fax%></p>

            <br />
            <h2>Lista de pedidos de <%=cliente.CompanyName%></h2>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <td><b>Identificador</b></td>
                        <td><b>Fecha Pedido</b></td>
                        <td><b>País de Envío</b></td>
                        <td><b>Fecha de Envío</b></td>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in cliente.Orders)
                        {
                            Response.Write("<tr>");
                            Response.Write("<td>" +
                                "<a href=\"ficha-pedido.aspx?id=" + item.OrderID  + "\">" + item.OrderID + "</a></td>");
                            Response.Write("<td>"+item.OrderDate.Value.ToShortDateString()+"</td>");
                            Response.Write("<td>"+item.ShipCountry+"</td>");
                            Response.Write("<td>"+item.ShippedDate.Value.ToShortDateString()+"</td>");
                            Response.Write("</tr>");

                        } %>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>
