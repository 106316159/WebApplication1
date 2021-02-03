<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="WELCOME!!!"></asp:Label>
            &nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="姓名: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="電話: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="地址: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="新增" />
            <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="修改資料" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="姓名: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="刪除" />
            <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="資料庫裡的資料: "></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DId" DataSourceID="SqlDataSource1" style="text-align: center">
                <Columns>
                    <asp:BoundField DataField="DId" HeaderText="DId" ReadOnly="True" SortExpression="DId" InsertVisible="False" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="tellphone" HeaderText="tellphone" SortExpression="tellphone" />
                    <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Update" Text="修改" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="刪除" />
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
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" style="height: 21px" Text="匯入EXCEL" />
            <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登出" style="text-align: center" />
        </div>
    </form>
</body>
</html>
