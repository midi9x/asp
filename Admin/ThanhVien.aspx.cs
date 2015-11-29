using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ThanhVien : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    protected void grThanhVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grThanhVien.PageIndex = e.NewPageIndex;
        FillData();
    }
    public void FillData()
    {
        grThanhVien.DataSource = data.GetAllThanhVien();
        grThanhVien.DataBind();
    }
    protected void btnXoa(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        data.XoaThanhVien(id);
        FillData();
    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grThanhVien.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grThanhVien.DataKeys[row.RowIndex].Value.ToString());
                data.XoaThanhVien(id);

            }
        }
        FillData();
    }
}