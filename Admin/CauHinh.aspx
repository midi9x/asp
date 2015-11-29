<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CauHinh.aspx.cs" Inherits="Admin_CauHinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
    <div class="col-lg-12">
        <h3>
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-home"></i>  <a href="/Admin">Home</a>
                </li>
                <li class="active">
                    <i class="fa fa-cog"></i> Cấu hình hệ thống
                </li>
            </ol>
        </h3>
    </div>
</div>
<!-- /.row -->
  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Tiêu đề trang web</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtTieude" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Mô tả</label>
    <div class="col-sm-10">
        <asp:TextBox TextMode="MultiLine" ID="btnMota" Rows="4" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Từ khóa</label>
    <div class="col-sm-10">
      <asp:TextBox TextMode="MultiLine" ID="btnTukhoa" Rows="4" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Logo</label>
    <div class="col-sm-10">
        <asp:FileUpload ID="imgAnh" CssClass="form-control"  runat="server" />
      <p class="form-control-static">
          <img width="160"  class="img-thumbnail" alt="logo" src="http://vieclam.24h.com.vn/upload/files_cua_nguoi_dung/logo/2014/02/24/1393231114_card_2.jpg"/>
      </p>
    </div>
  </div>


  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      <button t type="submit" class="btn btn-success"><i class="glyphicon glyphicon-ok"></i> Hoàn thành</button>
      <button type="reset" class="btn btn-warning"><i class="glyphicon glyphicon-repeat"></i> Làm mới</button>
    </div>
  </div>
</asp:Content>

