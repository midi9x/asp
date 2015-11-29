using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
public partial class TaiKhoan : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ThanhVien tv = new ThanhVien();
            tv = (ThanhVien)Session["thanhvien"];
            lblTenDN.Text = tv.tenDN;
            txtHoten.Text = tv.hoTen;
            txtEmail.Text = tv.email;
            txtNgaySinh.Text = tv.ngaySinh.ToString();
            ddGioitinh.Text = tv.gioiTinh.ToString();
            txtDiachi.Text = tv.diaChi;
            imgAnh.ImageUrl = tv.anhDaiDien;
        }
        
    }

    protected void btnCapnhat_Click(object sender, EventArgs e)
    {
        ThanhVien tvo = (ThanhVien)Session["thanhvien"];
        ThanhVien tv = new ThanhVien();
        tv.id = tvo.id;
        tv.tenDN = tvo.tenDN;
        tv.matKhau = tvo.matKhau;
        tv.hoTen = txtHoten.Text;
        tv.email = txtEmail.Text;
        tv.ngaySinh = Convert.ToDateTime(txtNgaySinh.Text);
        tv.gioiTinh = Convert.ToInt32(ddGioitinh.Text);
        tv.diaChi = txtDiachi.Text;
        if(txtAnh.HasFile)
        {
            string path = Server.MapPath("~/Upload/Avatar/") + txtAnh.FileName;
            txtAnh.PostedFile.SaveAs(path);
            tv.anhDaiDien = "/Upload/Avatar/" + txtAnh.FileName;
        }
        else
        {
            tv.anhDaiDien = imgAnh.ImageUrl;
        }
        data.SuaThanhVien(tv);
        Session["thanhvien"] = tv;
        Response.Redirect("TaiKhoan.aspx");
    }
    protected void btnMK_Click(object sender, EventArgs e)
    {
        ThanhVien tvo = (ThanhVien)Session["thanhvien"];
        string mkcu = GetMD5(txtmkcu.Text);
        if (mkcu != tvo.matKhau)
        {
            Response.Write("<script>alert('Mật khẩu cũ không chính xác');</script>");
        }
        else if( txtmkmoi.Text != txtremkmoi.Text){
            Response.Write("<script>alert('Mật khẩu không khớp');</script>");
        }
        else if(txtmkmoi.Text =="" ||  txtremkmoi.Text=="")
        {
            Response.Write("<script>alert('Nhập mk mới');</script>");
        }
        else{
            ThanhVien tv = new ThanhVien();
            tv.id = tvo.id;
            tv.matKhau = GetMD5(txtmkmoi.Text);
            data.DoiMkThanhVien(tv);
            Response.Redirect("TaiKhoan.aspx");
        }
        
    }
    public static string GetMD5(string str)
    {

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

        StringBuilder sbHash = new StringBuilder();

        foreach (byte b in bHash)
        {

            sbHash.Append(String.Format("{0:x2}", b));

        }

        return sbHash.ToString();

    }
}