using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CauHinh
/// </summary>
public class CauHinh
{
    public string tieuDe { get; set; }
    public string moTa { get; set; }
    public string tuKhoa { get; set; }
    public string logo { get; set; }
    public CauHinh(string tieuDe, string moTa, string tuKhoa, string logo)
    {
        this.tieuDe = tieuDe;
        this.moTa = moTa;
        this.tuKhoa = tuKhoa;
        this.logo = logo;
    }
	public CauHinh()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}