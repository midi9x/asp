using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
public partial class Login : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Thành viên đăng nhập";
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
    protected void btnDangnhap_Click(object sender, EventArgs e)
    {
        string tenDN = logintenDN.Text;
        string matKhau = loginmatKhau.Text;
        matKhau = GetMD5(matKhau);
        ThanhVien tv = data.GetAThanhVien(tenDN, matKhau);
        if (tv == null)
        {
            lblmsg.Text = "Sai tên đăng nhập hoặc mật khẩu";
            lblmsg.CssClass = "alert alert-danger col-sm-12";
        }
        else
        {
            Session["thanhvien"] = tv;
            Response.Redirect("/");
        }
    }
    protected void btnDangKy_Click(object sender, EventArgs e)
    {
        ThanhVien tv = new ThanhVien();
        tv.tenDN = txtTenDN.Text;
        string matKhau = txtMk.Text;
        tv.matKhau = GetMD5(matKhau);
        tv.email = txtEmail.Text;
        tv.hoTen = txtHoten.Text;
        tv.gioiTinh = Convert.ToInt32(ddGioitinh.Text);
        tv.ngayTao = Convert.ToDateTime(DateTime.Now);
        if (txtNgaySinh.Text!=null)tv.ngaySinh = Convert.ToDateTime(txtNgaySinh.Text);
        if (txtDiaChi.Text != null) tv.diaChi = txtDiaChi.Text;
        tv.trangThai = 1;
        if (tv.gioiTinh == 1) tv.anhDaiDien = "/Upload/Avatar/boy.jpg";
        else tv.anhDaiDien = "/Upload/Avatar/girl.jpg";
        data.ThemThanhVien(tv);
        Session["thanhvien"] = tv;
        Response.Redirect("/");
        
        
    }
    
}