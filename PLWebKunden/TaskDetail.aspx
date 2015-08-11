<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskDetail.aspx.cs" Inherits="PLWebKunden.TaskDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TaskDetail</title>
</head>
<body>
    <form id="formTaskDetail" runat="server">
    <div>
    
        <asp:Button ID="btnTaskDetailMyProjects" runat="server" Text="MyProjects" OnClick="btnTaskDetailMyProjects_Click" />
        <asp:Button ID="btnTaskDetailMyTasks" runat="server" Text="MyTasks" OnClick="btnTaskDetailMyTasks_Click" />
        <asp:Button ID="btnTaskDetailUser" runat="server" Text="User" OnClick="btnTaskDetailUser_Click" />
        <asp:Button ID="btnTaskDetailLogout" runat="server" Text="Logout" OnClick="btnTaskDetailLogout_Click" />
    
        <br />
    
    </div>
        <asp:Label ID="lblTaskDetailTaskname" runat="server" Text="Taskname"></asp:Label>
        <p>
            <asp:Label ID="lblTaskDetailDescription" runat="server" Text="Description"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblTaskDetailEndDate" runat="server" Text="EndDate"></asp:Label>
        </p>
        <p>
            Status:&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTaskDetailStatus" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnTaskDetailBack" runat="server" Text="Back" OnClick="btnTaskDetailBack_Click" />
        </p>
    </form>
</body>
</html>
