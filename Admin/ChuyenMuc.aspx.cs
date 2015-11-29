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
            ListItem lst = new ListItem("===>Không<===", "0");
            ddCha.Items.Insert(0, lst);
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                ChuyenMuc cm = new ChuyenMuc();
                //get cm
                cm = data.GetAChuyenMuc(id);
                tenCM.Text = cm.tenCM;
                moTa.Text = cm.moTa;
                tuKhoa.Text = cm.tuKhoa;
                ddCha.Text = cm.idCha.ToString();
            }
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
    protected void btnThem_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        if (id > 0)
        {
            //cap nhat
            ChuyenMuc cm = new ChuyenMuc();
            cm.id = id;
            cm.tenCM = tenCM.Text;
            cm.moTa = moTa.Text;
            cm.tuKhoa = tuKhoa.Text;
            cm.idCha = Convert.ToInt32(ddCha.Text);
            data.SuaChuyenMuc(cm);
            Response.Redirect("ChuyenMuc.aspx");
        }
        else
        {
            //them moi
            ChuyenMuc cm = new ChuyenMuc();
            cm.tenCM = tenCM.Text;
            cm.moTa = moTa.Text;
            cm.tuKhoa = tuKhoa.Text;
            cm.idCha = Convert.ToInt32(ddCha.Text);
            data.ThemChuyenMuc(cm);
            Response.Redirect("ChuyenMuc.aspx");
        }
    }
    protected void grvChuyenMuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvChuyenMuc.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvChuyenMuc.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grvChuyenMuc.DataKeys[row.RowIndex].Value.ToString());
                data.XoaChuyenMuc(id);

            }
        }
        FillData();
    }
}
