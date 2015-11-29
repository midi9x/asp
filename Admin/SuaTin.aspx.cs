using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SuaTin : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataAccess data = new DataAccess();
            ddChuyenMuc.DataSource = data.GetAllChuyenMuc();
            ddChuyenMuc.DataValueField = "id";
            ddChuyenMuc.DataTextField = "tenCM";
            ddChuyenMuc.DataBind();
            BaiViet bv = new BaiViet();
            bv = data.GetABaiViet(Convert.ToInt32(Request.QueryString["id"]));
            txtTieuDe.Text = bv.tieuDe.ToString();
            ddChuyenMuc.Text = bv.id_cm.ToString();
            oldHinhAnh.ImageUrl = bv.hinhAnh.ToString();
            txtNoiDung.Text = bv.noiDung;
            txtMota.Text = bv.moTa;
            txtTuKhoa.Text = bv.tuKhoa;
            if (bv.trangThai == 1) rd1.Checked = true;
            else rd0.Checked = true;

            //if (rdv.Equals(1)
            //{
            //    rdtrangThai.Items.FindByValue("1").Selected = true;
            //    rdtrangThai.Items.FindByValue("0").Selected = false;
            //}
            //else
            //{
            //    rdtrangThai.Items.FindByValue("0").Selected = true;
            //    rdtrangThai.Items.FindByValue("1").Selected = false;
            //}
            

        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        BaiViet bv = new BaiViet();
        bv.id=Convert.ToInt32(Request.QueryString["id"]);
        bv.tieuDe = txtTieuDe.Text;
        bv.id_cm = Convert.ToInt16(ddChuyenMuc.Text.ToString());
        bv.id_nd = 2;
        bv.noiDung = txtNoiDung.Text;
        bv.moTa = txtMota.Text;
        bv.tuKhoa = txtTuKhoa.Text;
        //file upload
        if (hinhAnh.HasFile)
        {
            string path = Server.MapPath("~/Upload/") + hinhAnh.FileName;
            hinhAnh.PostedFile.SaveAs(path);
            bv.hinhAnh = "/Upload/" + hinhAnh.FileName;
        }
        else bv.hinhAnh = oldHinhAnh.ImageUrl;
        if (rd1.Checked)
        {
            bv.trangThai = 1;
        }
        else bv.trangThai = 0;
        //end upload
        data.SuaBaiViet(bv);
        Response.Redirect("TinTuc.aspx");

    }
}