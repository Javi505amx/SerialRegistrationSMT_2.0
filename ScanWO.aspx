<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScanWO.aspx.cs" Inherits="SerialRegistrationSMT_2._0.ScanWO" %>

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
<script type="text/javascript">
    function selectWorkOrder() {
        document.getElementById('txtWorkOrder').select();
    }
</script>
<title>Scan Work Order</title>
<style type="text/css">
    #divWorkOrder{
        text-align: center;
    }
    #divScan{
        text-align: center;
    }
    #divResult{
        text-align: center;
    }
    #divModel{
        float: left;
    }
    #divQtys{
        float: right;
        text-align: left;
    }
    #divTotals{
        overflow: hidden;
        float: right;
    }
    #divRight{
        float: right;
    }
    #divOptions{
        text-align: center;
    }
    #divButtons{
        position: absolute;
        bottom:50px;
        right: 50px;
    }</style>
</head>
<body class="bg-light">
    <form id="form1" runat="server" style="font-family: Calibri;" title="Scan Work Order">
        <br />
        <div id="divWorkOrder" class="form-group">
            <asp:Label ID="lblWorkOrder" runat="server" Text="Ingresar Work Order" Font-Size="300%"></asp:Label>
            <br />
            <asp:TextBox ID="txtWorkOrder" runat="server" AutoPostBack="true" Font-Size="300%" OnTextChanged="txtWorkOrder_TextChanged" AutoCompleteType="Disabled" Style="text-transform:uppercase"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server" Font-Size="500%" ForeColor="Red" Text="Work Order No Encontrada!" Visible="false"></asp:Label>
        </div>
        <div id="divModel" class="form-group">
            <asp:Label ID="lblWO" runat="server" Font-Size="300%" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblModelWO" runat="server" Font-Size="300%" Text=""></asp:Label>
            <br />
        </div>
        <br />
        <div id="divRight">
            <div id="divQtys" class="form-group">
                &nbsp;
                <asp:Label ID="lblTotal" runat="server" Font-Size="300%" Text="" ForeColor="Blue"></asp:Label>
                &nbsp;&nbsp;
                <br />
                &nbsp;
                <asp:Label ID="lblAccumWO" runat="server" Font-Size="300%" Text="" ForeColor="Blue"></asp:Label>
                &nbsp;&nbsp;
                <br />
                &nbsp;
                <asp:Label ID="lblAccumDay" runat="server" Font-Size="300%" Text="" ForeColor="Blue"></asp:Label>
                &nbsp;&nbsp;
                <br />
                &nbsp;
            </div>
            <div id="divTotals" class="form-group">
                <asp:Label ID="lblQtyTotal" runat="server" Font-Size="300%" Text="Total WO: " Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblQtyAccumWO" runat="server" Font-Size="300%" Text="Acum WO: " Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblQtyAccumDay" runat="server" Font-Size="300%" Text="Acum Dia: " Visible="false"></asp:Label>
                <br />
            </div>
        </div>
        <div id="divButtons">
            <asp:LinkButton ID="btnClose2" runat="server" Font-Size="200%" CssClass="btn btn-primary" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> Atras
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>
