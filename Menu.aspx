<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SerialRegistrationSMT_2._0.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <title>Menu Escaneo QR</title>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
        #menuValidation{
            text-align: center;
        }
        #divLinks{
            position: absolute;
            margin: 3% 0 0 37%;
        }
        #btnLogout{
            float: right;
        }
    </style>
</head>
<body class="bg-light">
    <form id="menuValidation" runat="server" style="font-family: Calibri;" title="SMT Validation Menu">
        <div id="divUser">
            <asp:Label ID="lblUser" runat="server" Text="" Font-Size="150%" Font-Bold="true" ForeColor="Blue"></asp:Label>
        </div>
        <div id ="divLinks">
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnValidateJar" PostBackUrl="~/JarOpening.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-clipboard-check" aria-hidden="true"></span> Validación de Tarro
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server"  CssClass="btn btn-secondary" ID="btnQRScan" Font-Size="200%" Visible="false" OnClick="btnQRScan_Click">
                <span class="fas fa-qrcode" aria-hidden="true"></span> Escaneo QR Main
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnScard" Font-Size="200%" Visible="false" OnClick="btnScard_Click">
                <span class="fas fa-qrcode" aria-hidden="true"></span> Escaneo QR Scard / Sboard
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnScrap" PostBackUrl="~/ScanWOScrap.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-trash" aria-hidden="true"></span> Registro Scrap
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnConsultWO" PostBackUrl="~/ConsultWorkOrder.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-search" aria-hidden="true"></span> Consulta WO
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnInRework" PostBackUrl="~/ReworkMain.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-arrow-right" aria-hidden="true"></span> Ingreso Reparacion
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnOutRework" PostBackUrl="~/RepairComplete.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-arrow-left" aria-hidden="true"></span> Salida Reparacion
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnUsers" PostBackUrl="~/Users.aspx" Font-Size="200%" Visible="false">
                <span class="fas fa-user" aria-hidden="true"></span> Usuarios
            </asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnLogout" PostBackUrl="~/Login.aspx" Font-Size="200%">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> Salir
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>
