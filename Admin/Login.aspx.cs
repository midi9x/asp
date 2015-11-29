using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class Admin_Login : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Đăng nhập hệ thống";
    }
    protected void btnDangnhap_Click(object sender, EventArgs e)
    {
        string tenDN = logintenDN.Text;
        string matKhau = loginmatKhau.Text;
        matKhau = GetMD5(matKhau);
        NguoiDung nd = data.GetANguoiDung(tenDN, matKhau);
        if (nd == null)
        {
            lblmsg.Text = "Sai tên đăng nhập hoặc mật khẩu";
            lblmsg.CssClass = "alert alert-danger col-sm-12";
        }
        else
        {
            Session["login"] = nd;
            Response.Redirect("/Admin");
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