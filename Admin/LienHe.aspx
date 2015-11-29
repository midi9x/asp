<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Quản lý liên hệ</title>
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
                        <i class="fa fa-list"></i> Quản lý liên hệ
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
        var grLienHe = document.getElementById("<%=grLienHe.ClientID %>");
        for (i = 1; i < grLienHe.rows.length; i++) {
            grLienHe.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
</script>
<div class="row">
    <div class="col-lg-12">
        <div class="table-responsive">
            <asp:GridView DataKeyNames="id" ID="grLienHe" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="True" PageSize="7" OnPageIndexChanging="grLienHe_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="#" />
                    <asp:BoundField DataField="tenDN" HeaderText="Thành viên" />
                   <asp:BoundField DataField="noiDung" HeaderText="Nội dung" />
                    <asp:BoundField DataField="ngayGui" HeaderText="Ngày gửi" />
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

