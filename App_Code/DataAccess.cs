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
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id ORDER BY tblBaiViet.id DESC", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetAllBaiVietLimitOffSet(int limit,int offset)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"   SELECT TOP "+limit+ @" * 
                                                    FROM(
		                                                    SELECT 
		                                                    tblBaiViet.*, 
		                                                    tenCM ,
		                                                    ROW_NUMBER() OVER (ORDER BY tblBaiViet.id DESC) as offset 
		                                                    FROM tblBaiViet, tblChuyenMuc 
		                                                    WHERE tblBaiViet.id_CM = tblChuyenMuc.id 
	                                                    )   ROW 
                                                    WHERE offset >=" + offset + 1

        , con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetBaiVietTheoChuyenMuc(int id_cm)
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id AND id_cm=" + id_cm + " ORDER BY tblBaiViet.id DESC", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetBaiVietTheoChuyenMucLimitOffset(int id_cm, int limit,int offset)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"   SELECT TOP " + limit + @" * 
                                                    FROM(
		                                                    SELECT 
		                                                    tblBaiViet.*, 
		                                                    tenCM ,
		                                                    ROW_NUMBER() OVER (ORDER BY tblBaiViet.id DESC) as offset 
		                                                    FROM tblBaiViet, tblChuyenMuc 
		                                                    WHERE tblBaiViet.id_CM = tblChuyenMuc.id 
                                                            AND id_cm=" + id_cm + @"
	                                                    )   ROW 
                                                    WHERE offset >=" + offset + 1
        , con); 
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

    public void XoaChuyenMuc(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblChuyenMuc WHERE id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public BaiViet GetABaiViet(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = @"SELECT tblBaiViet.*, tenCM , hoTen
                            FROM tblChuyenMuc INNER JOIN tblBaiViet  
                            ON  tblBaiViet.id_CM = tblChuyenMuc.id 
                            INNER JOIN tblNguoiDung 
                            ON tblNguoiDung.id = tblBaiViet.id_ND
                            WHERE tblBaiViet.id = @id";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        BaiViet bv = new BaiViet();
        if (rd.Read())
        {
            bv.id_cm = Convert.ToInt32(rd["id_CM"]);
            bv.tenND = Convert.ToString(rd["hoTen"]);
            bv.id_nd = Convert.ToInt32(rd["id_ND"]);
            //bv.tenCM = Convert.ToString(rd["tenCM"]);
            bv.tieuDe = Convert.ToString(rd["tieuDe"]);
            bv.noiDung = Convert.ToString(rd["noiDung"]);
            bv.moTa = Convert.ToString(rd["moTa"]);;
            bv.tuKhoa  = Convert.ToString(rd["tuKhoa"]);
            bv.hinhAnh = Convert.ToString(rd["hinhAnh"]);
            bv.ngayTao = Convert.ToDateTime(rd["ngayTao"]);
            bv.trangThai = Convert.ToInt32(rd["trangThai"]);
            bv.luotXem = Convert.ToInt32(rd["luotXem"]);

        }
        con.Close();
        return bv;
    }
    public DataTable GetAllChuyenMuc()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM tblChuyenMuc", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public string GetTenChuyenMuc(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT tenCM FROM tblChuyenMuc WHERE id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        string tenCM = "";
        if (rd.Read())
        {
            tenCM = Convert.ToString(rd["tenCM"]);

        }
        con.Close();
        return tenCM;
      
    }
    public void ThemBaiViet(BaiViet bv)
    {
        string sql = "INSERT INTO tblBaiViet(id_cm, id_nd, tieuDe,noiDung, moTa, tuKhoa,hinhAnh,ngayTao) VALUES(@id_cm, @id_nd, @tieuDe,@noiDung, @moTa, @tuKhoa,@hinhAnh,@ngayTao)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.Parameters.AddWithValue("@id_cm", bv.id_cm);
        cmd.Parameters.AddWithValue("@id_nd", bv.id_nd);

        cmd.Parameters.Add("@tieuDe",SqlDbType.NText);
        cmd.Parameters["@tieuDe"].Value = bv.tieuDe;
        cmd.Parameters.AddWithValue("@noiDung", bv.noiDung);
        cmd.Parameters.AddWithValue("@moTa", bv.moTa);
        cmd.Parameters.AddWithValue("@tuKhoa", bv.tuKhoa);
        cmd.Parameters.AddWithValue("@hinhAnh", bv.hinhAnh);
        cmd.Parameters.AddWithValue("@ngayTao", bv.ngayTao);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void SuaBaiViet(BaiViet bv)
    {
        string sql = @"UPDATE tblBaiViet  set   id_cm=@id_cm, 
                                                id_nd=@id_nd, 
                                                tieuDe=@tieuDe,
                                                noiDung=@noiDung,
                                                moTa=@moTa, 
                                                tuKhoa=@tuKhoa,
                                                hinhAnh=@hinhAnh,
                                                trangThai=@trangThai
                                                WHERE id=@id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", bv.id);
        cmd.Parameters.AddWithValue("@id_cm", bv.id_cm);
        cmd.Parameters.AddWithValue("@id_nd", bv.id_nd);

        cmd.Parameters.Add("@tieuDe", SqlDbType.NText);
        cmd.Parameters["@tieuDe"].Value = bv.tieuDe;

        cmd.Parameters.Add("@noiDung", SqlDbType.NText);
        cmd.Parameters["@noiDung"].Value = bv.noiDung;

        cmd.Parameters.Add("@moTa", SqlDbType.NText);
        cmd.Parameters["@moTa"].Value = bv.moTa;

        cmd.Parameters.Add("@tuKhoa", SqlDbType.NText);
        cmd.Parameters["@tuKhoa"].Value = bv.tuKhoa;

        cmd.Parameters.AddWithValue("@hinhAnh", bv.hinhAnh);

        cmd.Parameters.AddWithValue("@trangThai", bv.trangThai);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void LuotXemBV(int id)
    {
        con.Open();
        string sql = "UPDATE tblBaiViet set luotXem = luotXem + 1 WHERE id=@id";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable GetAllNguoiDung()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM tblNguoiDung", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public NguoiDung GetANguoiDungId(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM tblNguoiDung WHERE id = @id";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        NguoiDung nd = new NguoiDung();
        if (rd.Read())
        {
            nd.id = Convert.ToInt32(rd["id"]);
            nd.tenDN = Convert.ToString(rd["tenDN"]);
            nd.matKhau = Convert.ToString(rd["matKhau"]);
            nd.hoTen = Convert.ToString(rd["hoTen"]);
            nd.email = Convert.ToString(rd["email"]);
            nd.ngayTao = Convert.ToDateTime(rd["ngayTao"]);
            nd.quyen = Convert.ToInt32(rd["quyen"]);
            nd.trangThai = Convert.ToInt32(rd["trangThai"]);
        }
        con.Close();
        return nd;
    }
    public NguoiDung GetANguoiDung(string tenDN, string matKhau)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM tblNguoiDung WHERE tenDN = @tenDN AND matKhau=@matKhau";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@tenDN", tenDN);
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        SqlDataReader rd = cmd.ExecuteReader();
        NguoiDung nd = new NguoiDung();
        if (rd.Read())
        {
            nd.id = Convert.ToInt32(rd["id"]);
            nd.tenDN = Convert.ToString(rd["tenDN"]);
            nd.matKhau = Convert.ToString(rd["matKhau"]);
            nd.hoTen = Convert.ToString(rd["hoTen"]);
            nd.email = Convert.ToString(rd["email"]);
            nd.ngayTao = Convert.ToDateTime(rd["ngayTao"]);
            nd.quyen = Convert.ToInt32(rd["quyen"]);
            nd.trangThai = Convert.ToInt32(rd["trangThai"]);
        }
        else
        {
            nd = null;
        }
        con.Close();
        return nd;
    }
    //thành viên
    public ThanhVien GetAThanhVienId(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM tblThanhVien WHERE id = @id";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        ThanhVien tv = new ThanhVien();
        if (rd.Read())
        {
            tv.id = Convert.ToInt32(rd["id"]);
            tv.tenDN = Convert.ToString(rd["tenDN"]);
            tv.matKhau = Convert.ToString(rd["matKhau"]);
            tv.hoTen = Convert.ToString(rd["hoTen"]);
            tv.email = Convert.ToString(rd["email"]);
            tv.ngaySinh = Convert.ToDateTime(rd["ngaySinh"]);
            tv.gioiTinh = Convert.ToInt32(rd["gioiTinh"]);
            tv.diaChi = Convert.ToString(rd["diaChi"]);
            tv.ngayTao = Convert.ToDateTime(rd["ngayTao"]);
            tv.anhDaiDien = Convert.ToString(rd["anhDaiDien"]);
            tv.trangThai = Convert.ToInt32(rd["trangThai"]);
        }
        else
        {
            tv = null;
        }
        con.Close();
        return tv;
    }
    public ThanhVien GetAThanhVien(string tenDN, string matKhau)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM tblThanhVien WHERE tenDN = @tenDN AND matKhau=@matKhau";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@tenDN", tenDN);
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        SqlDataReader rd = cmd.ExecuteReader();
        ThanhVien tv = new ThanhVien();
        if (rd.Read())
        {
            tv.id = Convert.ToInt32(rd["id"]);
            tv.tenDN = Convert.ToString(rd["tenDN"]);
            tv.matKhau = Convert.ToString(rd["matKhau"]);
            tv.hoTen = Convert.ToString(rd["hoTen"]);
            tv.email = Convert.ToString(rd["email"]);
            tv.ngaySinh = Convert.ToDateTime(rd["ngaySinh"]);
            tv.gioiTinh = Convert.ToInt32(rd["gioiTinh"]);
            tv.diaChi = Convert.ToString(rd["diaChi"]);
            tv.ngayTao = Convert.ToDateTime(rd["ngayTao"]);
            tv.anhDaiDien = Convert.ToString(rd["anhDaiDien"]);
            tv.trangThai = Convert.ToInt32(rd["trangThai"]);
        }
        else
        {
            tv = null;
        }
        con.Close();
        return tv;
    }

    //binh luan
    public DataTable GetAllBinhLuan()
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblBinhLuan.*, tieuDe,hoTen,tenDN
                                                    FROM tblBaiViet INNER JOIN  tblBinhLuan
                                                    ON  tblBinhLuan.id_BV = tblBaiViet.id
                                                    INNER JOIN tblThanhVien 
                                                    ON tblBinhLuan.id_TV = tblThanhVien.id
        ", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }

    public DataTable GetBinhLuanBV(int id)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblBinhLuan.*,tieuDe,hoTen,tenDN,anhDaiDien
                                                FROM tblBaiViet INNER JOIN tblBinhLuan
                                                ON tblBaiViet.id = tblBinhLuan.id_BV
                                                INNER JOIN tblThanhVien 
                                                ON tblBinhLuan.id_TV = tblThanhVien.id
                                                WHERE tblBaiViet.id= " +id
        , con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public void ThemBinhLuan(BinhLuan bl)
    {
        string sql = "INSERT INTO tblBinhLuan(id_TV, id_BV, noiDung,ngayGui,trangThai) VALUES(@id_TV, @id_BV, @noiDung,@ngayGui,1)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id_TV", bl.id_TV);
        cmd.Parameters.AddWithValue("@id_BV", bl.id_BV);
        cmd.Parameters.AddWithValue("@ngayGui", bl.ngayGui);
        cmd.Parameters.Add("@noiDung", SqlDbType.NText);
        cmd.Parameters["@noiDung"].Value = bl.noiDung;
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