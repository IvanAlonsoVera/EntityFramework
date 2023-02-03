<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioPrestamos.aspx.cs" Inherits="IvanAlonsoBibliotecaCodeFirst.FormularioPrestamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1>Prestamos de la libreria Tajamar</h1>
            </div>
            <div class="row">
                <asp:Label Class="col-4" runat="server">Usuario: </asp:Label>
                <asp:DropDownList 
                        Class="col-4"
                        ID="ddlUsuario" 
                        runat="server" 
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Text="-Seleccione Usuario-" Value="0"></asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label Class="col-4" runat="server">Autor: </asp:Label>
                <asp:DropDownList 
                        Class="col-4"
                        ID="ddlAutor" 
                        runat="server" 
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlAutor_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Text="-Seleccione Autor-" Value="0"></asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label Class="col-4" runat="server">Libro: </asp:Label>
                <asp:DropDownList 
                        Class="col-4"
                        ID="ddlLibro" 
                        runat="server" 
                        AutoPostBack="true"
                        AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddlLibro_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Text="-Seleccione Libro-" Value="0"></asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label Class="col-4" runat="server">Fecha de prestamo: </asp:Label>
                <asp:TextBox ReadOnly="true" Class="col-4" ID="TbHoy" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label Class="col-4" runat="server">Fecha de devolucion: </asp:Label>
                <asp:TextBox ReadOnly="true" Class="col-4" ID="TbDevolver" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:GridView class="col-4" 
                    ID="GvLibro" 
                    AutoGenerateColumns="False"
                    OnRowCommand="GvLibro_RowCommand"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN"/>
                        <asp:BoundField DataField="Autor" HeaderText="Autor"/>
                        <asp:BoundField DataField="Libro" HeaderText="Libro"/>
                        <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha de entrega"/>
                        <asp:BoundField DataField="FechaDevolucion" HeaderText="Fecha de Devolucion"/>
                        <asp:ButtonField runat="server" ControlStyle-CssClass="btn btn-danger" CommandName="Entregar" Text="Entregar" ButtonType="Button"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <asp:Button cssClass="col-4 btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" />
                <asp:Button cssClass="col-4 btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" />
            </div>
        </div>
    </form>
</body>
</html>
