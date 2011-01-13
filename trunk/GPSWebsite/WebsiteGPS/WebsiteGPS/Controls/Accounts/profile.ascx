<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profile.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.profile" %>
<%@ Register Src="ChangePassword.ascx" TagName="ChangePassword" TagPrefix="uc1" %>
<link href="../Themes/_default/Styles/profile.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(function () {
        //AddUser Dialog
        $("#profile-changePass-dialog").dialog({
            autoOpen: false,
            resizable: false,
            height: 300,
            width: 400,
            modal: true
        });
        $("#profile-changePass-dialog").parent().appendTo(jQuery("form:first")); //Move form of dialog become the first Form(Dua Form cua New Account len xu ly dau)
        //add Listener open dialog new AddUser
        $("#hypChanePass")
			.click(function () {
			    $("#profile-changePass-dialog").dialog("open");
			});
    });
</script>
<div>
    <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
</div>

<div class="profile_table">
    <div class="profile_lf">
        <asp:Label runat="server" Text="[UserName]" ID="lblUser"></asp:Label>
    </div>
    <div class="profile_lf">
        <a id="hypChanePass" href="#" class="bt_green">
            <asp:Label ID="lblChangePass" runat="server" Text="[Change Password]"></asp:Label>
            </a>
    </div>
    <div id="profile-changePass-dialog" title="[Change Password]" class="profile_rg">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <uc1:ChangePassword ID="ChangePassword" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    <div class="profile_lf">
        <asp:Label runat="server" Text="[Email]" ID="lblEmail"></asp:Label></div>
    <div class="profile_rg">
        <asp:Label runat="server" Text="[Email]" ID="lblEmailValue" CssClass="text ui-widget-content ui-corner-all"></asp:Label>
    </div>
    <div class="profile_lf">
        <asp:Label runat="server" Text="[Full Name]" ID="lblFullName"></asp:Label></div>
    <div class="profile_rg">
        <asp:Label runat="server" Text="[Full Name]" ID="lblFullNameValue" CssClass="text ui-widget-content ui-corner-all"></asp:Label></div>
    <div class="rw-control">
        <div class="profile_lf">
            <asp:Button runat="server" Text="[Commit]" ID="btnCommit" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
            </asp:Button>
        </div>
    </div>
</div>
