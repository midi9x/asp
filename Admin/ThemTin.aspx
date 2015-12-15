<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ThemTin.aspx.cs" Inherits="Admin_ThemTin" UnobtrusiveValidationMode="None" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Thêm tin mới</title>
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
                    <i class="fa fa-plus"></i> Thêm mới tin tức
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
    <label for="ddChuyenMuc" class="col-sm-2 control-label">Chuyên mục <span class="required">*</span></label>
    <div class="col-sm-10">
        <asp:DropDownList CssClass="form-control"  ID="ddChuyenMuc" runat="server"></asp:DropDownList>
    </div>
  </div>

  <div class="form-group">
    <label for="hinhAnh" class="col-sm-2 control-label">Ảnh đại diện<span class="required">*</span></label>
    <div class="col-sm-10">
        <asp:FileUpload ID="hinhAnh" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator CssClass="red" ID="rqhinhAnh" ControlToValidate="hinhAnh" runat="server" ErrorMessage="Vui lòng chọn ảnh"></asp:RequiredFieldValidator>
    
    </div>
  </div>
    <script type="text/javascript">
    $(function () {
        CKEDITOR.replace('<%=txtNoiDung.ClientID %>',
        { filebrowserImageUploadUrl: '/Upload.ashx' }); 
    });
    </script>


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
        <asp:RadioButtonList ID="rdtrangThai" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="1" Selected="True">Hiển thị</asp:ListItem>
             <asp:ListItem Value="0" >Không hiển thị</asp:ListItem>
        </asp:RadioButtonList>

    </div>
  </div>

  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
        <asp:Button ID="btnThem" runat="server" CssClass="btn btn-success"  Text="Thêm mới" OnClick="btnThem_Click" />
        <button type="reset" class="btn btn-warning"> Làm lại</button>
    </div>
  </div>
</asp:Content>

