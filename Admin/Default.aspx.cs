using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Trang quản trị";
        dtBaiviet.DataSource = data.GetAllBaiVietLimitOffSet(5, 0);
        dtBaiviet.DataBind();
        dtBinhLuan.DataSource = data.GetAllBinhLuanLimit(5);
        dtBinhLuan.DataBind();
        lblBinhluan.Text = data.SoBinhLuan().ToString();
        lblLienHe.Text = data.SoLienHe().ToString();
        lblThanhvien.Text = data.SoThanhVien().ToString();
    }
}