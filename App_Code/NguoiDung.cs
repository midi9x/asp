using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NguoiDung
/// </summary>
public class NguoiDung
{
    public int id { get; set; }
    public string tenDN { get; set; }
    public string matKhau { get; set; }
    public string hoTen { get; set; }
    public string email { get; set; }
    public DateTime ngayTao { get; set; }
    public int quyen { get; set; }
    public int trangThai { get; set; }
    public NguoiDung(int id, string tenDN, string matKhau, string hoTen, string email, DateTime ngayTao, int quyen, int trangThai)
    {
        this.id = id;
        this.tenDN = tenDN;
        this.matKhau = matKhau;
        this.hoTen = hoTen;
        this.email = email;
        this.ngayTao = ngayTao;
        this.quyen = quyen;
        this.trangThai = trangThai;
    }
    public NguoiDung()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}