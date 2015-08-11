<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="PLWebKunden.AddProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AddProject</title>
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
    <form id="formAddProjects" runat="server">
    <div>
    
        <asp:Button ID="btnAddProjectMyProjects" runat="server" Text="MyProjects" OnClick="btnAddProjectMyProjects_Click1" style="height: 26px" />
    
        <asp:Button ID="btnAddProjectMyTasks" runat="server" Text="MyTasks" OnClick="btnAddProjectMyTasks_Click" />
        <asp:Button ID="btnAddProjectUser" runat="server" Text="User" OnClick="btnAddProjectUser_Click" />
        <asp:Button ID="btnAddProjectLogout" runat="server" Text="Logout" OnClick="btnAddProjectLogout_Click" />
    
    </div>
        <p>
            Projectname:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProjectname" runat="server"></asp:TextBox>
        </p>
        <p>
            Description:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProjectDescription" runat="server"></asp:TextBox>
        </p>
        <p>
            Start Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calProjectStartDate" runat="server"></asp:Calendar>
        </p>
        <p>
            End Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calProjectEndDate" runat="server"></asp:Calendar>
        </p>
            <p>User List:</p>
        <p>
            <asp:CheckBoxList ID="chkAddProjectProjectUser" runat="server">
            </asp:CheckBoxList>
        </p>
        <asp:Button ID="btnAddProjectSave" runat="server" Text="Save" OnClick="btnAddProjectSave_Click" />
        <asp:Button ID="btnAddProjectCancel" runat="server" Text="Cancel" OnClick="btnAddProjectCancel_Click" />
    </form>
</body>
</html>
