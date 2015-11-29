using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NguoiDung : System.Web.UI.Page
{

    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    protected void grNguoiDung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grNguoiDung.PageIndex = e.NewPageIndex;
        FillData();
    }
    public void FillData()
    {
        grNguoiDung.DataSource = data.GetAllNguoiDung();
        grNguoiDung.DataBind();
    }
    protected void btnXoa(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        data.XoaNguoiDung(id);
        FillData();
    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grNguoiDung.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grNguoiDung.DataKeys[row.RowIndex].Value.ToString());
                data.XoaNguoiDung(id);

            }
        }
        FillData();
    }
}