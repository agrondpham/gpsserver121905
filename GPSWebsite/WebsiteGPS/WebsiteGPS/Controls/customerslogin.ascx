<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc1" %>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AdminTemplate/niceforms-default.css" />
<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
<%--set validation--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#loginForm").validate();
        onsubmit: false;
    });
    $("#ctl02_btnLogin").click(function (evt) {
        // Validate the form and retain the result.
        var isValid = $("#loginForm").valid();

        // If the form didn't validate, prevent the
        //  form submission.
        if (!isValid)
            evt.preventDefault();
    });
    
</script>
<form id="loginForm" runat="server" class="niceform">
<div id="main_container">
	<div class="header_login">
        <div class="logo"><img src="../Themes/_default/AdminTemplate/images/logo.png" alt="" title=""/></div>
    </div>
         <div class="login_form"> 
            <h3><asp:Label ID="lblTitle" runat="server" Text="[Admin Panel Login]"></asp:Label></h3>
            <asp:HyperLink ID="hypForgot" runat="server" NavigateUrl="../Pages/forgotpassword.html" CssClass="forgot_pass">[Forgot username or password]</asp:HyperLink>
            <fieldset>
                <dl>
                    <dd><asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label></dd>
                </dl>
                <dl>
                    <dt><asp:Label runat="server" Text="[UserName]" id="lblUsername" CssClass="label"></asp:Label></dt>
                    <dd><asp:TextBox runat="server" id="tbxUsername" CssClass="ui-corner-all required"></asp:TextBox></dd>
                </dl>
                <dl>
                    <dt><asp:Label runat="server" Text="[Password]" id="lblPassword"  CssClass="label"></asp:Label></dt>
                    <dd><asp:TextBox runat="server" TextMode="Password" id="tbxPassword" CssClass="ui-corner-all required"></asp:TextBox></dd>
                </dl> 
                <dl>
                    <dt><label></label></dt>
                    <dd>
                <input type="checkbox" name="interests[]" id="" value="" /><label class="check_label">Remember me</label>
                    </dd>
                </dl>
                    <dl class="submit">
                <asp:Button runat="server" Text="[Login]" id="btnLogin"
                    onclick="btnLogin_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-state-hover"></asp:Button>
                    </dl>
                    
            </fieldset>       
         </div>           
	<uc1:footer ID="footer1" runat="server" />
</div>		
</form>
   

   