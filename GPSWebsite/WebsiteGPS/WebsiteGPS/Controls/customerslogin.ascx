<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
<link href="../Themes/_default/LoginStyle/stylelog.css" rel="stylesheet" type="text/css" />
<form id="form1" runat="server">
<div id="layer01_holder">
  <div id="left"></div>
  <div id="center"></div>
  <div id="right"></div>
</div>

<div id="layer02_holder">
  <div id="left"></div>
  <div id="center"></div>
  <div id="right"></div>
</div>
<div id="layer03_holder">
  <div id="left"></div>
  <div id="center">

	    <div class="logiMain">
		    <%--<div class="rw notification" style="height:50px"><asp:Label runat="server" Text="[Notification]" id="lblNotification"></asp:Label></div>--%>
		    <div class="rw">
			    <div class="lfcl"><asp:Label runat="server" Text="[UserName]" id="lblUsername"></asp:Label></div>
			    <div class="rgcl"><asp:TextBox runat="server" id="tbxUsername"></asp:TextBox></div>
		        <%--<div><img class="style1" src="../Themes/_default/Images/notifi16px.png" /></div>--%>
            </div>
		    <div class="rw">
			    <div class="lfcl"><asp:Label runat="server" Text="[Password]" id="lblPassword"></asp:Label></div>
			    <div class="rgcl"><asp:TextBox runat="server" id="tbxPassword"></asp:TextBox></div>
                <%--<div><img class="style1" src="../Themes/_default/Images/notifi16px.png" /></div>--%>
		    </div>
		    <div class="rw">
                <div></div>
			    <div class="lfcl"><asp:Button runat="server" Text="[Login]" id="btnLogin" 
                        onclick="btnLogin_Click"></asp:Button></div>
		    </div>
	    </div>

  </div>
  <div id="right"></div>
</div>
<div id="layer04_holder">
  <div id="left"></div>
  <div id="center"><asp:Label runat="server" id="lblErr" ForeColor="Red"></asp:Label></br>
 <asp:HyperLink ID="hypForgot" runat="server" NavigateUrl="../Pages/forgotpassword.html">[Forgot username or password]</asp:HyperLink></div>
  <div id="right"></div>
</div>

<div id="layer05_holder">
  <div align="left">Copyright © 2007, Artfans Design</div>
</div>
</form>
    









