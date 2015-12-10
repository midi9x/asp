using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_ThemTin : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddChuyenMuc.DataSource = data.GetAllChuyenMuc();
            ddChuyenMuc.DataValueField = "id";
            ddChuyenMuc.DataTextField = "tenCM";
            ddChuyenMuc.DataBind();
        }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        BaiViet bv = new BaiViet();
        bv.tieuDe = txtTieuDe.Text;
        bv.id_cm=Convert.ToInt16(ddChuyenMuc.Text.ToString());
        NguoiDung nd = (NguoiDung)Session["login"];
        bv.id_nd = nd.id;//id nguoi dung
        bv.noiDung=txtNoiDung.Text;
        bv.moTa=txtMota.Text;
        bv.tuKhoa=txtTuKhoa.Text;      
        //file upload
        string path = Server.MapPath("~/Upload/")+hinhAnh.FileName;
        hinhAnh.PostedFile.SaveAs(path);
        bv.hinhAnh = "/Upload/" + hinhAnh.FileName;
        //end upload
        bv.ngayTao=Convert.ToDateTime(DateTime.Now.ToString());
        bv.trangThai = Convert.ToInt32(rdtrangThai.Text);
        if (nd.quyen == 0) bv.phanLoai = 0;//nếu quyền = 0 thì phân loại = 0 => phải kiểm duyệt
        else bv.phanLoai = 1;//nếu quyền = 1 thì không phải kiểm duyệt bài viết
        data.ThemBaiViet(bv);
        Response.Redirect("TinTuc.aspx");
    }
}