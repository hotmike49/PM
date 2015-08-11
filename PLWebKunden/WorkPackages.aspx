﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPackages.aspx.cs" Inherits="PLWebKunden.WorkPackages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WorkPackages</title>
</head>
<body>
    <form id="formWorkPackages" runat="server">
    <div>
    
        <asp:Button ID="btnWorkPackagesMyProjects" runat="server" Text="MyProjects" OnClick="btnWorkPackagesMyProjects_Click" />
    
        <asp:Button ID="btnWorkPackagesMyTasks" runat="server" Text="MyTasks" OnClick="btnWorkPackagesMyTasks_Click" />
        <asp:Button ID="btnWorkPackagesUser" runat="server" Text="User" OnClick="btnWorkPackagesUser_Click" />
        <asp:Button ID="btnWorkPackagesLogout" runat="server" Text="Logout" OnClick="btnWorkPackagesLogout_Click" />
    
    </div>
        <h2>
            <asp:Label ID="lblWorkPackagesProjectname" runat="server" Text="Projectname"></asp:Label>
&nbsp;- WorkPackages&nbsp;&nbsp;&nbsp; <asp:Button ID="btnWorkPackagesAddProject" runat="server" Text="+ Add" OnClick="btnWorkPackagesAddProject_Click" />
        </h2>
        <asp:GridView ID="WorkPackagesView" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
        </asp:GridView>
    </form>
    </body>
</html>
