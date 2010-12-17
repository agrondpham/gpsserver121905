<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMaps.ascx.cs" Inherits="WebsiteGPS.Controls.Maps.GoogleMaps" %>

<%@ Register src="../MapControler/historictracking.ascx" tagname="historictracking" tagprefix="uc1" %>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
<script type="text/javascript">
    function initialize() {
        var latlng = new google.maps.LatLng(10.8292, 106.63903333333333);
        var myOptions = {
            zoom: 15, //edit zoom to point
            mapTypeControl: false, //invisible Map control
            center: latlng, //put center of map
            mapTypeId: google.maps.MapTypeId.ROADMAP//choice type of map
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"),
        myOptions);
        var marker = new google.maps.Marker({
            map: map,
            position: latlng,
            title: "Hello World"
        });
        //loadMarker(); 
    }

    function loadMarker() {
        var latlng2 = new google.maps.LatLng(10.8293, 106.63905333333333);
        var marker2 = new google.maps.Marker({
            map: map,
            position: latlng2,
            title: "Hello World"
        });
    }
</script>
<link href="../../Themes/_default/Styles/googlemap.css" rel="stylesheet" 
    type="text/css" />
<div id="map_canvas" style="height:100%;min-height:605px;min-width:405px;width:100%;float:left">
</div>
<form id="form1" runat="server">
<uc1:historictracking ID="historictracking1" runat="server"/>
</form>

