<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SerialRegistrationSMT_2._0.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <meta http-equiv="Expires" content="0"/>
    <meta http-equiv="Pragma" content="no-cache"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" type="text/css" rel="stylesheet nofollow"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <title>Login</title>
    <style type="text/css">
        .container{
            margin: 0 auto;
            text-align: center;
        }
        #btnLogin{
            border-radius: 10px;
        }
    </style>
</head>
<body class="bg-light">
    <div class="container">
        <div>
            <div>
                <br />
                <asp:Image ImageUrl="~/Resources/Images/InventronicsDTLRHighResLogo.png" runat="server" Height="100px" Width="300px"/>
                <br />
                <br />
                <form id="frmLogin" runat="server" style="font-family:Calibri">
                    <div>
                        <div id="divTitle">
                            <asp:Label ID="lblWelcome" runat="server" Text="Escaneo QR Main" Font-Bold="true" Font-Size="250%" style="text-align: center" ForeColor="#000099"></asp:Label>
                        </div>
                        <br />
                        <br />
                        <div>
                            <asp:Label ID="lblUser" runat="server" Text="Usuario:" Font-Size="150%"></asp:Label><br />
                            <asp:TextBox ID="txtUser" runat="server" placeholder="Username" Font-Size="150%" Height="50px" Width="300px" AutoPostBack="true"  AutoCompleteType="Disabled" OnTextChanged="txtUser_TextChanged"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Size="150%"></asp:Label><br />
                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Font-Size="150%" Height="50px" Width="300px" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                        <div >
                            <asp:Label runat="server" ID="lblError" Font-Size="150%"/>
                        </div>
                        <br/>
                        <br />
                        <div>
                            <asp:Button ID="btnLogin" CssClass="btn-dark" runat="server" Text="Login" OnClick="btnLogin_Click" Font-Size="150%" Height="50px" Width="300px"/>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
