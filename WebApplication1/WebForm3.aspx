<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#D9D9D9;">
    <form id="form1" runat="server">
        <h3 style="text-align: center">修改資料</h3>
        <div style="text-align: center">
            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
            <tbody>
            <tr><td class="auto-style2">輸入要修改之姓名:</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            </tbody>
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" />
            <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <br />

            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
            <tbody>
            <tr><td class="auto-style2">姓名:</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
            <tr><td class="auto-style2">電話:</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
            <tr><td class="auto-style2">地址:</td>
                <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td></tr>
            </tbody>
            </table>

            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="送出" />
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="回上一頁" />
        </div>
    </form>
</body>
</html>
