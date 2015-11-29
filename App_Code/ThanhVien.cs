using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThanhVien
/// </summary>
public class ThanhVien
{
    public int id { get; set; }
    public string tenDN { get; set; }
    public string matKhau { get; set; }
    public string hoTen { get; set; }
    public string email { get; set; }
    public DateTime ngaySinh { get; set; }
    public int gioiTinh { get; set; }
    public string diaChi { get; set; }
    public DateTime ngayTao { get; set; }
    public string anhDaiDien { get; set; }
    public int trangThai { get; set; }
    public ThanhVien(int id, string tenDN, string matKhau, string hoTen, string email, DateTime ngayTao, DateTime ngaySinh, int gioiTinh, string diaChi, string anhDaiDien, int trangThai)
    {
        this.id = id;
        this.tenDN = tenDN;
        this.matKhau = matKhau;
        this.hoTen = hoTen;
        this.email = email;
        this.ngaySinh = ngaySinh;
        this.gioiTinh = gioiTinh;
        this.diaChi = diaChi;
        this.ngayTao = ngayTao;
        this.anhDaiDien = anhDaiDien;
        this.trangThai = trangThai;
    }
    
    public ThanhVien()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}