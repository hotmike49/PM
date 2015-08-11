<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkPackage.aspx.cs" Inherits="PLWebKunden.AddWorkPackage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AddWorkPackage</title>
    <style type="text/css">
        #TextArea1 {
            height: 81px;
        }
        #txtaProjectDescription {
            height: 83px;
        }
    </style>
</head>
<body>
    <form id="formAddWorkPackage" runat="server">
    <div>
    
        <asp:Button ID="btnAddWorkPackageMyProjects" runat="server" Text="MyProjects" OnClick="btnAddWorkPackageMyProjects_Click" />
    
        <asp:Button ID="btnAddWorkPackageMyTasks" runat="server" Text="MyTasks" OnClick="btnAddWorkPackageMyTasks_Click" />
        <asp:Button ID="btnAddWorkPackageUser" runat="server" Text="User" OnClick="btnAddWorkPackageUser_Click" />
        <asp:Button ID="btnAddWorkPackageLogout" runat="server" Text="Logout" OnClick="btnAddWorkPackageLogout_Click" />
    
    </div>
        <p>
            WorkPackagename:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtWorkPackagename" runat="server"></asp:TextBox>
        </p>
        <p>
            Description:&nbsp;&nbsp;&nbsp;
            <textarea id="txtaWorkPackageDescription" cols="20" name="S1"></textarea></p>
        <p>
            Start Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calWorkPackageStartDate" runat="server"></asp:Calendar>
        </p>
        <p>
            End Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calWorkPackageEndDate" runat="server"></asp:Calendar>
        </p>
        <asp:Button ID="btnAddWorkPackageSave" runat="server" Text="Save" />
        <asp:Button ID="btnAddWorkPackageCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
