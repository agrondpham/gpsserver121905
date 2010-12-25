<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createaccount.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.createaccount" %>
<div class="rw">
    <div class="lfcl">
        <asp:Label runat="server" Text="[UserName]" ID="lblUsername"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox ID="tbxUserName" runat="server" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox>
    </div>
    <div>
        <img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>
</div>
<div class="rw">
    <div class="lfcl">
        <asp:Label runat="server" Text="[Password]" ID="lblPassword"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxPassword" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div>
        <img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>
</div>
<div class="rw">
    <div class="lfcl">
        <asp:Label runat="server" Text="[Email]" ID="lblEmail"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxEmail" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div>
        <img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>
</div>
        <div class="rw">
    <div class="lfcl">
        <asp:Label runat="server" Text="[Full Name]" ID="lblFullName"></asp:Label></div>
    <div class="rgcl">
        <asp:TextBox runat="server" ID="tbxFullName" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox></div>
    <div>
        <img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>
</div>
<div class="rw-control">
    <div class="lfcl">
        <asp:Button runat="server" Text="[Commit]" ID="btnCommit" OnClick="btnCommit_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
        </asp:Button>
    </div>
    <div class="rgcl">
        <asp:Button runat="server" Text="[Add New]" ID="btnAddNew" OnClick="btnAddNew_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
        </asp:Button>
    </div>
    <div>
        <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
    </div>
</div>