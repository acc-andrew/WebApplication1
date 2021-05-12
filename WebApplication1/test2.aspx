<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="WebApplication1.test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    </br>
    <asp:Label ID="_PeopleCount" runat="server" Text=""></asp:Label>
    <asp:Button ID="_BtnLogout" runat="server" Text="登出" OnClick="_BtnLogout_Click" />
    </br>
    
    <asp:Label ID="Label_pss_title" runat="server" Text="遊戲：剪刀、石頭、布"></asp:Label>
    <br />
    <asp:ImageButton ID="_ImgBtnUser_paper"   runat="server" ImageUrl="~/Pics/paper.jpg" OnClick="UserInpPaper" />
    <asp:ImageButton ID="_ImgBtnUser_scissor" runat="server" ImageUrl="~/Pics/scissor.jpg" OnClick="_ImgBtnUser_scissor_Click" />
    <asp:ImageButton ID="_ImgBtnUser_stone"   runat="server" ImageUrl="~/Pics/stone.jpg" OnClick="_ImgBtnUser_stone_Click" />

    <br />
    <asp:Label ID="Label_pss" runat="server" Text="電腦出"></asp:Label>
    <asp:Image ID="_imageCpt" runat="server" ImageUrl="~/Pics/X.png" />
    <br />
    <asp:Label ID="Label_pssResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="">統計結果</asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="">贏了 </asp:Label>
    <asp:Label ID="_winTimes" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="">輸了 </asp:Label>
    <asp:Label ID="_lossTimes" runat="server" Text=""></asp:Label>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="_Timer1" runat="server" Interval="1000" OnTick="Timer1Tick"></asp:Timer>
            <asp:Label ID="_countDownText" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
    <asp:Label ID="Label5" runat="server" Text="Update Area"> </asp:Label>

    <asp:Label ID="Label4" runat="server" Text="輸入訊息"> </asp:Label>

    <asp:TextBox ID="_sendMsg" runat="server" Rows="10"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="訊息送出" OnClick="msgSent" />
    <br />
    <asp:ListBox ID="_ListBox" runat="server" Width="275px"></asp:ListBox>

<form id ="form1">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="Click" UseSubmitBehavior="false" OnClick="Button2_Click"/>
        <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        </br>
        <asp:Image ID="Image1" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
    </div>
</form>

</asp:Content>
