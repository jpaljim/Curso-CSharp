<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="Curso.HTML.WebApplication1.empleados.listado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Empleados</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Listado de Empleados</h1>
                <%if (Empleados.Count > 0)
                    {%>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <td><b>ID Empleado</b></td>
                            <td><b>Nombre</b></td>
                            <td><b>Ciudad</b></td>
                            <td><b>País</b></td>
                            <td><b>Antiguedad</b></td>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var item in Empleados)
    {
        Response.Write("<tr>");
        Response.Write("<td>" + item.EmployeeID + "</td>");
        Response.Write("<td>" + item.FirstName + " " + item.LastName + "</td>");
        Response.Write("<td>" + item.City + "</td>");
        Response.Write("<td>" + item.Country + "</td>");
        Response.Write("<td>" + item.HireDate.Value.ToShortDateString() + " (" + (DateTime.Now.Subtract(item.HireDate.Value).Days / 365).ToString("N0") + " años)</td>");
        Response.Write("</tr>");
    }
                          %>

                    </tbody>
                </table>
                <%}
                    else
                    {%>
                <br />
                <h2><b class="text-danger">Registros de Empleados no encontrados.</b></h2>
                <%  }%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-right">
                <a href="buscar.aspx" class="btn btn-primary">volver</a>
            </div>
        </div>
    </div>
</body>
</html>