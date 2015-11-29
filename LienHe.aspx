<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Liên hệ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="i-category fl">
   <script>
       $(function () {
           $("#txtNoiDung_btnCapnhat").click(function () {
               var vl = $("#txtNoiDung_txtNgaySinh").val();
               if (vl == null) {
                   alert('Vui lòng nhập nội dung');
                   return false;
               }
           });
       });
    </script>
    <h2>Trang chủ / Liên hệ</h2>
    <div id="content" class="icat clearfix taikhoan" >
        <%if(Session["thanhvien"]==null){ %>
        Vui lòng <a  style=" color: blue;" href="Login.aspx">đăng nhập </a> 
        <%} %>
        <%else { %>
        <table>
            <tr>
                <td>Nhập nội dung: </td>
            </tr>
            <tr>
                <td>
                        <asp:TextBox Width="580" ID="txtNoiDung" TextMode="MultiLine" Rows="6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button CssClass="buttonok" ID="btnCapnhat" runat="server" Text="Gửi" OnClick="btnCapnhat_Click"/>
                    <input class="buttonreset" type="reset" value="Làm lại" />
                </td>
            </tr>

        </table>    
        <%} %>
    </div>
</div>
</asp:Content>

