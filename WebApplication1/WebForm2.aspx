<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body style="background-color:#D9D9D9;">
    <form id="form1" runat="server">
        <h2 style="text-align: center">WELCOME!!!   <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h2>
        <div align="center">
            <b font-weight:bold;>新增</b>
            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
            <tbody>
            <tr><td class="auto-style2">姓名:</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            <tr><td class="auto-style2">電話:</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
            <tr><td class="auto-style2">地址:</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
            </tbody>
            </table>

            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="新增" />
            <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="修改資料(跳頁)" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" style="height: 21px" Text="GridView選取修改資料" />
            <br />
            <br />
            <br />
            <b font-weight:bold;>刪除</b>
            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
            <tbody>
            <tr><td class="auto-style2">姓名: </td>
                <td class="auto-style2"><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></asp:TextBox></td></tr>
            </tbody>
            </table>

            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="刪除" />
            <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <b font-weight:bold;>資料</b>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DId" DataSourceID="SqlDataSource1" style="text-align: center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" align="center">
                <Columns>
                    <asp:BoundField DataField="DId" HeaderText="DId" ReadOnly="True" SortExpression="DId" InsertVisible="False" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="tellphone" HeaderText="tellphone" SortExpression="tellphone" />
                    <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" OnClick="Button1_Click1" Text="編輯" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [People]" DeleteCommand="DELETE FROM [People] WHERE [DId] = @DId" InsertCommand="INSERT INTO [People] ([name], [tellphone], [address]) VALUES (@name, @tellphone, @address)" UpdateCommand="UPDATE [People] SET [name] = @name, [tellphone] = @tellphone, [address] = @address WHERE [DId] = @DId">
                <DeleteParameters>
                    <asp:Parameter Name="DId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="tellphone" Type="Int32" />
                    <asp:Parameter Name="address" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="tellphone" Type="Int32" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="DId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="匯出EXCEL" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" align="center"></asp:GridView>
            <table style="border:3px #808080 solid" cellpadding="10" border="0" align="center">
                <tbody>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>           
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" style="height: 21px" Text="匯入EXCEL" />
            <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登出" style="text-align: center" ViewStateMode="Disabled" />
        </div>
    </form>
</body>
</html>
