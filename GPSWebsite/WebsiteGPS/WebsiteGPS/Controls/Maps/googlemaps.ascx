<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMaps.ascx.cs" Inherits="WebsiteGPS.Controls.Maps.GoogleMaps" %>

<%@ Register src="../MapControler/historictracking.ascx" tagname="historictracking" tagprefix="uc1" %>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
<%--code Map--%>
<script type="text/javascript">
    var map;
    function initialize() {
        var Long = new google.maps.LatLng(10.8292, 106.63903333333333);
        var Duong = new google.maps.LatLng(10.812233333333333, 106.69376666666666);
        var myOptions = {
            zoom: 13, //edit zoom to point
            mapTypeControl: false, //invisible Map control
            center: Duong, //put center of map
            mapTypeId: google.maps.MapTypeId.ROADMAP//choice type of map
        };
        map = new google.maps.Map(document.getElementById("map_canvas"),
        myOptions);
        var marker = new google.maps.Marker({
            map: map,
            position: Duong,
            title: "Duong House"
        });
        var marker = new google.maps.Marker({
            map: map,
            position: Long,
            title: "Long House"
        });
        //loadMarker(); 
    }
    function setMap(map) {
        for (i = 0; i < 23; i++) {
            var latlng = new google.maps.LatLng(data.marker[i].latitude, data.marker[i].longitude);
            var marker = new google.maps.Marker({
                map: map,
                position: latlng,
                title: "Marker2"
            });
        }
    }
</script>
<link href="../../Themes/_default/Styles/googlemap.css" rel="stylesheet" type="text/css" />

<div id="map_canvas" style="height:100%;min-height:605px;min-width:405px;width:100%;float:left">
</div>

<form id="form1" runat="server">
<uc1:historictracking ID="historictracking1" runat="server"/>
</form>

