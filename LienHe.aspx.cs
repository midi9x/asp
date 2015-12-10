using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LienHe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCapnhat_Click(object sender, EventArgs e)
    {
        DataAccess data = new DataAccess();
        ThanhVien tv = (ThanhVien)Session["thanhvien"];
        PhanHoi ph = new PhanHoi();
        ph.id_TV = tv.id;
        ph.tieuDe = txtTieuDe.Text;
        ph.noiDung = txtNoiDung.Text;
        ph.ngayGui = Convert.ToDateTime(DateTime.Now);
        data.ThemLienHe(ph);
        Response.Write("<script>alert('Cảm ơn bạn đã gửi liên hệ với chúng tôi');</script>");
        txtNoiDung.Text = "";
        txtTieuDe.Text = "";
        //Response.Redirect("/");
    }
}