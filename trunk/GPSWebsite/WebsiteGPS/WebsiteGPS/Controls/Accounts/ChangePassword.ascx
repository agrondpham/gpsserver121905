<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs"
    Inherits="WebsiteGPS.Controls.Accounts.ChangePassword" %>
<div>
    <div class="lfcl">
        <asp:Label runat="server" Text="[Old Password]" ID="lblOldPassword"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxOldPassword" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div class="lfcl">
        <asp:Label runat="server" Text="[New Password]" ID="lblNewPassword"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxNewPassword" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div class="lfcl">
        <asp:Label runat="server" Text="[Re-type password]" ID="lblRePassword"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxRePassword" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div class="rgcl">
        <asp:Button runat="server" Text="[Update]" ID="btnUpdate" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
        </asp:Button>
    </div>
</div>
