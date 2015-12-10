using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhanHoi
/// </summary>
public class PhanHoi
{
    public int id { get; set; }
    public int id_TV { get; set; }
    public string tieuDe { get; set; }
    public string noiDung { get; set; }
    public DateTime ngayGui { get; set; }
    public PhanHoi(int id, int id_TV,string tieuDe , string noiDung, DateTime ngayGui)
    {
        this.id = id;
        this.id_TV = id_TV;
        this.noiDung = noiDung;
        this.ngayGui = ngayGui;
    }
    public PhanHoi()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}