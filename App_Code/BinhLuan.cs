using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BinhLuan
/// </summary>
public class BinhLuan
{
    public int id { get; set; }
    public int id_TV { get; set; }
    public int id_BV { get; set; }
    public string noiDung { get; set; }
    public DateTime ngayGui { get; set; }
    public int trangThai { get; set; }
	public BinhLuan(int id, int id_TV, int id_BV, string noiDung,DateTime ngayGui , int trangThai)
	{
        this.id = id;
        this.id_TV = id_TV;
        this.id_BV = id_BV;
        this.noiDung = noiDung;
        this.ngayGui = ngayGui;
        this.trangThai = trangThai;
	}
    public BinhLuan()
    {
    }
}