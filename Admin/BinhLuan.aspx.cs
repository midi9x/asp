using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BinhLuan : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    protected void grBinhluan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grBinhluan.PageIndex = e.NewPageIndex;
        FillData();
    }
    public void FillData()
    {
        grBinhluan.DataSource = data.GetAllBinhLuan();
        grBinhluan.DataBind();
    }
    protected void btnXoa(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        data.XoaBinhLuan(id);
        FillData();
        
    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grBinhluan.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grBinhluan.DataKeys[row.RowIndex].Value.ToString());
                data.XoaBinhLuan(id);

            }
        }
        FillData();
    }
}