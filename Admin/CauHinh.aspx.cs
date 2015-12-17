using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CauHinh : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CauHinh ch = data.GetCauHinh();
            txtTieude.Text = ch.tieuDe;
            txtMota.Text = ch.moTa;
            txtTuKhoa.Text = ch.tuKhoa;
            logo.ImageUrl = ch.logo;
        }
        

    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            CauHinh ch = new CauHinh();
            ch.tieuDe = txtTieude.Text;
            ch.moTa = txtMota.Text;
            ch.tuKhoa = txtTuKhoa.Text;
            if (imgAnh.HasFile)
            {
                string path = Server.MapPath("~/Upload/") + imgAnh.FileName;
                imgAnh.PostedFile.SaveAs(path);
                ch.logo = "/Upload/" + imgAnh.FileName;
            }
            else ch.logo = logo.ImageUrl;
            data.SuaCauHinh(ch);
            Response.Redirect("CauHinh.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert("+ex.Message+");</script>");
        }
    }
}