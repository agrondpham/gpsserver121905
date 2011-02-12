<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebsiteGPS.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="errorForm" runat="server" class="niceform">
<div id="main_container">
	<div class="header_login">
        <div class="logo"><img src="../Themes/_default/Images/logo.png" alt="" title=""/></div>
    </div>
         <div class="login_form"> 
            <h3><asp:Label ID="lblTitle" runat="server" Text="[Admin Panel Login]"></asp:Label></h3>
            <asp:HyperLink ID="hypForgot" runat="server" NavigateUrl="../Pages/forgotpassword.html" CssClass="forgot_pass">[Forgot username or password]</asp:HyperLink>
            <fieldset>
                <dl>
                    <dd><asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label></dd>
                </dl>   
            </fieldset>       
         </div>           
	<uc1:footer ID="footer1" runat="server" />
</div>		
</form>
</body>
</html>
