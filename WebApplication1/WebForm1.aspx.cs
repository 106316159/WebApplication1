using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            //建立Select帶參數語法
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[Table] Where id=@id AND password=@pw", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
            cmd.Parameters.Add("@pw", SqlDbType.NVarChar, 50).Value = TextBox2.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["id"] = TextBox1.Text;//賦值Session
                Response.Redirect("WebForm2.aspx", true);
            }
            else
            {
                Label3.Text = "帳號或密碼錯誤!";
            }

            dr.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}