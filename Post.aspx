<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <%
                DataAccess data = new DataAccess();
                BaiViet bv = new BaiViet();
                //get bài viết theo id
                int id = Convert.ToInt32(Request.QueryString["id"]);
                bv = data.GetABaiViet(id);
                //đổ dữ liệu lên view
                int idcm = bv.id_cm;
                int tdnd = bv.id_nd;
                string[] tukhoa =  bv.tuKhoa.Split(',');
     %>
    <div class="i-category fl">
    <h2><a href="/">Trang chủ</a> / <a href="Category.aspx?id=<%=idcm %>"><asp:Label runat="server" ID="lblChuyenmuc"></asp:Label></a></h2>
    <div class="icat-detail">
        <h1 class="media-heading"><asp:Label runat="server" ID="lblTieude"></asp:Label></h1>
        <span class="i-info clearfix">
            <span class="social">
                <a rel="nofollow" href="https://www.facebook.com/sharer/sharer.php?u=<%=HttpContext.Current.Request.Url.AbsoluteUri %>" target="_blank" class="fb">facebook</a>
                <a rel="nofollow" href="https://twitter.com/share?url==<%=HttpContext.Current.Request.Url.AbsoluteUri %>" target="_blank" class="tw">twitter</a>
                <a rel="nofollow" href="https://plus.google.com/share?url==<%=HttpContext.Current.Request.Url.AbsoluteUri %>" target="_blank" class="gg">google+</a>
                <a rel="nofollow" href="http://pinterest.com/pin/create/button/?url==<%=HttpContext.Current.Request.Url.AbsoluteUri %>" target="_blank" class="pt">Pin It</a>
                <a rel="nofollow" href="https://www.linkedin.com/cws/share?=<%=HttpContext.Current.Request.Url.AbsoluteUri %>" target="_blank" class="ln">LinkedIn</a>
            </span>
            Đăng bởi: <a class="user" href="Author.aspx?id=<%=tdnd %>"><asp:Label runat="server" ID="lbltenND"></asp:Label> </a> | 
            <asp:Label runat="server" ID="lblNgaydang"></asp:Label> | 
            <a class="user" href="Category.aspx?id=<%=idcm %>"><asp:Label runat="server" ID="lblCM"></asp:Label></a> |  
            <i style="color:#b5b5b5"> <asp:Label runat="server" ID="lblXem"></asp:Label> Lượt xem</i>

        </span>
        <div class="content_post">
            <div class="pos-content">
               <asp:Label runat="server" ID="lblNoidung"></asp:Label>            
            </div>

        </div>
        <div class="tags">Từ khóa: 
            <% for(int i=0;i<tukhoa.Length -1;i++)
            {%>
            <a><%=tukhoa[i] %></a>

            <%} %>
        </div>

        <div class="comment cmfb">
            <a name="name="binhluan"></a>
            <p>Bình luận</p>
            <%
            if(Session["thanhvien"]==null)
            {
            %>
            Vui lòng <a style='color:blue;font-weight:bold' href='Login.aspx'>Đăng nhập</a> để gửi bình luận
            <%}
            else
            {%>
            <asp:TextBox ID="txtNoidung" runat="server" TextMode="multiline" width="580" Rows="5"  ></asp:TextBox>
            <asp:Button ID="btnGui" CssClass="btnGui" runat="server" Text="Gửi" OnClick="btnGui_Click" />
            <%} %>
            <div style="margin-top:35px;"></div>
             <ul>
                 <asp:DataList ID="dataBinhLuan" runat="server">
                     <ItemTemplate>
                        <li>
                            
                            <img src="<%#Eval("anhDaiDien") %>" class="avatar" />
                            <div class="cm-content">
                                <div class="tenND"><%#Eval("tenDN") %></div>
                                <div style="font-size: 11px;"><%#Eval("ngayGui") %></div>
                                <div class="noiDung"><%#Eval("noiDung") %> </div>
                            </div>
                        </li>
                    </ItemTemplate>
                 </asp:DataList>
                 <%if (dataBinhLuan.Items.Count == 0) { 
                   %>
                 Chưa có bình luận nào
                 <%}  %>
            </ul>
        </div>
    </div>
   
</div>
</asp:Content>
