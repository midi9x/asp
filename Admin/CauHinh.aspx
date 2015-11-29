<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CauHinh.aspx.cs" Inherits="Admin_CauHinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Quản lý cấu hình</title>
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
        <asp:TextBox TextMode="MultiLine" ID="txtMota" Rows="4" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Từ khóa</label>
    <div class="col-sm-10">
      <asp:TextBox TextMode="MultiLine" ID="txtTuKhoa" Rows="4" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

  <div class="form-group">
    <label for="" class="col-sm-2 control-label">Logo</label>
    <div class="col-sm-10">
        <asp:FileUpload ID="imgAnh" CssClass="form-control"  runat="server" />
      <p class="form-control-static">
          <asp:ImageButton ID="logo" runat="server" />

      </p>
    </div>
  </div>


  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
        <asp:LinkButton ID="btnCapNhat" CssClass="btn btn-success" runat="server" OnClick="btnCapNhat_Click"><i class="glyphicon glyphicon-ok"></i> Câp nhật</asp:LinkButton>
      <button type="reset" class="btn btn-warning"><i class="glyphicon glyphicon-repeat"></i> Làm mới</button>
    </div>
  </div>
</asp:Content>

