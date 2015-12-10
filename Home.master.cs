using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.MasterPage
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            dataXemnhieu.DataSource = data.GetAllBaiVietLimitOffSet(3, 0);
            dataXemnhieu.DataBind();
            dataTin.DataSource=data.GetAllBaiVietLimitOffSet(2,0);
            dataTin.DataBind();

            dtBaiviet.DataSource = data.GetAllBaiVietLimitOffSet(10, 0);
            dtBaiviet.DataBind();
            //cauhinh
        }
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string tukhoa = txtTuKhoa.Text;
        Response.Redirect("Search.aspx?tukhoa=" + tukhoa);
    }
}
