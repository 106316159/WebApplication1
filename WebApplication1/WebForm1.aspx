<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            height: 22px;
        }
    </style>
</head>
<body style="background-color:#D9D9D9;">
    <h2 style="text-align: center">登入</h2>
    <form id="form1" runat="server">
        <div class="auto-style1">

            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
            <tbody>
            <tr><td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="帳號: "></asp:Label></td>
                <td class="auto-style2"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="Label2" runat="server" Text="密碼: "></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
            </tbody>
            </table>

            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="管理登入" />
            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
