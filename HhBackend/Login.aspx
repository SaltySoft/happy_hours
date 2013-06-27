<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HhBackend.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" runat="server"></asp:Login>
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </div>
    </form>
</body>
</html>
