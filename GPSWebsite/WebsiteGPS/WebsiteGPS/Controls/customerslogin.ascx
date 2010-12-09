<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerslogin.ascx.cs" Inherits="WebsiteGPS.Controls.CustomersLogin" %>
<div>
<form runat="server">
<asp:TextBox ID="txtCustomerID" runat="server"/>
<asp:TextBox ID="txtCustomerPass" TextMode="Password" runat="server"/>
<asp:Button runat="server" Text="[Login]"/>
</form>
</div>