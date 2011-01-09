<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMaps.ascx.cs" Inherits="WebsiteGPS.Controls.Maps.GoogleMaps" %>

<%@ Register src="../MapControler/historictracking.ascx" tagname="historictracking" tagprefix="uc1" %>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
<%--code Map--%>
<script type="text/javascript">
    var map;
    var poly;
    //windown info
    var speedString ='<div class="infowindows_table">'+
                     '<div class="infowindows_table_lf">[speed]:</div>'+
                     '<div class="infowindows_table_rg">';
    var dateString  = ' km/h </div'+
                      '<div class="infowindows_table_lf">[Date]:</div>'+
                      '<div class="infowindows_table_rg">';
    var timeString  = '</div'+
                      '<div class="infowindows_table_lf">[Time]:</div>'+
                      '<div class="infowindows_table_rg">';
    var footerString = '</div><div style="clear"></div></div>';  
    var contentString;
    var markersArray = [];
    var infowindow ;

    function initialize() {
        var Long = new google.maps.LatLng(10.8292, 106.63903333333333);
        var Duong = new google.maps.LatLng(10.812233333333333, 106.69376666666666);
        var myOptions = {
            zoom: 13, //edit zoom to point
            mapTypeControl: false, //invisible Map Type control
            center: Duong, //put center of map
            mapTypeId: google.maps.MapTypeId.ROADMAP,//choice type of map
            navigationControl: true, //visible Map Zoom control
            navigationControlOptions: {
                style: google.maps.NavigationControlStyle.ZOOM_PAN,
                position: google.maps.ControlPosition.TOP_RIGHT
            }
        };
        map = new google.maps.Map(document.getElementById("map_canvas"),
        myOptions);
        var markerDuong = new google.maps.Marker({
            map: map,
            position: Duong,
            title: "Duong House"
        });
        var markerLong = new google.maps.Marker({
            map: map,
            position: Long,
            title: "Long House"
        });
        //loadMarker();

        google.maps.event.addListener(map, 'click', function () {
            infowindow.close();
        });

        //polyline
        var polyOptions = {
            strokeColor: '#51bff8',
            strokeOpacity: 1.0,
            strokeWeight: 3
        }
        poly = new google.maps.Polyline(polyOptions); 
    }
    function setMap(map) {
        //clearOverlays();
        deleteOverlays();
        //poly.setMap(null);
        poly.setMap(map);
        var path = poly.getPath(); //dung cho ve duong di
        for (i = 0; i < 23; i++) {
            var image = "../../Themes/_default/Images/gpsPoint_icon24.png"
            if (i == 0) { image = "../../Themes/_default/Images/gpsStart_icon32.png"; }
            if (1 == 22) { image = "../../Themes/_default/Images/gpsStop_icon32.png"; }
            var latlng = new google.maps.LatLng(data.marker[i].latitude, data.marker[i].longitude);
            var marker = new google.maps.Marker({
                map: map,
                position: latlng,
                title: "Marker2",
                icon: image
            });
            path.push(latlng); //dua cac diem len de noi
            var strDateTime=data.marker[i].date;
            var dateStringValue= strDateTime.substring(0,10);
            var timeStringValue = strDateTime.substring(11, 19);
            contentString = speedString + data.marker[i].speed + dateString + dateStringValue + timeString + timeStringValue + footerString;
            addInforWindow(marker); //bat buoc phai tach ra lam mot ham rieng
            markersArray.push(marker);
        }

    }
    function addInforWindow(marker) {
        //add info window
        infowindow= new google.maps.InfoWindow({
            content: contentString,
            size: new google.maps.Size(200, 100)
        });
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
    }
    function deleteOverlays() {
        var path = poly.getPath();
        if (markersArray) {
            for (i in markersArray) {
                markersArray[i].setMap(null);
            }
            for (i in path) {
                path.removeAt(i);
            }
            markersArray.length = 0;

        }
    }

</script>
<link href="../../Themes/_default/Styles/googlemap.css" rel="stylesheet" type="text/css" />
<link href="../../Themes/_default/Styles/Style.css" rel="stylesheet" type="text/css" />
<div id="map_canvas" style="height:100%;min-height:605px;min-width:405px;width:100%;float:left">
</div>

<form id="form1" runat="server">
<uc1:historictracking ID="historictracking1" runat="server"/>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
    <div class="uploadProcess"><img alt="" class="uploadProcess_image" src="../../Themes/_default/Images/ajax_loadingBarRed.gif" /></div>
</ProgressTemplate>
</asp:UpdateProgress>
</form>

