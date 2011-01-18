<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMaps.ascx.cs" Inherits="WebsiteGPS.Controls.Maps.GoogleMaps" %>
<%@ Register src="../MapControler/controller.ascx" tagname="controller" tagprefix="uc1" %>

<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
<%--<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=ABQIAAAAJCnUvnxeaVCKKYLhaMGzSxRm1ARfQFbvxUcbu13wOqOx30MQhxQwOFQBUooA1oZopax-Nick7H_WIA" type="text/javascript"></script>--%>
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
        for (i = 0; i < data.marker.length; i++) {
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
<%--validation--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#controlForm").validate();
        onsubmit: false;
    });
    $("#ctl02_controller1_btnShowMarkers").click(function (evt) {
        // Validate the form and retain the result.
        var isValid = $("#controlForm").valid();

        // If the form didn't validate, prevent the
        //  form submission.
        if (!isValid)
            evt.preventDefault();
    });
    
</script>
<link href="../../Themes/_default/Styles/googlemap.css" rel="stylesheet" type="text/css" />

<div id="map_canvas" style="height:100%;min-height:605px;min-width:405px;width:100%;float:left;">
</div>

<form id="controlForm" runat="server">
<uc1:controller ID="controller1" runat="server"/>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
    <div class="uploadProcess"><img alt="" class="uploadProcess_image" src="../../Themes/_default/Images/ajax_loadingBarRed.gif" /></div>
    <%--<div id="loading-panel-js" style="border: 1px solid rgb(255, 255, 255); font: 12px/46px 'Segoe UI','Trebuchet MS',Arial,Verdana,Serif; -moz-border-radius: 6px 6px 6px 6px; -moz-box-shadow: 0pt 0pt 10px rgb(0, 0, 0); text-align: center; color: rgb(255, 255, 255); background-color: rgb(59, 59, 59); background-image: url('../../Themes/_default/Images/Loading_00.gif'); background-position: center center; width: 200px; height: 46px; margin-left: -100px; margin-top: -23px; visibility: hidden;">Contacting Server. Please, wait...</div>--%>
</ProgressTemplate>
</asp:UpdateProgress>
</form>

