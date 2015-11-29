using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LienHe : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    protected void grLienHe_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grLienHe.PageIndex = e.NewPageIndex;
        FillData();
    }
    public void FillData()
    {
        grLienHe.DataSource = data.GetAllLienHe();
        grLienHe.DataBind();
    }
    protected void btnXoa(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        data.XoaLienHe(id);
        FillData();

    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grLienHe.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grLienHe.DataKeys[row.RowIndex].Value.ToString());
                data.XoaLienHe(id);

            }
        }
        FillData();
    }
}