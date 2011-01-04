<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forgotpassword.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.Forgotpassword" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AdminTemplate/niceforms-default.css" />
<form id="form2" runat="server" class="niceform">
<div id="main_container">

	<div class="header_login">
    <div class="logo"><img src="../Themes/_default/AdminTemplate/images/logo.gif" alt="" title=""/></div>
    
    </div>
         <div class="forgotPass_form">
         
         <h3><asp:Label ID="lblTitle" runat="server" Text="[Forgot password page]"></asp:Label></h3>
                <fieldset>
                    <dl>
                        <dt><asp:Label runat="server" Text="[Email]" id="lblEmail" CssClass="label"></asp:Label></dt>
                        <dd><asp:TextBox runat="server" id="tbxEmail"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt><asp:Label runat="server" Text="[Captcha]" id="lblCaptcha"  CssClass="label"></asp:Label></dt>
                        <dd><recaptcha:RecaptchaControl
                                    ID="recaptcha"
                                    runat="server"
                                    PublicKey="6LfFH8ASAAAAAFt5r322YLp-3wBfg-giNoouR3dT "
                                    PrivateKey="6LfFH8ASAAAAAB24iaLsuVDsXW2HT-8P1n-744x2"
                                    /></dd>
                    </dl>
                    <asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label>
                     <dl class="submit">
                    <asp:Button runat="server" Text="[Summit]" id="btnSummit" 
                    onclick="btnSummit_Click"></asp:Button>
                     </dl>
                    
                </fieldset>
                
         </div>  
          
	
    
<%--    <div class="footer_login">
    
    	<div class="left_footer_login">Chương trình quản lý | Powered by INDEZINER</div>
    	<div class="right_footer_login"><img src="../Themes/_default/AdminTemplate/images/indeziner_logo.gif" alt="" title="" /></div>
    
    </div>--%>

</div>		
</form>