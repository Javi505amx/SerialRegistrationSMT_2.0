<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainScan.aspx.cs" Inherits="SerialRegistrationSMT_2._0.MainScan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Resources/Images/inventronics icon.ico" rel="icon" />
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
<title>Escaneo QR SMT</title>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
        #divLeft{
            float: left;
        }
        #divLabels{
            float: left;
            text-align: right;
        }
        #divResults{
            float: left;
            text-align: left;
        }
        #divBottom{
            text-align: center;
        }
        #divButtons{
            position: absolute;
            bottom:50px;
            right: 50px;
        }
        #divScan{
            text-align: center;
        }
    </style>

</head>
<body class="bg-light">
    <form id="form1" runat="server" style="font-family: Calibri;" title="Escaneo QR SMT">
        <div id="divScan" class="form-group">
            <asp:Label ID="lblMain" runat="server" Text="ESCANEO MAIN" Font-Bold="true" Font-Size="200%" ForeColor="Blue"></asp:Label>
            <br />
            <asp:Label ID="lblJar" runat="server" Text="Escanear Tarro de Pasta:" Font-Size="200%"></asp:Label>
            <br />
            <asp:TextBox ID="txtJarScan" runat="server" AutoPostBack="true" Font-Size="200%" AutoCompleteType="Disabled" Style="text-transform:uppercase" OnTextChanged="txtJarScan_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="lblJarScan" runat="server" Font-Size="200%" Text="" Font-Bold="true"></asp:Label>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Escanear QR: " Font-Size="200%"></asp:Label>
            <br />
            <asp:TextBox ID="txtSerialScan" runat="server" AutoPostBack="true" OnTextChanged="txtSerialScan_TextChanged" Font-Size="200%" AutoCompleteType="Disabled" Enabled="false" Style="text-transform:uppercase"></asp:TextBox>
            <br />
            <br />
       </div>
            <div id="divLeft" class="form-group">
                <div id="divLabels" class="form-group">
                    &nbsp;
                    <asp:Label ID="lblWorkOrder" runat="server" Text="Work Order: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblQtyTotal" runat="server" Text="Cantidad Total: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblModel" runat="server" Text="Modelo: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblSerialScan" runat="server" Text="Numero Serie QR: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblRepair" Text="Main Reparación: " runat="server" Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblAccumTotal" runat="server" Text="Total Acumulado: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblAccumDay" runat="server" Text="Acumulado X Dia: " Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;
                    <asp:Label ID="lblScrap" Text="Scrap: " runat="server" Font-Size="200%" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                </div>
                <div id="divResults" class="form-group">
                    <asp:Label ID="lblRWO" runat="server" Text="" Font-Size="200%" ForeColor="Blue"></asp:Label>
                    <br />
                    <asp:Label ID="lblRQT" runat="server" Text="" Font-Size="200%" ForeColor="Blue"></asp:Label>
                    <br />
                    <asp:Label ID="lblRM" runat="server" Text="" Font-Size="200%" ForeColor="Blue"></asp:Label>
                    <br />
                    <asp:Label ID="lblRSN" runat="server" Text="" Font-Size="200%" ForeColor="Blue"></asp:Label>
                    <br />
                    <asp:Label ID="lblQtyRepair" Text="" runat="server" Font-Size="200%" ForeColor="Orange"></asp:Label>
                    <br />
                    <asp:Label ID="lblRAT" runat="server" Text="" Font-Size="200%" ForeColor="Navy"></asp:Label>
                    <br />
                    <asp:Label ID="lblRAD" runat="server" Text="" Font-Size="200%" ForeColor="Navy"></asp:Label>
                    <br />
                    <asp:Label ID="lblQtyScrap" Text="" runat="server" Font-Size="200%" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
            <div id="divBottom" class="form-group">
                    <asp:Label ID="lblResult" runat="server" Text="" Font-Size="300%" ForeColor="Blue"></asp:Label>
            </div>

        <div id="divButtons">
            <asp:LinkButton ID="btnClose2" runat="server" Font-Size="200%" CssClass="btn btn-primary" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> Atras
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnLogout" PostBackUrl="~/Login.aspx" Font-Size="200%">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> Salir
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>
