using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    DataAccess data = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            CauHinh ch = data.GetCauHinh();
            Page.Title = ch.tieuDe;
            Page.MetaDescription = ch.moTa;
            Page.MetaKeywords = ch.tuKhoa;
            //

            Datalist1.DataSource = data.GetAllBaiVietLimitOffSet(1,0);
            Datalist1.DataBind();
            Datalist2.DataSource = data.GetAllBaiVietLimitOffSet(6,1);
            Datalist2.DataBind();
            dataCongnghe1.DataSource = data.GetAllBaiVietLimitOffSet(1, 0);
            dataCongnghe1.DataBind();
            dataCongnghe2.DataSource = data.GetAllBaiVietLimitOffSet(3,1);
            dataCongnghe2.DataBind();
            //
            dataANXH1.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(9,1,0);
            dataANXH1.DataBind();
            dataANXH2.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(9,3,0);
            dataANXH2.DataBind();
            //
            dataBongda1.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(5, 1, 0);
            dataBongda1.DataBind();
            dataBongda2.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(5, 3, 0);
            dataBongda2.DataBind();
            //
            dataTG.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(1,3, 0);
            dataTG.DataBind();
            //
            dataDulich1.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(10, 1, 0);
            dataDulich1.DataBind();
            dataDulich2.DataSource = data.GetBaiVietTheoChuyenMucLimitOffset(10, 3, 0);
            dataDulich2.DataBind();
        }
    }
}