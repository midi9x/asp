using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    public SqlConnection con = new SqlConnection("data source=MINHDINH;initial catalog=tintuc;user id=sa;password=123456");
    public DataTable GetAllBaiViet()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable SearchBaiViet(string tukhoa)
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id AND tieuDe like '%"+tukhoa+"%'", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public void XoaBaiViet(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblBaiViet WHERE id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
	public DataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}