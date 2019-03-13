<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscar.aspx.cs" Inherits="Curso.HTML.WebApplication1.empleados.buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Buscar Empleado</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <form method="post" action="listado.aspx">
            <div class="row">
                <div class="col-md-12">
                    <h1>Buscar Empleados</h1>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>Nombre</label>
                        <input type="text" id="nombre" name="nombre" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Ciudad</label>
                        <select id="ciudad" name="ciudad" class="form-control">
                            <option value="all">Todas las ciudades</option>
                            <%foreach (var item in Ciudades)
                                {
                                    Response.Write("<option>" + item + "</option>");
                                }%>
                        </select>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>País</label>
                        <select id="pais" name="pais" class="form-control">
                            <option value="all">Todas los paises</option>
                            <%foreach (var item in Paises)
                                {
                                    Response.Write("<option>" + item + "</option>");
                                }%>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-right">
                    <button type="submit" class="btn btn-success">Enviar</button>
                </div>
            </div>
        </form>
    </div>
</body>
</html>