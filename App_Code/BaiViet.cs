using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaiViet
/// </summary>
public class BaiViet
{
    public int id { get; set; }
    public int id_cm { get; set; }
    public int id_nd { get; set; }
    public string tieuDe { get; set; }
    public string noiDung { get; set; }
    public string moTa { get; set; }
    public string tuKhoa { get; set; }
    public string hinhAnh { get; set; }
    public DateTime ngayTao { get; set; }
    public int luotXem { get; set; }
    public int phanLoai { get; set; }
    public int trangThai { get; set; }
    public string tenCM { get; set; }
    public string tenND { get; set; }
    public BaiViet(int id, int id_cm, int id_nd, string tieuDe, string noiDung, string moTa, string tuKhoa, string hinhAnh, DateTime ngayTao, int luotXem,int phanLoai , int trangThai, string tenCM, string tenND)
    {
        this.id = id;
        this.id_cm = id_cm;
        this.id_nd = id_nd;
        this.tieuDe = tieuDe;
        this.noiDung = noiDung;
        this.moTa = moTa;
        this.tuKhoa = tuKhoa;
        this.hinhAnh = hinhAnh;
        this.ngayTao = ngayTao;
        this.luotXem = luotXem;
        this.trangThai = trangThai;
        this.phanLoai = phanLoai;
        this.tenCM = tenCM;
        this.tenND = tenND;
    }
	public BaiViet()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}