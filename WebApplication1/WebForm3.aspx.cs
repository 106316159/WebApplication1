using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("WebForm1.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e) //搜尋
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            //建立Select帶參數語法
            conn.Open();

            SqlCommand cmd = new SqlCommand(@"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where name=@a", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@a", SqlDbType.NChar, 10).Value = TextBox1.Text;
            SqlDataReader dr = cmd.ExecuteReader();


            string strsql = @"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where name='" + TextBox1.Text + "' ";
            DataTable dt = new DataTable();//创建一个数据表dt
            SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");//定义新的数据连接控件并初始化
            Conn.Open();//打开连接
            SqlDataAdapter Cmd = new SqlDataAdapter(strsql, Conn);//定义并初始化数据适配器
            Cmd.Fill(dt);   //将数据适配器中的数据填充到数据集dt中
            Conn.Close();//关闭连接	

            if (dr.HasRows)
            {
                //Row[0]表示dt表中的第一行（假设没有同名）,ItemArray[1]表示行中的第二个数据单元
                TextBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                TextBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                TextBox4.Text = dt.Rows[0].ItemArray[3].ToString();
            }
            else
            {
                //顯示查不到之訊息
                Label4.Text = "查無該姓名資料記錄！";
            }
            dr.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void Button2_Click(object sender, EventArgs e) //修改
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            //建立Select帶參數語法
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(@"Update [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Set name=@a,tellphone=@tell,address=@addr  Where name=@a", conn1);
            cmd1.Parameters.Add("@a", SqlDbType.NChar, 10).Value = TextBox2.Text;
            cmd1.Parameters.Add("@tell", SqlDbType.Int, 4).Value = Int32.Parse(TextBox3.Text);
            cmd1.Parameters.Add("@addr", SqlDbType.NVarChar, 50).Value = TextBox4.Text;
            cmd1.ExecuteNonQuery();
            Label5.Visible = true;
            Label5.Text = "修改成功！";
            cmd1.Dispose();
            conn1.Close();
            conn1.Dispose();

            //Response.Redirect("WebForm2.aspx", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx", true);
        }
    }
}