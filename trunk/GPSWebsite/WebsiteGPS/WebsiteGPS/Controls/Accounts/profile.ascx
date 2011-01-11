<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profile.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.profile" %>
<%@ Register Src="ChangePassword.ascx" TagName="ChangePassword" TagPrefix="uc1" %>
<link href="../Themes/_default/Styles/profile.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(function () {
        //AddUser Dialog
        $("#add-user-dialog").dialog({
            autoOpen: false,
            resizable: false,
            height: 500,
            width: 650,
            modal: true
        });
        $("#add-user-dialog").parent().appendTo(jQuery("form:first")); //Move form of dialog become the first Form(Dua Form cua New Account len xu ly dau)
        //add Listener open dialog new AddUser
        $("#hypAddUser")
			.click(function () {
			    $("#add-user-dialog").dialog("open");
			});
    });
</script>
<div>
    <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
</div>

<div class="profile_table">
    <div class="profile_lf">
        <asp:Label runat="server" Text="[UserName]" ID="Label2"></asp:Label>
    </div>
    <div class="rw">
        <a id="hypAddUser" href="#" class="bt_green">
            <asp:Label ID="lblAddnew" runat="server" Text="[Change Password]"></asp:Label>
            </a>
        <div id="add-user-dialog" title="[Change Password]">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <uc1:ChangePassword ID="ChangePassword" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="rw">
        <div class="lfcl">
            <asp:Label runat="server" Text="[Email]" ID="Label3"></asp:Label></div>
        <div class="rgcl">
            <asp:Label runat="server" Text="[Email]" ID="lblEmail" CssClass="text ui-widget-content ui-corner-all"></asp:Label>
        </div>
        <div class="profile_lf">
            <asp:Label runat="server" Text="[Full Name]" ID="Label4"></asp:Label></div>
        <div class="profile_rg">
            <asp:Label runat="server" Text="[Full Name]" ID="lblFullName" CssClass="text ui-widget-content ui-corner-all"></asp:Label></div>
    </div>
    <div class="rw-control">
        <div class="profile_lf">
            <asp:Button runat="server" Text="[Commit]" ID="btnCommit" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
            </asp:Button>
        </div>
    </div>
</div>
