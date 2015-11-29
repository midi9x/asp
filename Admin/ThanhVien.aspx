<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ThanhVien.aspx.cs" Inherits="Admin_ThanhVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Quản lý thành viên</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
    <div class="col-lg-10">
        <div class="page-header">
            <h3>
                <ul class="breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>  <a href="/Admin">Home</a>
                    </li>
                    <li class="active">
                        <i class="fa fa-list"></i> Quản lý thành viên
                    </li>
                </ul>
            </h3>
        </div>
    </div>
    <div class="col-lg-2 ">
            <div class="page-header" style="    padding-top: 6px;">
                <asp:LinkButton ID="btnXoaN" OnClientClick="return confirm('Bạn có muốn xóa không?');" CssClass="btn btn-danger" runat="server" OnClick="btnXoaN_Click"><i class="glyphicon glyphicon-remove"></i> Xóa mục chọn </asp:LinkButton>
           </div>
    </div>
</div>

<script type="text/javascript">
    function CheckAllEmp(Checkbox) {
        var grThanhVien = document.getElementById("<%=grThanhVien.ClientID %>");
        for (i = 1; i < grThanhVien.rows.length; i++) {
            grThanhVien.rows[i].cells[9].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
</script>
<div class="row">
    <div class="col-lg-12">
        <div class="table-responsive">
            <asp:GridView DataKeyNames="id" ID="grThanhVien" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="True" PageSize="7" OnPageIndexChanging="grThanhVien_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="#" />
                    <asp:TemplateField HeaderText="Ảnh đại diện">
                        <ItemTemplate>
                            <asp:Image ImageUrl='<%# Eval("anhDaiDien") %>' Width="30px" HeaderText="Anh" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tenDN" HeaderText="Tên đăng nhập" />
                    <asp:BoundField DataField="hoTen" HeaderText="Họ tên" />
                    <asp:BoundField DataField="email" HeaderText="email" />
                    <asp:TemplateField HeaderText="Giới tính" ItemStyle-Width="100">
                        <ItemTemplate>
                        <asp:Label Text='<%# Eval("ngaySinh").ToString() == "1" ? "Nam" : "Nữ" %>'
                        runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:BoundField DataField="diaChi" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="ngayTao" HeaderText="Ngày tạo" />
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                        <asp:Label Text='<%# Eval("trangThai").ToString() == "1" ? "Hoạt động" : "Khóa" %>'
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

                    <asp:TemplateField HeaderText="Xóa">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-warning"
                                OnClientClick="return confirm('Bạn có muốn xóa');"
                                ID="btnXoa" 
                                runat="server"  
                                CommandName="Xóa"
                                OnCommand="btnXoa"
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