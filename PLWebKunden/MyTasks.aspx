<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTasks.aspx.cs" Inherits="PLWebKunden.MyTasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MyTasks</title>
</head>
<body>
    
    <form id="formMyTasks" runat="server">
    


    
        <asp:Button ID="btnMyTasksMyProjects" runat="server" Text="MyProjects" OnClick="btnMyTasksMyProjects_Click" />
    
        <asp:Button ID="btnMyTasksUser" runat="server" Text="User" OnClick="btnMyTasksUser_Click" />
        <asp:Button ID="btnMyTasksLogout" runat="server" Text="Logout" OnClick="btnMyTasksLogout_Click" />
    
    <br />
    <br />
    <h4><asp:Label ID="lblMyTasksUsername" runat="server" Text="Label"></asp:Label> &nbsp;- Tasks</h4><br />
    <asp:GridView ID="MyTasksView" runat="server">
    </asp:GridView>
</form>
</body>
</html>
    
    