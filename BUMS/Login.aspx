<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BUMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
    <link type="text/css" rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="icon" type="image/png" href="assets/img/libraryfavicon.ico">
    <title>Đăng nhập</title>
</head>
<body>
    <div class="limiter">
		<div class="container-login100" style="background-color:rgba(194, 197, 199, 0.36)">
			<div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
				<form id="form1" runat="server">
					<span class="login100-form-title p-b-49">
						Đăng nhập
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Tên không được rỗng">						
                        <asp:TextBox ID="txtUsername" class="input100" runat="server" placeholder="Nhập mã nhân viên" required="true" tooltip="please enter address your account!"></asp:TextBox>
						
					</div>

					<div class="wrap-input100 validate-input" data-validate="Mật khẩu không được rỗng">						
                        <asp:TextBox ID="txtPassword" class="input100" runat="server" placeholder="Nhập mật khẩu" TextMode="Password" tooltip="please enter password!" required="true"></asp:TextBox>
						
					</div>
					
					<div class="text-right p-t-8 p-b-31">
                        <asp:CheckBox ID="CheckBox1" class="form-check-input" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"/>
				    	<span class="label-input100">Nhớ Mật khẩu?</span>
					</div>
                    <asp:Button ID="btnLogin" class="login100-form-btn" style="color:cadetblue" runat="server" Text="ĐĂNG NHẬP" Font-Size=" 30px" OnClick="btnLogin_Click" />                    
					                 
				</form>
			</div>
		</div>
	</div>
</body>
</html>

