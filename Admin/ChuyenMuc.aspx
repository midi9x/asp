<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChuyenMuc.aspx.cs" Inherits="Admin_ChuyenMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
        $(document).ready(function () {
            $('#selectall').click(function (event) { //on click
                if (this.checked) { //Kiểm tra trạng thái đã chọn checkbox có id là selectall hay chưa
                    $('.checkbox').each(function () { //lặp qua từng checkbox
                        this.checked = true; //chọn tất cả checkbox có class là: "checkbox"
                    });
                }
                else {
                    $('.checkbox').each(function () { //lặp qua từng checkbox
                        this.checked = false; //deselect all checkboxes with class "checkbox"
                    });
                }
            });
        });
</script>
<div class="row">
    <div class="col-lg-12">
        <div class="page-header">
            <h3>
                <ul class="breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>  <a href="/Admin">Home</a>
                    </li>
                    <li class="active">
                        <i class="fa fa-table"></i> Quản lý chuyên mục
                    </li>
                </ul>
            </h3>
        </div>    
    </div>
</div>


<div class="row">
    <div class="col-lg-4">
        <h2> <span class="action">Thêm</span> Chuyên mục</h2>
            <input type="hidden" name="id" id="id" />
            <div class="form-group">
                <label for="tenChuyenMuc" class="col-sm-3 control-label">Tiêu đề</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="tenChuyenMuc" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="moTa" class="col-sm-3 control-label">Mô tả</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="moTa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="tuKhoa" class="col-sm-3 control-label">Từ khóa</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="tuKhoa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="loaiCha" class="col-sm-3 control-label">Loại cha</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddCha" runat="server"  CssClass="form-control"></asp:DropDownList>

                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnThem" CssClass="btn btn-success" runat="server" Text="Button" />
                    <%--<button name="btnThem" id="btnCapnhat" type="submit" class="btn btn-success"><i class="glyphicon glyphicon-ok"></i> <span class="action">Thêm </span></button>--%>
                    <button type="reset" class="btn btn-warning"><i class="glyphicon glyphicon-repeat"></i> Làm mới</button>
                </div>
            </div>

    </div>
    <div class="col-lg-8">
<div class="form-group">
    <div class="col-sm-7"><h2>Danh sách loại sản phẩm</h2>
    </div>
    <div class="col-sm-5">
    <div style="padding-top: 20px;"></div>
<button class="btn btn-success" type="button" id="Add"><i class="glyphicon glyphicon-plus"></i> Thêm mới </button> 
                    <script>
                        $(document).ready(function (e) {
                            $('#Add').click(function (e) {
                                $('span.action').text('Thêm ');
                                $('#id').val(0);
                                $('#tenLoai').val('');
                                $('#moTa').val('');
                                $('#tuKhoa').val('');
                                $('#loaiCha').val(0);
                                $('#btnCapnhat').attr('name', 'btnThem');
                            });
                        });
                    </script>
                    <button name="btnXoachon" onclick="return confirm('Bạn có muốn xóa');" type="submit" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i> Xóa mục chọn</button>
    </div>
</div>

        <div class="table-responsive">
            <table class="table table-bordered table-hover table-striped">
                <thead>
                    <tr>
                        <th>Tên loại</th>
                        <th>Mô tả</th>
                        <th>Chuyên mục cha</th>
                        <th><input type="checkbox" id="selectall" name="selectall" /></th>
                         <th width="170">Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        
                        <td></td>
                        <td></td>
                        <td>
                        </td>
                       
                        <td><input type="checkbox" name="cbitem[]" value="{$item.id}" class="checkbox"/></td>
                        <td width="170">
                            <button type="button" id="btnedit{$item.id}" class="btn btn-warning"><i class="glyphicon glyphicon-pencil"></i> Sửa </button>
                             <a href="{$link}&action=xoa&id={$item.id}" onclick="return confirm('Bạn có muốn xóa');" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i> Xóa</a>
                            
                        </td>
                    </tr>
                   <%-- <script>
                        $(document).ready(function (e) {
                            $('#btnedit{$item.id}').click(function (e) {
                                $('span.action').text('Cập nhật');
                                $('#id').val('{$item.id}');
                                $('#tenLoai').val('{$item.tenLoai}');
                                $('#moTa').val('{$item.moTa}');
                                $('#tuKhoa').val('{$item.tuKhoa}');
                                $('#loaiCha').val('{$item.loaiCha}');
                                $('#btnCapnhat').attr('name', 'btnSua');
                            });
                        });
                    </script>--%>
                </tbody>
            </table>
          
        </div>
    </div>
</div>
<!-- /.row -->
</asp:Content>

