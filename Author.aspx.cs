using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Author : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        DataTable pTable;
        if (id > 0)
        {
            lblTencm.Text = data.GetTenTacGia(id);
            Page.Title = data.GetTenTacGia(id) + "- Tin tức 24h";
            pTable = data.GetBaiVietTheoTacGia(id);
            //phan trang
            //khởi tạo pagedatasource 
            PagedDataSource pagesource;
            pagesource = new PagedDataSource();
            //gán nguồn dữ liệu 
            pagesource.DataSource = pTable.DefaultView;
            //cho phép phân trang 
            pagesource.AllowPaging = true;
            //thiết lập kích thước trang 
            pagesource.PageSize = 5;
            //xử lý việc nhận số trang khi người dùng kích vào link 
            int pageno = 1;
            try
            {
                pageno = int.Parse(Request["page"]);
                if (pageno < 1)
                    pageno = 1;
                if (pageno > pagesource.PageCount)
                    pageno = pagesource.PageCount;
            }
            catch
            {

            }
            //gán trang hiện tại 
            pagesource.CurrentPageIndex = pageno - 1;
            //thực hiện việc sinh ra link 
            lblPage.Text = "<div  class=\"paging\"> ";
            for (int i = 1; i <= pagesource.PageCount; i++)
            {
                if (i == pageno)
                    lblPage.Text += "<a class=\"active\"> " + i + "</a> ";
                else
                    lblPage.Text += " <a class=\"noactive\" href='" + "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.Url.AbsolutePath + "?id=" + id + "&page=" + i + "'>" + i
                   + "</a> ";
            }
            lblPage.Text += "</div>";
            dataBaiViet.DataSource = pagesource;
            dataBaiViet.DataBind();
        }
        else
        {
            lblTencm.Text = "Tin tức 24h";
            Page.Title = "Tin tức 24h";
            Response.Redirect("/");
        }
        
    }
}


