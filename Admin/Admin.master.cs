using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null) Response.Redirect("Login.aspx");
        else
        {
            NguoiDung nd = (NguoiDung)Session["login"];
            lblTenND.Text = nd.tenDN;
        }
    }
}
