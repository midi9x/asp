using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChuyenMuc
/// </summary>
public class ChuyenMuc
{

    public int id { get; set; }
    public string tenCM { get; set; }
    public string moTa { get; set; }
    public string tuKhoa { get; set; }
    public int idCha { get; set; }
    public ChuyenMuc(int id, string tenCM, string moTa, string tuKhoa, int idCha)
    {
        this.id = id;
        this.tenCM = tenCM;
        this.moTa = moTa;
        this.tuKhoa = tuKhoa;
        this.id = idCha;
    }
    public ChuyenMuc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}