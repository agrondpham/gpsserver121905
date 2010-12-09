<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMaps.ascx.cs" Inherits="WebsiteGPS.Controls.Maps.GoogleMaps" %>

<link href="../../Themes/_default/Styles/googlemap.css" rel="stylesheet" 
    type="text/css" />
<script type="text/javascript"
    src="http://maps.google.com/maps/api/js?sensor=true">
</script>
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

    }

</script>
<div id="map_canvas"></div>