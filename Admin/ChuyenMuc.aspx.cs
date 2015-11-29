using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChuyenMuc : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddCha.DataSource = data.GetAllChuyenMuc();
            ddCha.DataTextField = "tenCM";
            ddCha.DataValueField = "id";
            ddCha.DataBind();
            FillData();
        }

    }
    protected void FillData()
    {
        grvChuyenMuc.DataSource = data.GetAllChuyenMuc();
        grvChuyenMuc.DataBind();
    }
    protected void Xoa(object sender, CommandEventArgs e)
    {
        try
        {
            int id = Convert.ToInt16(e.CommandArgument);
            data.XoaChuyenMuc(id);
            FillData();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Có lỗi xảy xa: " + ex.Message;
        }

    }
}