<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AdminTemplate/niceforms-default.css" />
<form id="form1" runat="server" class="niceform">
<div id="main_container">

	<div class="header_login">
    <div class="logo"><img src="../Themes/_default/AdminTemplate/images/logo.gif" alt="" title=""/></div>
    
    </div>

     
         <div class="login_form">
         
         <h3><asp:Label ID="lblTitle" runat="server" Text="[Admin Panel Login]"></asp:Label></h3>
         
         <asp:HyperLink ID="hypForgot" runat="server" NavigateUrl="../Pages/forgotpassword.html" CssClass="forgot_pass">[Forgot username or password]</asp:HyperLink>
         
                <fieldset>
                    <dl>
                        <dt><asp:Label runat="server" Text="[UserName]" id="lblUsername" CssClass="label"></asp:Label></dt>
                        <dd><asp:TextBox runat="server" id="tbxUsername" CssClass="ui-corner-all"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt><asp:Label runat="server" Text="[Password]" id="lblPassword"  CssClass="label"></asp:Label></dt>
                        <dd><asp:TextBox runat="server" id="tbxPassword" CssClass="ui-corner-all"></asp:TextBox></dd>
                    </dl>
                    
                    <dl>
                        <dt><label></label></dt>
                        <dd>
                    <input type="checkbox" name="interests[]" id="" value="" /><label class="check_label">Remember me</label>
                        </dd>
                    </dl>
                    <asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label>
                     <dl class="submit">
                    <asp:Button runat="server" Text="[Login]" id="btnLogin"
                        onclick="btnLogin_Click"></asp:Button>
                     </dl>
                    
                </fieldset>
                
         </div>  
          
	
    
<%--    <div class="footer_login">
    
    	<div class="left_footer_login">Chương trình quản lý | Powered by INDEZINER</div>
    	<div class="right_footer_login"><a href="http://indeziner.com"><img src="../Themes/_default/AdminTemplate/images/indeziner_logo.gif" alt="" title="" /></a></div>
    
    </div>--%>

</div>		
</form>
   