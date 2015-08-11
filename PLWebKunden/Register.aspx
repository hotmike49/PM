<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PLWebKunden.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
</head>
<body>
    <form id="formRegister" runat="server">
    <div>
    
        Firstname:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterFirstname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegisterFirstname" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        Lastname:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterLastname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtRegisterLastname"></asp:RequiredFieldValidator>
        <br />
        Username:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtRegisterUsername"></asp:RequiredFieldValidator>
        <br />
        E-Mail:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtRegisterEmail"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRegisterEmail" ErrorMessage="e-mail not valid" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
        <br />
        Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtRegisterPassword"></asp:RequiredFieldValidator>
        <br />
        Confirm Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRegisterConfirmPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtRegisterConfirmPassword"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnRegisterRegister" runat="server" Text="Register" OnClick="btnRegisterRegister_Click" />
        <asp:Button ID="btnRegisterCancel" runat="server" Text="Cancel" OnClick="btnRegisterCancel_Click" CausesValidation="False" />
    
    </div>
    </form>
</body>
</html>
