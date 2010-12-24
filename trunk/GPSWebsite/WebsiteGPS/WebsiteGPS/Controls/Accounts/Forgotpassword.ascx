<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forgotpassword.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.Forgotpassword" %>
<form id="form1" runat="server">
<div>
	<div class="logiMain">
		<div class="rw notification" style="height:50px"><asp:Label runat="server" Text="[Notification]" id="lblNotification"></asp:Label></div>
		<div class="rw">
			<div class="lfcl"><asp:Label runat="server" Text="[Email]" id="lblEmail"></asp:Label></div>
			<div class="rgcl"><asp:TextBox runat="server" id="tbxEmail"></asp:TextBox></div>
		    <div><img class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>
        </div>		
		<div class="rw">
            <div><asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label></div>
			<div class="lfcl"><asp:Button runat="server" Text="[Summit]" id="btnSummit"></asp:Button></div>
			
		</div>
	</div>
</div>

</form>