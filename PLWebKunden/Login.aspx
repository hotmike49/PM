<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PLWebKunden.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>

    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="txtUsername" runat="server">Username</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="txtPassword" runat="server">Password</asp:TextBox>
        </p>
        <asp:Button ID="btnLoginLogin" runat="server" Text="Login" OnClick="btnLoginLogin_Click" />
        <asp:Button ID="btnLoginCancel" runat="server" Text="Cancel" OnClick="btnLoginCancel_Click" />
    </form>

</body>
</html>
