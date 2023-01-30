<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RelaccionNaN.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Gestión de Proyectos: </h1>
            <p>Elija un proyecto: </p>
            <%--AutoPostBack va unido con un evento--%>
            <%--AppendDataBoundItems: AÑADIR CAMPO NUEVO EN DROPDOWNLIST ASP--%>
            <asp:DropDownList ID="ddlProyectos" 
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlProyectos_SelectedIndexChanged"
                runat="server">
                <asp:ListItem Text="-SELECCIONE PROYECTO-" Value="0"></asp:ListItem>
            </asp:DropDownList><br />

            <asp:GridView ID="gvCientificosProyecto" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <br />
            <hr />
            <br />
            <h1>Gestión de Científicos:</h1>
            <p>Elija un científico: </p>
            <asp:DropDownList ID="ddlCientificos" 
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlCientificos_SelectedIndexChanged"
                runat="server">
                <asp:ListItem Text="-SELECCIONE CIENTÍFICO-" Value="0"></asp:ListItem>
            </asp:DropDownList><br />

            <asp:GridView ID="gvProyectosCientifico" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView><br />

            <asp:Button ID="btnAsociar" runat="server" Text="Asociar" 
                onclick="btnAsociar_Click"/>
        </div>
    </form>
</body>
</html>
