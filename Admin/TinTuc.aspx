<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="TinTuc.aspx.cs" Inherits="Admin_TinTuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Quản lý tin tức</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script>
$(document).ready(function (e) {
    $("#ContentPlaceHolder1_btnSearch").click(function (e) {
        var value = $("#ContentPlaceHolder1_txtKey").val();
        if (value == "") {
            alert('Vui lòng nhập từ khóa');
            return false;
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
                        <i class="fa fa-list"></i> Danh sách tin tức
                    </li>
                </ul>
            </h3>
        </div>
    </div>
</div>
    <p style="text-align:center;color:red"><asp:Label ID="lblmsg" runat="server"  /></p>
<!-- /.row -->
<div class="row">
    <div class="col-lg-6">
            <div class="input-group">
                <span class="input-group-addon " id="basic-addon1">Tìm kiếm tin tức</span>
                <asp:TextBox CssClass="form-control" ID="txtKey" runat="server" aria-describedby="basic-addon1" placeholder="Nhập từ khóa cần tìm ..."></asp:TextBox>
                <span class="input-group-btn">
                    <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary" runat="server" OnClick="btnSearch_Click"><i class="glyphicon glyphicon-search"></i> Tìm </asp:LinkButton>
                </span>
            </div>
        
    </div>
     <div class="col-lg-1">
            <div class="input-group">
                <a href="" class="btn btn-info" type="button"><i class="glyphicon glyphicon-off"></i>  Tất cả </a>
            </div>
        
    </div>
    <div class="col-lg-offset-1 col-lg-4">
            <a href="ThemTin.aspx" class="btn btn-success"><i class="glyphicon glyphicon-plus"></i> Thêm mới </a> 
            <asp:LinkButton ID="btnXoaN" OnClientClick="return confirm('Bạn có muốn xóa không?');" CssClass="btn btn-danger" runat="server" OnClick="btnXoaN_Click"><i class="glyphicon glyphicon-remove"></i> Xóa mục chọn </asp:LinkButton>
           
    </div>
</div>
<script type="text/javascript">
    function CheckAllEmp(Checkbox) {
        var grvBaiviet = document.getElementById("<%=grvBaiviet.ClientID %>");
        for (i = 1; i < grvBaiviet.rows.length; i++) {
            grvBaiviet.rows[i].cells[8].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
</script>
<br/>
<div class="row">
    <div class="col-lg-12">
        <div class="table-responsive">
            <asp:GridView   AllowSorting="True" OnSorting="grvBaiviet_Sorting" DataKeyNames="id" ID="grvBaiviet" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grvBaiviet_PageIndexChanging" PageSize="7">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="#" SortExpression="id" />
                    <asp:BoundField DataField="tieuDe" HeaderText="Tiêu đề" />
                    <asp:BoundField DataField="tenCM" HeaderText="Chuyên mục" />
                    <asp:TemplateField HeaderText="Ảnh đại diện">
                        <ItemTemplate>
                            <asp:Image ImageUrl='<%#Eval("hinhAnh") %>' Width="50" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="moTa" HeaderText="Mô tả" />
                    <asp:BoundField DataField="ngayTao" HeaderText="Ngày đăng" />
                    <asp:BoundField DataField="luotXem" HeaderText="Lượt xem" SortExpression="luotXem"  />
                    <asp:TemplateField HeaderText="Trạng thái" ItemStyle-Width="100">
                        <ItemTemplate>
                        <asp:Label Text='<%# Eval("trangThai").ToString() == "1" ? "Hiển thị" : "Không hiển thị" %>'
                        runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" onClick="CheckAllEmp(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEmp" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:HyperLinkField  ControlStyle-CssClass="btn btn-warning"
                        DataNavigateUrlFields="id" 
                        DataNavigateUrlFormatString="SuaTin.aspx?id={0}"
                        Text="<i class='glyphicon glyphicon-pencil'></i> Sửa" 
                        HeaderText="Sửa"
                        >

                    </asp:HyperLinkField>

                    <asp:TemplateField HeaderText="Xóa">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-danger"
                                OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');"
                                ID="btnXoa" 
                                runat="server"  
                                CommandName="Xóa"
                                OnCommand="Xoa"
                                CommandArgument='<%# Eval("id") %>' 
                            ><i class="glyphicon glyphicon-remove"></i> Xóa
                            </asp:LinkButton>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    
                </Columns>
               
                <PagerStyle CssClass="pagination-ys" />

            </asp:GridView>
            
        </div>
    </div>
</div>  
</asp:Content>

