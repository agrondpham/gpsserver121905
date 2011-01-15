<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forgotpassword.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.Forgotpassword" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register src="../footer.ascx" tagname="footer" tagprefix="uc1" %>
<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AdminTemplate/niceforms-default.css" />
<%--set validation--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#forgotpassForm").validate();
        onsubmit: false;
    });
    $("#ctl02_btnSummit").click(function (evt) {
        // Validate the form and retain the result.
        var isValid = $("#forgotpassForm").valid();

        // If the form didn't validate, prevent the
        //  form submission.
        if (!isValid)
            evt.preventDefault();
    });
    
</script>
<form id="forgotpassForm" runat="server" class="niceform">
<div id="main_container">

	<div class="header_login">
    <div class="logo"><img src="../Themes/_default/AdminTemplate/images/logo.png" alt="" title=""/></div>
    
    </div>
         <div class="forgotPass_form">
         
         <h3><asp:Label ID="lblTitle" runat="server" Text="[Forgot password page]"></asp:Label></h3>
                <fieldset>
                    <dl>
                        <dt><asp:Label runat="server" Text="[Email]" id="lblEmail" CssClass="label"></asp:Label></dt>
                        <dd><asp:TextBox runat="server" id="tbxEmail" CssClass="required email"></asp:TextBox></dd>
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
                    onclick="btnSummit_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-state-hover"></asp:Button>
                     </dl>
                    
                </fieldset>
                
         </div>  
          
	<uc1:footer ID="footer1" runat="server" />

</div>		
</form>

