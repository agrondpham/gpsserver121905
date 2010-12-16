<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="historictracking.ascx.cs" Inherits="WebsiteGPS.Controls.Controler.HistoricTracking" %>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css"/>
<script src="../Scripts/jquery-1.4.4.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery-ui-1.8.7.custom.min.js"type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-vi.js"type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-en-GB.js"type="text/javascript"></script>
<script type="text/javascript">
    /*$(function() {
    $("#tbxTime").datepicker();
    });*/
    $(document).ready(function () {
        $(function () {
            $.datepicker.setDefaults($.datepicker.regional[""]); //set Default isnot important
            $("#historictracking1_tbxTime").datepicker($.datepicker.regional["vi"]); //set location for time picker
            $("#historictracking1_tbxTime").datepicker({ showAnim: "slide" });
        });
        // run the show effect
        function runEffect(typeOfEffect) {
            // get effect type from 
            var selectedEffect = "drop";

            // most effect types need no options passed by default
            var options = {};
            // some effects have required parameters
            if (selectedEffect === "scale") {
                options = { percent: 100 };
            } else if (selectedEffect === "size") {
                options = { to: { width: 280, height: 185} };
            }
            //callback function to bring a hidden box back
            function callback() {
            };
            // run the effect
            if (typeOfEffect == "show") {
                //show effect
                $("#WidgetControler").show(selectedEffect, options, 500, callback);
            } else {
                // hide effect
                $("#WidgetControler").hide(selectedEffect, options, 1000, callback);

            }
        };
        // set effect from select menu value
        $("#show").click(function () {
            runEffect("show");
            return false;
        });
        // set effect from select menu value
        $("#hide").click(function () {
            runEffect("hide");
            return false;
        });
    });

</script>
<style type="text/css">
    <%--bo goc lai voi CSS--%>
ui-corner-all
{
    -moz-border-radius: 4px; 
    -webkit-border-radius: 4px;
    }</style>
<div id="WidgetControler" class="ui-widget-content ui-corner-all" style="width:400px;">
    <div class="ui-widget-header ui-corner-all" style="width:300px"><a href="#" id="hide" >Hide Controler</a></div>
    <div style="height:30px">
        <div style="width:100px;float:left">[Choice Device]</div>
        <div style="width:150px;float:left"></div>
        <div style="clear"></div>
    </div>
    <div style="height:30px">
        <div style="width:100px;float:left">[Choice Time]</div>
        <div style="width:150px;float:left">
            <asp:TextBox ID="tbxTime" runat="server"></asp:TextBox>
        </div>
        <div style="clear"></div>
    </div>
    <div>[Button Show Data]</div>
</div>
<div>
<a href="#" id="show" class="ui-state-default ui-corner-all">Show Controler</a>
</div>