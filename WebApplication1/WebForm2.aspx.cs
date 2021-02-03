﻿using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
                Label2.Text = (string)Session["id"];
            else
                Response.Redirect("WebForm1.aspx", true);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx", true);
        }

        protected void Button2_Click(object sender, EventArgs e) //儲存
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();    //開啟資料庫連線
                            //建立SqlCommand查詢命令
            SqlCommand cmd = new SqlCommand(@"Insert Into [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People](name,tellphone,address) Values(@n,@tell,@addr)", conn);
            //cmd.Parameters.Add("@id", SqlDbType.NChar, 10).Value = Label2.Text;
            cmd.Parameters.Add("@n", SqlDbType.NChar, 10).Value = TextBox1.Text;
            cmd.Parameters.Add("@tell", SqlDbType.Int, 4).Value = Int32.Parse(TextBox2.Text);
            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 50).Value = TextBox3.Text;
            cmd.ExecuteNonQuery();
            //釋放物件及連線資源
            Label6.Text = "新增成功！";
            GridView1.DataBind();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void Button3_Click(object sender, EventArgs e) //刪除
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TPE-Intern001\Desktop\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(@"Select * From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where name=@a", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd1.Parameters.Add("@a", SqlDbType.NVarChar, 10).Value = TextBox4.Text;
            SqlDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.HasRows)
            {
                dr1.Dispose();
                cmd1.Dispose();
                SqlCommand cmd = new SqlCommand(@"Delete From [C:\USERS\TPE-INTERN001\DESKTOP\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DATABASE1.MDF].[dbo].[People] Where  name=@a", conn);
                //於SqlCommand中加入SqlParameter參數，並設定參數值
                cmd.Parameters.Add("@a", SqlDbType.NVarChar, 10).Value = TextBox4.Text;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.Dispose();
                Label8.Text = "刪除成功！";
            }
            else
            {
                Label8.Text = "無該姓名資料記錄！";
            }
            GridView1.DataBind();

            conn.Close();
            conn.Dispose();
        }

        protected void Button5_Click(object sender, EventArgs e) //修改
        {
            Label2.Text = (string)Session["id"];
            Response.Redirect("WebForm3.aspx", true);
        }

        public static void ExportToFile(GridView gv, string excelName)//匯出Excel
        {
            try
            {
                //建立 WorkBook 及試算表
                XSSFWorkbook workbook = new XSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                XSSFSheet mySheet1 = (XSSFSheet)workbook.CreateSheet(excelName);

                //mySheet1.DefaultColumnWidth = 15; //預設的字元寬度

                //建立標題列 Header
                XSSFRow rowHeader = (XSSFRow)mySheet1.CreateRow(0);
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    ////若有啟用排序，Header會變成 LinkButton
                    //LinkButton lb = null;
                    //if (gv.HeaderRow.Cells[i].Controls.Count > 0)
                    //{
                    // lb = gv.HeaderRow.Cells[i].Controls[0] as LinkButton;
                    //}
                    //string strValue = (lb != null) ? lb.Text : gv.HeaderRow.Cells[i].Text;
                    string strValue = gv.HeaderRow.Cells[i].Text;
                    XSSFCell cell = (XSSFCell)rowHeader.CreateCell(i);
                    cell.SetCellValue(HttpUtility.HtmlDecode(strValue).Trim());

                    //建立新的CellStyle
                    ICellStyle CellsStyle = workbook.CreateCellStyle();
                    //建立字型
                    IFont StyleFont = workbook.CreateFont();
                    //設定文字字型
                    StyleFont.FontName = "微軟正黑體";
                    //設定文字大小
                    StyleFont.FontHeightInPoints = 12; //設定文字大小為10pt
                    CellsStyle.SetFont(StyleFont);
                    cell.CellStyle = CellsStyle;
                }

                //建立內容列 DataRow
                for (int i = 0; i < gv.Rows.Count; i++)
                {

                    XSSFRow rowItem = (XSSFRow)mySheet1.CreateRow(i + 1);

                    for (int j = 0; j < gv.HeaderRow.Cells.Count; j++)
                    {
                        Label lb = null;  // 因為GridView中有TemplateField，所以要將Label.Text讀出來
                        if (gv.Rows[i].Cells[j].Controls.Count > 1)
                        {
                            lb = gv.Rows[i].Cells[j].Controls[1] as Label;
                        }
                        string value1 = (lb != null) ? HttpUtility.HtmlDecode(lb.Text) : HttpUtility.HtmlDecode(gv.Rows[i].Cells[j].Text).Trim();
                        int intry = 0;
                        bool isNumeric = !value1.StartsWith("0") && int.TryParse(value1, out intry);

                        XSSFCell cell = (XSSFCell)rowItem.CreateCell(j);

                        if (string.IsNullOrEmpty(value1.Trim()))
                        {
                            //空白
                            cell.SetCellValue(Convert.ToString(""));
                        }
                        else if (!isNumeric)
                        {
                            if (value1.Length > 10)
                            {
                                //文字格式
                                mySheet1.SetColumnWidth(j, 50 * 256); //欄位寬度設為50
                            }
                            else if (value1.Length > 3)
                            {
                                //文字格式
                                mySheet1.SetColumnWidth(j, 30 * 256); //欄位寬度設為30
                            }
                            else
                            {
                                //文字格式
                                mySheet1.SetColumnWidth(j, 15 * 256); //欄位寬度設為15
                            }

                            XSSFCellStyle cellStyle = (XSSFCellStyle)workbook.CreateCellStyle(); // 給cell style
                            XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                            cellStyle.DataFormat = format.GetFormat("@"); // 文字格式

                            //建立字型
                            IFont StyleFont = workbook.CreateFont();
                            //設定文字字型
                            StyleFont.FontName = "微軟正黑體";
                            //設定文字大小
                            StyleFont.FontHeightInPoints = 12; //設定文字大小為12pt
                            cellStyle.SetFont(StyleFont);
                            //cellStyle.WrapText = true; //文字自動換列
                            cell.CellStyle = cellStyle;
                            cell.SetCellValue(value1);
                        }
                        {                             
                            //數字格式
                            cell.SetCellValue(value1);

                            ////自訂呈現格式
                            //XSSFCellStyle cellStyle = (XSSFCellStyle)workbook.CreateCellStyle(); // 給cell style
                            //XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                            //cellStyle.DataFormat = format.GetFormat("#,##0;[RED](#,##0)");
                            //cell.CellStyle = cellStyle;
                        }
                    }
                }
                //匯出
                workbook.Write(ms);

                //此為匯出副檔名xls 以上 XSSF 都要改成 HSSF
                //HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("Attachment; Filename=" + HttpUtility.UrlEncode(excelName) + ".xls"));
                //HttpContext.Current.Response.BinaryWrite(ms.ToArray());

                //此為匯出副檔名xlsx
                //方法一
                /*
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "AAA.xlsx"));
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();*/

                //方法二
                using (FileStream fs = new FileStream(@"C:\Users\TPE-Intern001\Desktop\20210203.xls", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))//写入指定的文件
                {
                    byte[] b = ms.ToArray();
                    fs.Write(b, 0, b.Length);
                    ms.Close();
                    fs.Flush();
                    fs.Close();
                }

                //釋放資源
                workbook = null;
                ms.Close();
                ms.Dispose();
            }
            catch (Exception)
            { }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ExportToFile(GridView1, "AAA");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            //string savePath = @"C:\Users\TPE-Intern001\Desktop\20210202.xls";
            //將使用者上傳的檔案
            if (FileUpload1.HasFile)
            {
                //string filename = FileUpload1.FileName;
                //savePath += filename;
                //FileUpload1.SaveAs(savePath);

                try
                {
                    //XSSFWorkbook 活頁簿
                    XSSFWorkbook myWorkbook = new XSSFWorkbook(FileUpload1.FileContent);

                    //建立XSSFSHEET 工作表
                    ISheet mySheet = myWorkbook.GetSheetAt(0);

                    //建立DATATABLE
                    DataTable myDT = new DataTable();

                    //抓取MYSHEET工作表中的標題欄位，並存入DATATABLE
                    XSSFRow headerRow = mySheet.GetRow(0) as XSSFRow;
                    for (int i = headerRow.FirstCellNum; i < headerRow.LastCellNum-1; i++)
                    {
                        if (headerRow.GetCell(i) != null)
                        {
                            DataColumn myColumn = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            myDT.Columns.Add(myColumn);

                        }
                    }

                    //抓取XSSFSHEET第一列以後的所有資料，並存入DATATABLE中
                    for (int i = mySheet.FirstRowNum + 1; i <= mySheet.LastRowNum; i++)
                    {
                        XSSFRow row = mySheet.GetRow(i) as XSSFRow;
                        DataRow myRow = myDT.NewRow();
                        for (int j = row.FirstCellNum; j < row.LastCellNum-1; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                myRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        myDT.Rows.Add(myRow);
                    }

                    //釋放活頁簿、工作表資源
                    myWorkbook = null;
                    mySheet = null;
                    DataView myView = new DataView(myDT);
                    GridView2.DataSource = myDT;
                    GridView2.DataBind();

                    Label9.Text = "上傳成功";
                }
                catch (Exception ex)
                {
                    Response.Write("thie Error Message---" + ex.ToString());
                }
            }
            else
            {
                Label9.Text = "請先挑選檔案之後";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }
    }
}