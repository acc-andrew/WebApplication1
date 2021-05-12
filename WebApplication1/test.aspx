<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApplication1.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="userid" runat="server"></asp:TextBox>
        <asp:Label ID="_veri_userid" runat="server" Text=""></asp:Label>
        </br>
        <asp:TextBox ID="passwd" runat="server"></asp:TextBox>
        <asp:Label ID="_veri_passwd" runat="server" Text=""></asp:Label>
        </br>
        <asp:TextBox ID="_userName" runat="server"></asp:TextBox>
        </br>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AccountsConnectionString %>" SelectCommand="SELECT * FROM [AccTable]"></asp:SqlDataSource>
    </form>
</body>
</html>
