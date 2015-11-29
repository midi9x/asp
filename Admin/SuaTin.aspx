<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SuaTin.aspx.cs" Inherits="Admin_SuaTin" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Sửa tin tức</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row">
    <div class="col-lg-12">
        <h3>
            <ul class="breadcrumb">
                <li>
                    <i class="fa fa-home"></i>  <a href="/Admin">Home</a>
                </li>
                <li class="active">
                    <i class="fa fa-plus"></i> Sửa tin tức
                </li>
            </ul>
        </h3>
    </div>
</div>
<!-- /.row -->
    
  <div class="form-group">
    <label for="txtTieuDe" class="col-sm-2 control-label">Tiêu đề <span class="required">*</span></label>
    <div class="col-sm-10">
       <asp:TextBox runat="server" ID="txtTieuDe" CssClass="form-control" placeholder=""></asp:TextBox>
       <asp:RequiredFieldValidator CssClass="red" ID="rqTieude" runat="server" ControlToValidate="txtTieuDe" ErrorMessage="Vui lòng nhập tiêu đề"></asp:RequiredFieldValidator>

    </div>
  </div>

  <div class="form-group">
    <label for="ddchuyenmuc" class="col-sm-2 control-label">Chuyên mục <span class="required">*</span></label>
    <div class="col-sm-10">
        <asp:DropDownList CssClass="form-control"  ID="ddChuyenMuc" runat="server"></asp:DropDownList>
    </div>
  </div>

  <div class="form-group">
    <label for="hinhAnh" class="col-sm-2 control-label">Ảnh đại diện<span class="required">*</span></label>
    <div class="col-sm-10">
        <asp:FileUpload ID="hinhAnh" CssClass="form-control" runat="server" />
        <asp:Image ID="oldHinhAnh" runat="server" Width="69px" />
    </div>
  </div>

  <div class="form-group">
    <label for="txtNoiDung" class="col-sm-2 control-label">Nội dung <span class="required">*</span></label>
    <div class="col-sm-10">
        <CKEditor:CKEditorControl ID="txtNoiDung" CssClass="form-control" runat="server" BasePath="Admin/ckeditor"></CKEditor:CKEditorControl>
        <asp:RequiredFieldValidator CssClass="red" ID="rqNoidung" runat="server" ControlToValidate="txtNoiDung" ErrorMessage="Vui lòng nhập nội dung"></asp:RequiredFieldValidator>

    </div>
  </div>

  <div class="form-group">
    <label for="txtMota" class="col-sm-2 control-label">Mô tả <span class="required">*</span></label>
    <div class="col-sm-10">
      <asp:TextBox runat="server" ID="txtMota" CssClass="form-control" placeholder=""></asp:TextBox>
      <asp:RequiredFieldValidator CssClass="red" ID="raMota" ControlToValidate="txtMota" runat="server" ErrorMessage="Vui lòng nhập mô tả"></asp:RequiredFieldValidator>
    </div>
  </div>
 
  <div class="form-group">
    <label for="txtTuKhoa" class="col-sm-2 control-label">Từ khóa <span class="required">*</span></label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" ID="txtTuKhoa" CssClass="form-control" placeholder=""></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="red" ID="rqTukhoa" ControlToValidate="txtTuKhoa" runat="server" ErrorMessage="Vui lòng nhập từ khóa"></asp:RequiredFieldValidator>
    </div>
  </div>
  
  <div class="form-group">
    <label for="trangThai" class="col-sm-2 control-label">Trạng thái</label>
    <div class="col-sm-10">
        <asp:RadioButton ID="rd1" GroupName="rdtrangThai" Text="Hiển thị" runat="server" /> 
        <asp:RadioButton ID="rd0" GroupName="rdtrangThai" Text="Không hiển thị" runat="server" />

<%--        <asp:RadioButtonList ID="rdtrangThai" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="1" >Hiển thị</asp:ListItem>
            <asp:ListItem Value="0">Không hiển thị</asp:ListItem>
        </asp:RadioButtonList>--%>
    </div>
  </div>

  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
        
        <asp:LinkButton ID="btnThem" runat="server" CssClass="btn btn-success" OnClick="btnThem_Click"><i class="glyphicon glyphicon-plus"></i> Cập nhật</asp:LinkButton>
        <button type="reset" class="btn btn-warning"><i class="glyphicon glyphicon-refresh"></i> Làm lại</button>
    </div>
  </div>
</asp:Content>


