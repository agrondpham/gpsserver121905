﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteGPS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
  html { height: 100% }
  body { height: 100%; margin: 0px; padding: 0px }
</style>
</head>
<body onload="initialize()">
    <asp:PlaceHolder ID="BodyHolder" runat="server" />
<%--    <form id="form1" runat="server">
    <asp:Label ID="lblWebTitle" runat="server" Text="[GPSSystemTitle]"></asp:Label>
    <asp:Label ID="lblWebTitle2" runat="server" Text="[GPSSystemTitle]"></asp:Label>
    <uc1:googlemaps ID="googlemaps" runat="server" />
        <asp:GridView runat="server" ID="GridView1">
        </asp:GridView>
    
    </form>--%>
    
</body>
</html>