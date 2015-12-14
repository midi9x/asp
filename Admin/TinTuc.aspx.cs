using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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
        //viewstate dùng để sắp xếp
        ViewState["dt"] = data.GetAllBaiViet();
        ViewState["sort"] = "DESC";
    }

    //sắp xếp
    protected void grvBaiviet_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt1 = (DataTable)ViewState["dt"];
        if (dt1.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sort"]) == "Asc")
            {
                dt1.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sort"] = "Desc";
            }
            else
            {
                dt1.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sort"] = "Asc";
            }
            grvBaiviet.DataSource = dt1;
            grvBaiviet.DataBind();
        }
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