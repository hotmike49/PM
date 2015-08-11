<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="PLWebKunden.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Welcome</title>
</head>
<body>
    <form id="formWelcome" runat="server">
    <div>
        <h1>PM-Tool</h1>
    </div>
        <asp:Button ID="btnWelcomeLogin" runat="server" Text="Login" OnClick="btnWelcomeLogin_Click" />
        <asp:Button ID="btnWelcomeRegister" runat="server" Text="Register" OnClick="btnWelcomeRegister_Click" />
    </form>
</body>
</html>
