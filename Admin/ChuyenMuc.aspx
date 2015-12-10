<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ChuyenMuc.aspx.cs" Inherits="Admin_ChuyenMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Quản lý chuyên mục</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
        function CheckAllEmp(Checkbox) {
            var grvBaiviet = document.getElementById("<%=grvChuyenMuc.ClientID %>");
        for (i = 1; i < grvBaiviet.rows.length; i++) {
            grvBaiviet.rows[i].cells[5].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
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

    <p style="text-align:center;color:red;"><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></p>
<div class="row">
    <div class="col-lg-4">
        <h2> <span class="action">
            <% int id= Convert.ToInt32(Request.QueryString["id"]);
               if (id > 0)
            {%>
                Cập nhật
            <%} else {%>
                Thêm
            <%} %>
             </span> Chuyên mục</h2>
        <div style="padding-top: 15px;"></div>
            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            <div class="form-group">
                <label for="tenCM" class="col-sm-3 control-label">Tiêu đề</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="tenCM" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="red" ID="rqTieude" runat="server" ControlToValidate="tenCM" ErrorMessage="Vui lòng nhập tiêu đề"></asp:RequiredFieldValidator>
  
                </div>
            </div>
            <div class="form-group">
                <label for="moTa" class="col-sm-3 control-label">Mô tả</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="moTa"  runat="server" TextMode="multiline" Rows="6" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="red" ID="rqMota" runat="server" ControlToValidate="moTa" ErrorMessage="Vui lòng nhập mô tả"></asp:RequiredFieldValidator>
  
                </div>
            </div>

            <div class="form-group">
                <label for="tuKhoa" class="col-sm-3 control-label">Từ khóa</label>
                <div class="col-sm-9"> 
                    <asp:TextBox ID="tuKhoa" runat="server" TextMode="multiline" Rows="6"  CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="red" ID="rqTukhoa" runat="server" ControlToValidate="tuKhoa" ErrorMessage="Vui lòng nhập từ khóa"></asp:RequiredFieldValidator>
  
                </div>
            </div>

            <div class="form-group">
                <label for="loaiCha" class="col-sm-3 control-label">Loại cha</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddCha" runat="server"  CssClass="form-control">
                    </asp:DropDownList>

                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnThem" CssClass="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnThem_Click" />
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
<button onclick="window.location.href='ChuyenMuc.aspx'" class="btn btn-success" type="button" id="Add"><i class="glyphicon glyphicon-plus"></i> Thêm mới </button> 
                    <script>
                        $(document).ready(function (e) {
                            $('#Add').click(function (e) {
                                $('span.action').text('Thêm ');
                                $(<%=tenCM.ClientID%>).val('');
                                $(<%=moTa.ClientID%>).val('');
                                $(<%=tuKhoa.ClientID%>).val('');
                                $(<%=ddCha.ClientID%>).val(0);
                            });
                        });
                    </script>
                     <asp:LinkButton ID="btnXoaN" OnClientClick="return confirm('Bạn có muốn xóa không?');" CssClass="btn btn-danger" runat="server" OnClick="btnXoaN_Click"><i class="glyphicon glyphicon-remove"></i> Xóa mục chọn </asp:LinkButton>
             </div>
</div>

        <div class="table-responsive">
            <asp:GridView ID="grvChuyenMuc" DataKeyNames="id" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="True" PageSize="7" runat="server" OnPageIndexChanging="grvChuyenMuc_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="#" />
                    <asp:BoundField DataField="tenCM" ItemStyle-Width="100" HeaderText="Tên chuyên mục" />
                    <asp:BoundField DataField="moTa" ItemStyle-Width="150" ItemStyle-CssClass="crop" HeaderText="Mô tả" />
                    <asp:BoundField DataField="tuKhoa" ItemStyle-Width="150" ItemStyle-CssClass="crop" HeaderText="Từ khóa" />
                    <asp:BoundField DataField="idCha" ItemStyle-Width="20" HeaderText="Chuyên mục cha" />
                    <asp:TemplateField >
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" onClick="CheckAllEmp(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEmp" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:HyperLinkField  ControlStyle-CssClass="btn btn-warning"
                        DataNavigateUrlFields="id" 
                        DataNavigateUrlFormatString="SuaTin.aspx?id={0}"
                        Text="<i class='glyphicon glyphicon-pencil'></i> Sửa" 
                        HeaderText="Sửa"
                        >
                    </asp:HyperLinkField>--%>

                    
                    <asp:HyperLinkField  ControlStyle-CssClass="btn btn-warning"
                        DataNavigateUrlFields="id" 
                        DataNavigateUrlFormatString="ChuyenMuc.aspx?id={0}&action=sua"
                        Text="<i class='glyphicon glyphicon-pencil'></i> Sửa" 
                        HeaderText="Sửa"
                        >

                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Xóa">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-danger"
                                OnClientClick="return confirm('Bạn có muốn xóa');"
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
<!-- /.row -->
</asp:Content>

