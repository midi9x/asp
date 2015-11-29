<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <!-- content index -->
                <div class="iradio fl">
                    <div id="jslidernews2" class="lof-slidecontent" style="width:648px; height:396px;">
                        <div class="main-slider-content" style="width:380px; height:396px;">
                            <div style="width: 380px;" class="sliders-wrapper">
                                <ul class="sliders-wrap-inner">
                                    <asp:datalist id="Datalist1" runat="server" width="651px"  >
                                        <ItemTemplate>
                                            <li>
                                                <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                                    <img class="cover" alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="380" height="275" >
                                                </a>
                                                &nbsp;<div class="audio-player">
                                                    <h1>
                                                        <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                                            <%# Eval("tieuDe")%>
                                                        </a>
                                                    </h1>
                                                    <div style="width: 350px; height: 30px;padding-top:45px;padding-left:10px;font-size:14px;" id="mep_0" class="mejs-container mejs-audio">
                                                        <%# Eval("moTa")%>
                                                        
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:datalist>

                                </ul>
                            </div>  	
                        </div>
                        <div class="navigator-content">
                            <div style="height: 330px; width: 245px;" class="navigator-wrapper lc-radio">
                                <ul style="height: 330px; top: 0px;" class="navigator-wrap-inner">
                                    <asp:datalist id="Datalist2"  runat="server" width="651px" >
                                        <ItemTemplate>
                                            <li style="height: 55px; width: 245px;">
                                                <a title="<%# Eval("tieuDe")%>"  href="Post.aspx?id=<%# Eval("id")%>"><img src="<%# Eval("hinhAnh")%>" alt="<%# Eval("tieuDe")%>" style="width:59px;height:42px;">
                                                    <p id="title"><%# Eval("tieuDe")%></p>
                                                </a>
                                            &nbsp;</li>
                                        </ItemTemplate>
                                    </asp:datalist>
                                </ul>
                            </div>
                        </div> 
                        <div class="button-control action-stop"><span></span></div>
                    </div>
                </div>

                <div class="tracnghiem fl">
                    <h1><a href="Category.aspx?id=12">Tin tức công nghệ</a></h1>
                    <div class="list-r1">
                        <asp:datalist id="dataCongnghe1"  runat="server" width="300" >
                            <ItemTemplate>
                                <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                    <img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="300" height="124">
                                </a>
                                &nbsp;<a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>"><%# Eval("tieuDe")%></a>
                                
                            </ItemTemplate>
                       </asp:datalist>
                    </div>
                    <ul>
                        <asp:datalist id="dataCongnghe2"  runat="server" width="300" >
                            <ItemTemplate>
                                <li>
                                    <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                        <%# Eval("tieuDe")%>
                                    </a>
                                </li>
                            </ItemTemplate>
                       </asp:datalist>
                       
                    </ul>
                </div>
                <div class="clear"></div>
                
                <!-- List Radio -->
                <div class="list-radio-i">
                    <div class="l-radio fl">
                        <h1><ins><a href="Category.aspx?id=9">Xem thêm</a></ins>An ninh Xã hội</h1>
                        <div class="hot fl">    
                            <asp:datalist id="dataANXH1"  runat="server">
                                <ItemTemplate>
                                    <a href="Post.aspx?id=<%# Eval("id")%>" title="<%# Eval("tieuDe")%>>">
                                        <img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="203" height="128"/>
                                    </a>  
                                    <a href="Post.aspx?id=<%# Eval("id")%>" title="<%# Eval("tieuDe")%>" ><%# Eval("tieuDe")%></a>
                                    <p> 
                                        <%# Eval("moTa").ToString().Substring(0, 120) %>...
                                    </p>
                                </ItemTemplate>
                            </asp:datalist>      

                        </div>
                        <ul>	
                            <asp:datalist id="dataANXH2"  runat="server" >
                                <ItemTemplate>
                                    <li>
                                        <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                            <img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="59" height="42" />
                                        </a>
                                        <a id="title" title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>"><%# Eval("tieuDe")%></a>
                                    </li>	
                                </ItemTemplate>
                            </asp:datalist>      
                            

                        </ul>            	
                    </div>
                    <div class="l-radio fl">
                        <h1><ins><a href="Category.aspx?id=5">Xem thêm</a></ins>Bóng đá</h1>
                         <div class="hot fl">    
                            <asp:datalist id="dataBongda1"  runat="server">
                                <ItemTemplate>
                                    <a href="Post.aspx?id=<%# Eval("id")%>" title="<%# Eval("tieuDe")%>>">
                                        <img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="203" height="128"/>
                                    </a>  
                                    <a href="Post.aspx?id=<%# Eval("id")%>" title="<%# Eval("tieuDe")%>" ><%# Eval("tieuDe")%></a>
                                    <p> 
                                        <%# Eval("moTa").ToString().Substring(0, 120) %>...
                                    </p>
                                </ItemTemplate>
                            </asp:datalist>      

                        </div>
                        <ul>	
                            <asp:datalist id="dataBongda2"  runat="server" >
                                <ItemTemplate>
                                    <li>
                                        <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>">
                                            <img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="59" height="42" />
                                        </a>
                                        <a id="title" title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>"><%# Eval("tieuDe")%></a>
                                    </li>	
                                </ItemTemplate>
                            </asp:datalist>      
                            

                        </ul>        	
                    </div>            
                </div>
                <!-- end content index -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<!-- main content -->
<div class="fix-res fl">
    <!-- Family -->
    <div class="kynang">
<%--        <span></span>--%>
        <h1><ins><a href="Category.aspx?id=7">Xem thêm</a></ins>Thế giới</h1>
        <ul>
            <asp:datalist id="dataTG"   runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <li>
                        <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>"><img src="<%# Eval("hinhAnh")%>" alt="<%# Eval("tieuDe")%>" width="201" height="141"/></a>
                        <a title="<%# Eval("tieuDe")%>" href="Post.aspx?id=<%# Eval("id")%>"> <%# Eval("tieuDe")%></a>
                        <p> <%# Eval("moTa").ToString().Substring(0, 120) %>...</p>
                    </li>
                </ItemTemplate>
            </asp:datalist>
        </ul>
    </div>
    <div class="chiase thitham">
        <h1><ins><a href="Category.aspx?id=10">Xem thêm</a></ins> Du lịch</h1>

        <div class="hot-news fl">
            <asp:datalist id="dataDulich1" runat="server"  >
                <ItemTemplate>
                    <a title="<%# Eval("tieuDe")%>"  href="Post.aspx?id=<%# Eval("id")%>"><img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="212" height="149"/></a>
                    <a title="<%# Eval("tieuDe")%>"  href="Post.aspx?id=<%# Eval("id")%>"><%# Eval("tieuDe")%></a>
                    <p> 
                       <%# Eval("moTa")%>
                    </p>
                </ItemTemplate>
            </asp:datalist>

        </div>
        <ul>
            <asp:datalist id="dataDulich2"  runat="server" >
                <ItemTemplate>
                    <li class="clearfix">
                        <a title="<%# Eval("tieuDe")%>"  href="Post.aspx?id=<%# Eval("id")%>"><img alt="<%# Eval("tieuDe")%>" src="<%# Eval("hinhAnh")%>" width="120" height="90"/></a>
                        <a title="<%# Eval("tieuDe")%>"  href="Post.aspx?id=<%# Eval("id")%>"><%# Eval("tieuDe")%></a>
                        <p> 
                                    <%# Eval("mota")%>
                        </p>
                    </li>
                </ItemTemplate>
            </asp:datalist>
        </ul>
    </div>
</div>
<!--end main content -->
</asp:Content>

