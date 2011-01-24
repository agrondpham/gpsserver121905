<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controller.ascx.cs"
    Inherits="WebsiteGPS.Controls.Controler.controller" %>
<%@ Register Src="../Accounts/profile.ascx" TagName="profile" TagPrefix="uc1" %>
<%--StyleSheet inport--%>
<link rel="stylesheet" href="../../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<link href="../../Themes/_default/Styles/controller.css" rel="stylesheet" type="text/css" />
<%-- Library Jquery inport--%>
<script src="../../Scripts/pageScripts/controler.js" type="text/javascript"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="WidgetControler" class="ui-controller ui-corner-all">
    <ul>
        <li><a href="#HistoryTracking">
            <img style="border:0px" title="[History]" alt="" src="../../Themes/_default/Images/historytracking_icon48.png" /></a></li>
        <li><a href="#TrackingOnline">
            <img style="border:0px" title="[Tracking]" alt="" src="../../Themes/_default/Images/tracking_icon48.png" /></a></li>
        <li><a id="hypProfile">
            <img title="[Profile]" alt="" src="../../Themes/_default/Images/account_icon48.png" /></a></li>
        <li><a id="hypHide" class="close-icon">
            <img title="[Close]" alt="" src="../../Themes/_default/Images/delete_icon48.png" /></a></li>
    </ul>
    
    <div id="HistoryTracking" class="ui-controller-maincontent">
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                <asp:Label ID="lblDevices" runat="server" Text="[Choice Device]"></asp:Label></div>
            <div class="ui-controller-component">
                <asp:DropDownList ID="drdDevices" runat="server" AutoPostBack="True" CssClass="required">
                </asp:DropDownList>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                <asp:Label ID="lblStartTime" runat="server" Text="[Choice Time Start]"></asp:Label></div>
            <div class="ui-controller-component">
                <asp:TextBox ID="tbxStartTime" runat="server" CssClass="text ui-corner-all required" Enabled="false"></asp:TextBox>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                <asp:Label ID="lblStopTime" runat="server" Text="[Choice Time Stop]"></asp:Label></div>
            <div class="ui-controller-component">
                <asp:TextBox ID="tbxStopTime" runat="server" CssClass="text ui-corner-all required" Enabled="false"></asp:TextBox>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-Controller-button">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-state-hover" ID="btnShowMarkers" runat="server" Text="[Show Data]" OnClick="btnShowMarkers_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </div>
    <div id="TrackingOnline" class="ui-controller-maincontent">
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                <asp:Label ID="lblDevices2" runat="server" Text="[Choice Device]"></asp:Label></div>
            <div class="ui-controller-component">
                <asp:DropDownList ID="drdDevices2" runat="server">
                    <asp:ListItem>Long2</asp:ListItem>
                    <asp:ListItem>Duong2</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-Controller-button">
            <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-state-hover" ID="btnTracking" runat="server" Text="[Tracking]" />
        </div>
    </div>
    <div class="logo">
        <img src="../Themes/_default/LoginStyle/images/logo.png" alt="" title=""/>
        <img src="../Themes/_default/LoginStyle/images/beta_icon.gif" style="width:50px;height:50px"alt="" title=""/>
    </div>
</div>
<div id="ProfileDialog" title="[View Profile]">
    <uc1:profile ID="profile1" runat="server" />
</div>
<div class="ui-controller-showPanel">
    <a id="hypShow" class="ui-state-default ui-corner-all" style="cursor: pointer;background:url('../AdminTemplate/images/bg.jpg') no-repeat scroll 90% 0 #320B28">
        <img alt="" src="../../Themes/_default/Images/map_icon.png" />
    </a>
</div>
