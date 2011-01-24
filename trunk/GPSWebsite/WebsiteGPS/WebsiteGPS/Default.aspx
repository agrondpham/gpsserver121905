<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteGPS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="Themes/_default/AdminTemplate/images/logo.png" />

<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
<script type="text/javascript" src="../Scripts/jquery-1.4.4.js" ></script>
<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
<script src="../Scripts/librarys/jquery-ui-1.8.7.custom.min.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-vi.js" type="text/javascript"></script>
<style type="text/css">
  html { height: 100% }
  body { height: 100%; margin: 0px; padding: 0px }
</style>
</head>
<body onload="initialize()">
    <asp:PlaceHolder ID="BodyHolder" runat="server" />  
</body>
</html>
