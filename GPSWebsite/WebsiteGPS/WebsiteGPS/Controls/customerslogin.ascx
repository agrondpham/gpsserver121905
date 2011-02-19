<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
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
    <div class="login_form"> 
    <h3><asp:Label ID="lblTitle" runat="server" Text="[Admin Panel Login]"></asp:Label></h3>
    <asp:HyperLink ID="hypForgot" runat="server" NavigateUrl="../forgotpassword.html" CssClass="forgot_pass">[Forgot username or password]</asp:HyperLink>
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
</form>
   

   