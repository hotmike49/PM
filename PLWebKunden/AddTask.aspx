<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="PLWebKunden.AddTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AddTask</title>
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
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnAddTaskMyProjects" runat="server" Text="MyProjects" OnClick="btnAddTaskMyProjects_Click" />
    
        <asp:Button ID="btnAddTaskMyTasks" runat="server" Text="MyTasks" OnClick="btnAddTaskMyTasks_Click" />
        <asp:Button ID="btnAddTaskUser" runat="server" Text="User" OnClick="btnAddTaskUser_Click" />
        <asp:Button ID="btnAddTaskLogout" runat="server" Text="Logout" OnClick="btnAddTaskLogout_Click" />
    
    </div>
        <p>
            Taskname:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTaskname" runat="server"></asp:TextBox>
        </p>
        <p>
            Description:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTaskDescription" runat="server"></asp:TextBox>
        </p>
        <p>
            Start Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calTaskStartDate" runat="server"></asp:Calendar>
        </p>
        <p>
            End Date:&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="calTaskEndDate" runat="server"></asp:Calendar>
        </p>
            <p>User:</p>
        
            <asp:CheckBoxList ID="chkTaskUser" runat="server">
            </asp:CheckBoxList>
        
        <br />
        Status:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Value="0">In Progress</asp:ListItem>
            <asp:ListItem Value="1">Done</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        
        <asp:Button ID="btnAddTaskSave" runat="server" Text="Save" OnClick="btnAddTaskSave_Click" />
        <asp:Button ID="btnAddTaskCancel" runat="server" Text="Cancel" OnClick="btnAddTaskCancel_Click" />
    </form>
</body>
</html>
