using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        BaiViet bv = new BaiViet();
        //get bài viết theo id
        int id = Convert.ToInt32(Request.QueryString["id"]);
        bv = data.GetABaiViet(id);
        //đổ dữ liệu lên view
        lblTieude.Text = bv.tieuDe;
        lblChuyenmuc.Text = data.GetTenChuyenMuc(bv.id_cm);
        lblCM.Text = data.GetTenChuyenMuc(bv.id_cm);
        lblNgaydang.Text = bv.ngayTao.ToString();
        lblXem.Text = bv.luotXem.ToString();
        lblNoidung.Text = bv.noiDung;
        lbltenND.Text = bv.tenND;
        //title, description, keyword meta
        Page.Title = bv.tieuDe;
        Page.MetaDescription = bv.moTa;
        Page.MetaKeywords = bv.tuKhoa;
        //luot xem
        data.LuotXemBV(id);
        dataBinhLuan.DataSource = data.GetBinhLuanBV(id);
        dataBinhLuan.DataBind();
        //nếu chưa login
    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        BinhLuan bl = new BinhLuan();
        ThanhVien tv = (ThanhVien)Session["thanhvien"];
        bl.id_BV = Convert.ToInt32(Request.QueryString["id"]);
        bl.id_TV = tv.id;
        bl.noiDung = txtNoidung.Text;
        bl.ngayGui = Convert.ToDateTime(DateTime.Now.ToString());
        data.ThemBinhLuan(bl);
        Response.Redirect("Post.aspx?id="+bl.id_BV+"#binhluan");
    }
}