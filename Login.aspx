<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="/Admin/css/bootstrap.min.css" rel="stylesheet" />
        <script src="/Admin/js/jquery.js"></script>
        <script src="/Admin/js/bootstrap.min.js"></script>
        <link href="Admin/css/jquery-ui.min.css" rel="stylesheet" />
        <link href="/Admin/css/jquery-ui.min.css" rel="stylesheet" />
        <script src="Admin/js/jquery-ui.min.js"></script>
        <style>
            body {
                background-color: #222;
            }

        </style>
       <script>
           $(function () {
               $("#txtNgaySinh").datepicker({ 'dateFormat': 'yy-mm-dd' });
           });
    </script>
    </head>
    <body>
        <form  d="form1" runat="server" class="form-horizontal" >
            <div class="container">    
                <div id="loginbox" style="margin-top:120px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
                    <div class="panel panel-info" >
                        <div class="panel-heading">
                            <div class="panel-title">Thành viên đăng nhập</div>

                        </div>     
                        <div style="padding-top:30px" class="panel-body" >
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox ID="logintenDN" CssClass="form-control" runat="server" placeholder="Tên đăng nhập"></asp:TextBox>                                
                            </div>
                            
                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox ID="loginmatKhau" TextMode="Password" CssClass="form-control" runat="server" placeholder="Mật khẩu"></asp:TextBox>  
                            </div>

                            <div style="margin-top:10px" class="form-group">
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button ID="btnDangnhap" runat="server"  CssClass="btn btn-success" Text="Đăng nhập" OnClick="btnDangnhap_Click"  />
                                   
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-12 control">
                                    <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                        <a style="padding-right:40px;" href="#">Quên mật khẩu?</a>
                                        <a name="dangky" href="#" onclick="$('#loginbox').hide(); $('#signupbox').show()">Đăng ký</a>

                                    </div>
                                </div>
                            </div>    

                        </div>                     
                    </div>  

                </div>
                <div id="signupbox" style="display:none; margin-top:30px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Đăng ký</div>
                            <div style="float:right; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" onclick="$('#signupbox').hide(); $('#loginbox').show()">Đăng nhập</a></div>
                        </div>  
                        <div class="panel-body" >

                            <div id="signupalert" style="display:none" class="alert alert-danger">
                                <p>Lỗi:</p>
                                <span></span>
                            </div>


                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Tên đăng nhập <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtTenDN"  CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Mật khẩu  <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtMk" TextMode="Password" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Nhập lại mật khẩu  <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtReMk" TextMode="Password" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="email" class="col-md-3 control-label">Email  <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEmail"  CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Họ và tên  <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtHoten" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Giới tính <span style="color:red">*</span></label>
                                <div class="col-md-9">
                                    <asp:DropDownList CssClass="form-control" ID="ddGioitinh" runat="server">
                                        <asp:ListItem Value="1" Selected="True">Nam</asp:ListItem>
                                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Ngày sinh</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtNgaySinh" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">Địa chỉ</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtDiaChi" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <!-- Button -->                                        
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnDangky" runat="server" CssClass="btn btn-info" Text="Đăng ký" OnClick="btnDangKy_Click"  />
                                    <%--<span style="margin-left:8px;">hoặc</span>  --%>
                                </div>
                            </div>

                           <%-- <div style="border-top: 1px solid #999; padding-top:20px"  class="form-group">

                                <div class="col-md-offset-3 col-md-9">
                                    <button id="btn-fbsignup" type="button" class="btn btn-primary"><i class="icon-facebook"></i>   Đăng ký bằng Facebook</button>
                                </div>                                           

                            </div>--%>

                        </div>
                    </div>
                </div> 
            </div>
        </form>
    </body>
</html>

