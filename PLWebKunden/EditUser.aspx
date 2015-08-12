<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PLWebKunden.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EditUser</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Firstname:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEditUserFirstname" runat="server"></asp:TextBox>
        <br />
        Lastname:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEditUserLastname" runat="server"></asp:TextBox>
        <br />
        E-Mail:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEditUserEmail" runat="server"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEditUserPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Confirm Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEditUserConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEditUserSave" runat="server" Text="Save" OnClick="btnEditUserSave_Click" />
        <asp:Button ID="btnEditUserCancel" runat="server" Text="Cancel" OnClick="btnEditUserCancel_Click" />
    
    </div>
    </form>
</body>
</html>
