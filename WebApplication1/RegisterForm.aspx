<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="WebApplication1.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="_username" runat="server"></asp:TextBox></br>
            <asp:TextBox ID="_passwd" runat="server"></asp:TextBox></br>
            <asp:TextBox ID="_name" runat="server"></asp:TextBox></br>
            <asp:Button ID="Button1" runat="server" Text="Write To DB" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
