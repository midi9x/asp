using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TinTuc : System.Web.UI.Page
{
    DataAccess data = new DataAccess();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillData();
        }
       
    }

    public void FillData()
    {
        grvBaiviet.DataSource = data.GetAllBaiViet();
        grvBaiviet.DataBind();
    }


    protected void Xoa(object sender, CommandEventArgs e)
    {
        try
        {
            int id = Convert.ToInt16(e.CommandArgument);
            data.XoaBaiViet(id);
            FillData();
        }
        catch(Exception ex)
        {
            lblmsg.Text = "Có lỗi xảy xa: " + ex.Message;
        }
        
    }
   
    protected void grvBaiviet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvBaiviet.PageIndex = e.NewPageIndex;   
        FillData();
    }
    protected void btnXoaN_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvBaiviet.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkEmp");

            if (checkbox.Checked)
            {
                int id = Convert.ToInt32(grvBaiviet.DataKeys[row.RowIndex].Value.ToString());
                data.XoaBaiViet(id);
                
            }
        }
        FillData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        grvBaiviet.DataSource = data.SearchBaiViet(txtKey.Text) ;
        grvBaiviet.DataBind();
    }
}