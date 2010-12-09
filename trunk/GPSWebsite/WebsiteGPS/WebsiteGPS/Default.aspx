<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteGPS.Default" %>

<%@ Register src="Controls/Maps/googlemaps.ascx" tagname="googlemaps" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>[GPSSystemTitle]</title>
</head>
<body onload="initialize()">
    <uc1:googlemaps ID="googlemaps" runat="server" />
</body>
</html>
