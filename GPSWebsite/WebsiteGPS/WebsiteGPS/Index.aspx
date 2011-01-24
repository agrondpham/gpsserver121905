<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebsiteGPS.Index" %>
<%@ Register src="Controls/footer.ascx" tagname="footer" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AdminTemplate/niceforms-default.css" />--%>
<link rel="stylesheet" type="text/css" href="../Themes/_default/LoginStyle/Style.css" />
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<script type="text/javascript" src="../Scripts/jquery-1.4.4.js" ></script>
<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
</head>
<body>
    <div id="main_container">
	    <div class="header_login">
            <div class="logo"><img src="../Themes/_default/AdminTemplate/images/logo.png" alt="" title=""/></div>
        </div>
        <asp:PlaceHolder ID="BodyHolder" runat="server" />           
	    <uc1:footer ID="footer1" runat="server" />
    </div>		
</body>
</html>
