<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
<link href="../Themes/_default/Styles/login.css" rel="stylesheet" type="text/css" />
<form id="form1" runat="server">
<div>
	<div class="logiMain">
		<div class="rw notification" style="height:50px"><asp:Label runat="server" Text="[Notification]" id="lblNotification"></asp:Label></div>
		<div class="rw">
			<div class="lfcl"><asp:Label runat="server" Text="[UserName]" id="lblUsername"></asp:Label></div>
			<div class="rgcl"><asp:TextBox runat="server" id="tbxUsername"></asp:TextBox></div>
		    <div><img class="style1" src="../Themes/_default/Images/notifi16px.png" /></div>
        </div>
		<div class="rw">
			<div class="lfcl"><asp:Label runat="server" Text="[Password]" id="lblPassword"></asp:Label></div>
			<div class="rgcl"><asp:TextBox runat="server" id="tbxPassword"></asp:TextBox></div>
            <div><img class="style1" src="../Themes/_default/Images/notifi16px.png" /></div>
		</div>
		<div class="rw">
			<div class="lfcl"><asp:Button runat="server" Text="[Login]" id="btnLogin"></asp:Button></div>
			<div class="rgcl"><asp:HyperLink runat="server" id="hypForgot">[Forgot username or password]</asp:HyperLink></div>
		</div>
	</div>
</div>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</form>