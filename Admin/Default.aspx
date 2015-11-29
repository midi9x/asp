<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Page Heading -->
<div class="row">
    <div class="col-lg-12">
        <h3>
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-home"></i>  <a href="">Home</a>
                </li>
                <li class="active">
                    <i class="fa fa-dashboard"></i> Tổng quan
                </li>
            </ol>
        </h3>
    </div>
</div>
<!-- /.row -->

<div class="row">
    <div class="col-lg-12">
        <div class="alert alert-info alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <i class="fa fa-info-circle"></i>   
            Chào mừng bạn đến với trang quản trị. Trước tiên hãy <strong><u><a href="">thiết lập cấu hình</u></a></strong> cho website.
            
        </div>
    </div>
</div>
<!-- /.row -->

<div class="row">
    <div class="col-lg-4 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-reply fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge">
                            <asp:Label ID="lblLienHe" runat="server" Text=""></asp:Label>
                        </div>
                        <div>Liên hệ mới!</div>
                    </div>
                </div>
            </div>
            <a href="LienHe.aspx" title="lien he">
                <div class="panel-footer">
                    <span class="pull-left">Xem chi tiết</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-4 col-md-6">
        <div class="panel panel-yellow">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-comments fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"><asp:Label ID="lblBinhluan" runat="server" Text=""></asp:Label></div>
                        <div>Bình luận mới!</div>
                    </div>
                </div>
            </div>
            <a title="binh luan" href="BinhLuan.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Xem chi tiết</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-4 col-md-6">
        <div class="panel panel-red">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-user fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"><asp:Label ID="lblThanhvien" runat="server" Text=""></asp:Label></div>
                        <div>Thành viên mới</div>
                    </div>
                </div>
            </div>
            <a title="Thanh Vien" href="ThanhVien.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Xem chi tiết</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
</div>
<!-- /.row -->

<div class="row">
    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><i class="fa fa-file fa-fw"></i> Bài viết gần đây</h3>
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                    <asp:GridView AutoGenerateColumns="false" ID="dtBaiviet" CssClass="table table-bordered table-hover table-striped" runat="server">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="#" />
                            <asp:BoundField DataField="tieuDe" HeaderText="Tiêu đề" />
                            <asp:BoundField DataField="ngayTao" HeaderText="Ngày tạo" />
                            <asp:BoundField DataField="luotXem" HeaderText="Lượt xem" />
                        </Columns>
                    </asp:GridView>
                        
                         
                </div>
                <div class="text-right">
                    <a title="Tin tức" href="TinTuc.aspx">Xem tất cả bài viết <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><i class="fa fa-comment fa-fw"></i> Bình luận gần đây</h3>
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                    <asp:GridView AutoGenerateColumns="false" ID="dtBinhLuan" CssClass="table table-bordered table-hover table-striped" runat="server">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="#" />
                            <asp:BoundField DataField="hoTen" HeaderText="Thành viên" />
                            <asp:BoundField DataField="tieuDe" HeaderText="Bài viết" />
                            <asp:BoundField DataField="noiDung" HeaderText="Nội dung" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="text-right">
                    <a title="Tin tức" href="BinhLuan.aspx">Xem tất bình luận<i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- /.row -->

</asp:Content>

