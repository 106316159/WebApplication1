using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string Strcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("WebForm1.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e) //搜尋
        {
            if (TextBox1.Text != "")
            {
                SqlConnection conn = new SqlConnection(Strcon);
                //建立Select帶參數語法
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where DId=@a", conn);
                //於SqlCommand中加入SqlParameter參數，並設定參數值
                cmd.Parameters.Add("@a", SqlDbType.Int, 4).Value = TextBox1.Text;
                SqlDataReader dr = cmd.ExecuteReader();


                string strsql = @"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where DId='" + TextBox1.Text + "' ";
                DataTable dt = new DataTable();//创建一个数据表dt
                SqlConnection Conn = new SqlConnection(Strcon);//定义新的数据连接控件并初始化
                Conn.Open();//打开连接
                SqlDataAdapter Cmd = new SqlDataAdapter(strsql, Conn);//定义并初始化数据适配器
                Cmd.Fill(dt);  //将数据适配器中的数据填充到数据集dt中
                Conn.Close();

                if (dr.HasRows)
                {
                    TextBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                    TextBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                    TextBox4.Text = dt.Rows[0].ItemArray[3].ToString();
                }
                else
                    Label4.Text = "查無該ID資料記錄！";
                dr.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            else
                Label4.Text = "請輸入ID資料";
        }

        protected void Button2_Click(object sender, EventArgs e) //修改
        {
            if (TextBox1.Text != "")
            {
                SqlConnection conn1 = new SqlConnection(Strcon);
                //建立Select帶參數語法
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand(@"Update [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Set name=@a,tellphone=@tell,address=@addr  Where DId='" + TextBox1.Text + "'", conn1);
                cmd1.Parameters.Add("@a", SqlDbType.NChar, 10).Value = TextBox2.Text;
                cmd1.Parameters.Add("@tell", SqlDbType.NChar, 10).Value = TextBox3.Text;
                cmd1.Parameters.Add("@addr", SqlDbType.NChar, 10).Value = TextBox4.Text;
                cmd1.ExecuteNonQuery();
                Label5.Visible = true;
                Label5.Text = "修改成功！";
                cmd1.Dispose();
                conn1.Close();
                conn1.Dispose();
            }
            else
                Label5.Text = "請輸入ID資料";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx", true);
        }
    }
}