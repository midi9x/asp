<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="i-category fl">
    <h2><asp:Label runat="server" ID="lblTencm" /></h2>
    <div id="content" class="icat clearfix">
        <asp:datalist id="dataCM" runat="server" >
             <ItemTemplate>
                <div class="icat-content"> 
                    <a class="pull-left" title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                        <img src="<%# Eval("hinhAnh")%>"" width="208" height="153" alt="<%# Eval("tieuDe")%>" class="media-object"/>
                    </a>
                    <div class="icat-body">
                        <h4 class="media-heading">
                            <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>" class="cat"><%# Eval("tieuDe")%>
                            </a>
                        </h4>
                        <span class="icat-info">
                            <a class="user" href="Category.aspx?id=<%# Eval("id_cm")%>"><%# Eval("tenCM")%></a> | Đăng lúc: <%# Eval("ngayTao")%> | <i style="color:#b5b5b5"><%# Eval("luotXem")%>  Lượt xem</i></span>
                        <p>
                            <%# Eval("moTa")%>
                        </p>
                    </div>
                    <div class="clear"></div>
                </div>
            </ItemTemplate>
       </asp:datalist>
        <asp:Label ID="lblPage" runat="server" /><br />
        <asp:Label ID="lblmsg" runat="server" />

    </div>
</div>
</asp:Content>

