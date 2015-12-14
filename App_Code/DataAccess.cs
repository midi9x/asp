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
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1 ORDER BY tblBaiViet.id DESC", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable BaiVietXemNhieu()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT TOP 4 tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1 ORDER BY tblBaiViet.luotXem DESC", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetAllBaiVietDuyet()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id AND tblBaiViet.phanLoai = 0 ORDER BY tblBaiViet.id DESC", con);
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
                                                             AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1
	                                                    )   ROW 
                                                    WHERE offset >=" + offset + 1

        , con);

        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetBaiVietTheoChuyenMuc(int id_cm)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblBaiViet.*, 
                                                        tenCM FROM tblBaiViet, 
                                                        tblChuyenMuc 
                                                        WHERE tblBaiViet.id_CM = tblChuyenMuc.id  
                                                        AND tblBaiViet.phanLoai = 1 
                                                        AND tblBaiViet.trangThai = 1 
                                                        AND id_cm= @id_cm   ORDER BY tblBaiViet.id DESC", con);
        ad.SelectCommand.Parameters.Add(new SqlParameter
        {
            ParameterName = "@id_cm",
            Value = id_cm,
            SqlDbType = SqlDbType.Int,
        });
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetBaiVietTheoTacGia(int id)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblBaiViet.*, tenDN FROM tblBaiViet, 
                                                tblNguoiDung WHERE tblBaiViet.id_ND = tblNguoiDung.id  
                                                AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1 
                                                AND id_ND= @id  ORDER BY tblBaiViet.id DESC",con);
        ad.SelectCommand.Parameters.Add(new SqlParameter
        {
            ParameterName = "@id",
            Value = id,
            SqlDbType = SqlDbType.Int,
        });
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
                                                             AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1
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
        SqlDataAdapter ad = new SqlDataAdapter("SELECT tblBaiViet.*, tenCM FROM tblBaiViet, tblChuyenMuc WHERE tblBaiViet.id_CM = tblChuyenMuc.id  AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1 AND (tieuDe like '% " + tukhoa + "%' OR noiDung like '% " + tukhoa + "%')", con);
        ad.SelectCommand.Parameters.Add(new SqlParameter
        {
            ParameterName = "@tukhoa",
            Value = tukhoa,
            SqlDbType = SqlDbType.NText,
        });
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
    //duyet bai viet
    public void DuyetBaiViet(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE  tblBaiViet SET phanLoai=1 WHERE id = @id", con);
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
                            WHERE tblBaiViet.id = @id
                            AND tblBaiViet.phanLoai = 1 AND tblBaiViet.trangThai = 1
                            ";
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
        else
        {
            bv = null;
        }
        con.Close();
        return bv;
    }
    //chuyen muc
    public ChuyenMuc GetAChuyenMuc(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM tblChuyenMuc WHERE id=@id";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        ChuyenMuc cm = new ChuyenMuc();
        if (rd.Read())
        {
            cm.id = Convert.ToInt32(rd["id"]);
            cm.tenCM = Convert.ToString(rd["tenCM"]);
            cm.moTa = Convert.ToString(rd["moTa"]);
            cm.tuKhoa = Convert.ToString(rd["tuKhoa"]);
            cm.idCha = Convert.ToInt32(rd["idCha"]);
        }
        con.Close();
        return cm;
    }
    public void XoaChuyenMuc(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblChuyenMuc WHERE id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable GetAllChuyenMuc()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM tblChuyenMuc order by id DESC", con);
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
    public string GetTenTacGia(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT tenDN FROM tblNguoiDung WHERE id = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader rd = cmd.ExecuteReader();
        string tenDN = "";
        if (rd.Read())
        {
            tenDN = Convert.ToString(rd["tenDN"]);

        }
        con.Close();
        return tenDN;

    }
    public void ThemChuyenMuc(ChuyenMuc cm)
    {
        string sql = "INSERT INTO tblChuyenMuc(tenCM, moTa, tuKhoa,idCha) VALUES (@tenCM, @moTa, @tuKhoa,@idCha)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@idCha", cm.idCha);

        cmd.Parameters.Add("@tenCM", SqlDbType.NText);
        cmd.Parameters["@tenCM"].Value = cm.tenCM;

        cmd.Parameters.Add("@moTa", SqlDbType.NText);
        cmd.Parameters["@moTa"].Value = cm.moTa;

        cmd.Parameters.Add("@tuKhoa", SqlDbType.NText);
        cmd.Parameters["@tuKhoa"].Value = cm.tuKhoa;

        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void SuaChuyenMuc(ChuyenMuc cm)
    {
        string sql = "Update tblChuyenMuc set tenCM=@tenCM, moTa=@moTa, tuKhoa=@tuKhoa,idCha=@idCha WHERE id=@id" ;
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", cm.id);
        cmd.Parameters.AddWithValue("@idCha", cm.idCha);

        cmd.Parameters.Add("@tenCM", SqlDbType.NText);
        cmd.Parameters["@tenCM"].Value = cm.tenCM;

        cmd.Parameters.Add("@moTa", SqlDbType.NText);
        cmd.Parameters["@moTa"].Value = cm.moTa;

        cmd.Parameters.Add("@tuKhoa", SqlDbType.NText);
        cmd.Parameters["@tuKhoa"].Value = cm.tuKhoa;

        cmd.ExecuteNonQuery();
        con.Close();
    }
    //----
    public void ThemBaiViet(BaiViet bv)
    {
        string sql = "INSERT INTO tblBaiViet(id_cm, id_nd, tieuDe,noiDung, moTa, tuKhoa,hinhAnh,ngayTao,phanLoai,trangThai) VALUES(@id_cm, @id_nd, @tieuDe,@noiDung, @moTa, @tuKhoa,@hinhAnh,@ngayTao,@phanLoai,@trangThai)";
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
        cmd.Parameters.AddWithValue("@phanLoai", bv.phanLoai);
        cmd.Parameters.AddWithValue("@trangThai", bv.trangThai);
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
    //nguoidung
    public DataTable GetAllNguoiDung()
    {
        SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM tblNguoiDung order by id desc", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public void XoaNguoiDung(int id)
    {
        string sql = @"Delete from tblNguoiDung  WHERE id=@id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
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
    public void ThemThanhVien(ThanhVien tv)
    {
        string sql = @"INSERT INTO tblThanhVien(tenDN,matKhau,hoTen,email,ngaySinh,gioiTinh,diaChi,ngayTao,anhDaiDien,trangThai) 
                                                VALUES(@tenDN,@matKhau,@hoTen,@email,@ngaySinh,@gioiTinh,@diaChi,@ngayTao,@anhDaiDien,@trangThai)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("tenDN", tv.tenDN);
        cmd.Parameters.AddWithValue("@matKhau", tv.matKhau);
        cmd.Parameters.AddWithValue("@email", tv.email);
        cmd.Parameters.AddWithValue("@ngaySinh", tv.ngaySinh);
        cmd.Parameters.AddWithValue("@gioiTinh", tv.gioiTinh);
        cmd.Parameters.AddWithValue("@anhDaiDien", tv.anhDaiDien);
        cmd.Parameters.AddWithValue("@trangThai", tv.trangThai);
        cmd.Parameters.AddWithValue("@ngayTao", tv.ngayTao);
        cmd.Parameters.Add("@hoTen", SqlDbType.NText);
        cmd.Parameters["@hoTen"].Value = tv.hoTen;
        cmd.Parameters.Add("@diaChi", SqlDbType.NText);
        cmd.Parameters["@diaChi"].Value = tv.diaChi;
        cmd.ExecuteNonQuery();
        con.Close();
    }
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
    public void SuaThanhVien(ThanhVien tv)
    {
        string sql = @"UPDATE tblThanhVien  set hoTen=@hoTen,
                                                email=@email,
                                                ngaySinh=@ngaySinh, 
                                                gioiTinh=@gioiTinh,
                                                diaChi=@diaChi,
                                                anhDaiDien=@anhDaiDien
                                                WHERE id=@id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", tv.id);
        //cmd.Parameters.AddWithValue("@tenDN", tv.tenDN);
        //cmd.Parameters.AddWithValue("@matKhau", tv.matKhau);
        cmd.Parameters.AddWithValue("@email", tv.email);
        cmd.Parameters.AddWithValue("@ngaySinh", tv.ngaySinh);
        cmd.Parameters.AddWithValue("@gioiTinh", tv.gioiTinh);
        cmd.Parameters.AddWithValue("@anhDaiDien", tv.anhDaiDien);
        cmd.Parameters.Add("@hoTen", SqlDbType.NText);
        cmd.Parameters["@hoTen"].Value = tv.hoTen;

        cmd.Parameters.Add("@diaChi", SqlDbType.NText);
        cmd.Parameters["@diaChi"].Value = tv.diaChi;

        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void DoiMkThanhVien(ThanhVien tv)
    {
        string sql = @"UPDATE tblThanhVien  set matKhau = @matKhau WHERE id=@id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", tv.id);
        cmd.Parameters.AddWithValue("@matKhau", tv.matKhau);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void XoaThanhVien(int id)
    {
        string sql = @"Delete from tblThanhVien  WHERE id=@id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable GetAllThanhVien()
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT * from tblThanhVien order by id desc", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    //binh luan
    public DataTable GetAllBinhLuan()
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblBinhLuan.*, tieuDe,hoTen,tenDN
                                                    FROM tblBaiViet INNER JOIN  tblBinhLuan
                                                    ON  tblBinhLuan.id_BV = tblBaiViet.id
                                                    INNER JOIN tblThanhVien 
                                                    ON tblBinhLuan.id_TV = tblThanhVien.id
                                                    order by id desc
        ", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public DataTable GetAllBinhLuanLimit(int limit)
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT TOP "+limit+ @" tblBinhLuan.*, tieuDe,hoTen,tenDN
                                                    FROM tblBaiViet INNER JOIN  tblBinhLuan
                                                    ON  tblBinhLuan.id_BV = tblBaiViet.id
                                                    INNER JOIN tblThanhVien 
                                                    ON tblBinhLuan.id_TV = tblThanhVien.id
                                                    order by id desc 
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
    public void XoaBinhLuan(int id)
    {
        string sql = "DELETE FROM tblBinhLuan WHERE id = @id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
        
    }
    // phan hoi
    public DataTable GetAllLienHe()
    {
        SqlDataAdapter ad = new SqlDataAdapter(@"SELECT tblPhanHoi.*,tenDN
                                                    FROM tblPhanHoi INNER JOIN  tblThanhVien 
                                                    ON tblPhanHoi.id_TV = tblThanhVien.id
                                                    order by id desc
        ", con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        return dt;
    }
    public void ThemLienHe(PhanHoi ph)
    {
        string sql = "INSERT INTO tblPhanHoi(id_TV, tieuDe , noiDung,ngayGui) VALUES(@id_TV,@tieuDe, @noiDung,@ngayGui)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id_TV", ph.id_TV);
        cmd.Parameters.AddWithValue("@ngayGui", ph.ngayGui);
        cmd.Parameters.Add("@tieuDe", SqlDbType.NText);
        cmd.Parameters["@tieuDe"].Value = ph.tieuDe;
        cmd.Parameters.Add("@noiDung", SqlDbType.NText);
        cmd.Parameters["@noiDung"].Value = ph.noiDung;
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void XoaLienHe(int id)
    {
        string sql = "DELETE FROM tblPhanHoi WHERE id = @id";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void SuaCauHinh(CauHinh ch)
    {
        string sql = @"UPDATE tblCauHinh  set   tieuDe=@tieuDe,
                                                moTa=@moTa,
                                                tuKhoa=@tuKhoa, 
                                                logo=@logo where 1 = 1";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@tieuDe", SqlDbType.NText);
        cmd.Parameters["@tieuDe"].Value = ch.tieuDe;

        cmd.Parameters.AddWithValue("@logo", ch.logo);

        cmd.Parameters.Add("@moTa", SqlDbType.NText);
        cmd.Parameters["@moTa"].Value = ch.moTa;

        cmd.Parameters.Add("@tuKhoa", SqlDbType.NText);
        cmd.Parameters["@tuKhoa"].Value = ch.tuKhoa;
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public CauHinh GetCauHinh()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * From tblCauHinh";
        cmd.Connection = con;
        SqlDataReader rd = cmd.ExecuteReader();
        CauHinh ch = new CauHinh();
        if (rd.Read())
        {
            ch.tieuDe = Convert.ToString(rd["tieuDe"]);
            ch.moTa = Convert.ToString(rd["moTa"]);
            ch.tuKhoa = Convert.ToString(rd["tuKhoa"]);
            ch.logo = Convert.ToString(rd["logo"]);
        }
        con.Close();
        return ch;
    }
    //tong quan
    public int SoLienHe()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(*) AS Max From tblPhanHoi";
        cmd.Connection = con;
        SqlDataReader rd = cmd.ExecuteReader();
        int lh=0;
        if (rd.Read())
        {
            lh = Convert.ToInt32(rd["Max"]);
        }
        con.Close();
        return lh;
    }

    public int SoBinhLuan()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(*) AS Max From tblBinhLuan";
        cmd.Connection = con;
        SqlDataReader rd = cmd.ExecuteReader();
        int lh = 0;
        if (rd.Read())
        {
            lh = Convert.ToInt32(rd["Max"]);
        }
        con.Close();
        return lh;
    }
    public int SoThanhVien()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(*) AS Max From tblThanhVien";
        cmd.Connection = con;
        SqlDataReader rd = cmd.ExecuteReader();
        int lh = 0;
        if (rd.Read())
        {
            lh = Convert.ToInt32(rd["Max"]);
        }
        con.Close();
        return lh;
    }
    //menu chuyen muc
    public string loadmenu(int idCha, int level)
    {
        string result = "";
        SqlConnection conn = new SqlConnection("data source=MINHDINH;initial catalog=tintuc;user id=sa;password=123456");
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblChuyenMuc WHERE idCha = " + idCha, conn);
        conn.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (level == 0) result = "<ul class='nav-menu'>";
        else result = "<ul class='sub-menu'>";
        while (rd.Read())
        {
            result += "<li><a href=Category.aspx?id=" + rd["id"] + ">" + rd["tenCM"] + "</a>";
            result += loadmenu(Convert.ToInt32(rd["id"]), level + 1);
        }
        result += "</li></ul>";
        conn.Close();
        return result;
    }


	public DataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}