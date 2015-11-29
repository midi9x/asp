<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="TaiKhoan.aspx.cs" Inherits="TaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Tài khoản thành viên</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="i-category fl">
   <script>
   $(function() {
       $("#ContentPlaceHolder2_txtNgaySinh").datepicker({ 'dateFormat': 'yy-mm-dd' });
   });
    </script>
    <h2>Trang chủ / Tài khoản thành viên</h2>
    <div id="content" class="icat clearfix taikhoan" >
        <%if(Session["thanhvien"]==null){ %>
       
        Vui lòng <a  style=" color: blue;" href="Login.aspx">đăng nhập </a> 
        <%} %>
        <%else { %>
        <table>
            <tr>
                <td>Tên đăng nhập: </td>
                <td>
                    <asp:Label ID="lblTenDN" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Họ tên:  </td>
                <td>
                    <asp:TextBox ID="txtHoten" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email: </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày sinh</td>
                <td>
                    <asp:TextBox  ID="txtNgaySinh" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Giới tính</td>
                <td>
                    <asp:DropDownList ID="ddGioitinh" runat="server">
                        <asp:ListItem Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Địa chỉ</td>
                <td>
                    
                    <asp:TextBox ID="txtDiachi" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ảnh đại diện</td>
                <td>
                    <asp:FileUpload ID="txtAnh" runat="server"></asp:FileUpload><br />
                    <asp:Image Width="60px" Height="60px" CssClass="img" ID="imgAnh" runat="server" />

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button CssClass="buttonok" ID="btnCapnhat" runat="server" Text="Câp nhật" OnClick="btnCapnhat_Click"/>
                    <input class="buttonreset" type="reset" value="Làm lại" />
                </td>
            </tr>

            <tr>
                <td>Mật khẩu cũ</td>
                <td>
                    <asp:TextBox ID="txtmkcu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Mật khẩu mới</td>
                <td>
                    <asp:TextBox ID="txtmkmoi" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nhập lại mật khẩu</td>
                <td>
                    <asp:TextBox ID="txtremkmoi" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
               <td>     <asp:Button CssClass="buttonok" ID="btnMK" runat="server" Text="Đổi mật khẩu" OnClick="btnMK_Click" /></td>
               
            </tr>
        </table>    
        <%} %>
    </div>
</div>
</asp:Content>

