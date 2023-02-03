<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimerEjercicioAJAX.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.6.3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBuscarN_Aleatorio" runat="server" Text="Buscar Aleatorio" /><br />
            <asp:Label ID="lblResultado" runat="server" CssClass="label"></asp:Label>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $('#btnBuscarN_Aleatorio').click(function (e) {
            e.preventDefault();
            $.ajax({
                url: "Aleatorio.aspx/BuscarNumAleatorio",
                type:'POST',
                data: null,
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resultado) {
                    var num = resultado.d;
                    $('#lblResultado').text('Numero aleatorio es ' + num);
                },
                error: function (error) {
                    alert(error.Message);
                }
            })
        })
    })
</script>
