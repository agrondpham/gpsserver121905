<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="historictracking.ascx.cs"
    Inherits="WebsiteGPS.Controls.Controler.HistoricTracking" %>
<%@ Register Src="../Accounts/profile.ascx" TagName="profile" TagPrefix="uc1" %>
<%--StyleSheet inport--%>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<link rel="stylesheet" href="../Themes/_default/Styles/Controller.css" />
<%-- Library Jquery inport--%>
<script src="../Scripts/jquery-1.4.4.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery-ui-1.8.7.custom.min.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-vi.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-en-GB.js" type="text/javascript"></script>
<%--Date Time Jquery--%>
<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $.datepicker.setDefaults($.datepicker.regional[""]); //set Default isnot important

            $("#ctl02_historictracking1_tbxStartTime").datepicker({
                showOn: "button",
                buttonImage: "../Themes/_default/Images/calendar_icon.png",
                buttonImageOnly: true,
                showAnim: "slide"
            });
            //set location for time picker
            $("#ctl02_historictracking1_tbxStartTime").datepicker("option",
				$.datepicker.regional["vi"]);
            $("#ctl02_historictracking1_tbxStopTime").datepicker({
                showOn: "button",
                buttonImage: "../Themes/_default/Images/calendar_icon.png",
                buttonImageOnly: true,
                showAnim: "slide"
            });
            //set location for time picker
            $("#ctl02_historictracking1_tbxStopTime").datepicker("option",
				$.datepicker.regional["vi"]);
        });
    });

</script>
<%--Effect for Controller--%>
<script type="text/javascript">
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
    $(function () {
        // set effect from select menu value
        $("#hypShow").click(function () {
            runEffect("show");
            $("#hypShow").hide("fast");
            return false;
        });
        // set effect from select menu value
        $("#hypHide").click(function () {
            runEffect("hide");
            $("#hypShow").show("fast");
            return false;
        });
        //set hide default of "Show Control"
        $("#hypShow").hide("fast");
    });

</script>
<%--DropDownList Jquery--%>
<script type="text/javascript">
    (function ($) {
        $.widget("ui.combobox", {
            _create: function () {
                var self = this,
					select = this.element.hide(),
					selected = select.children(":selected"),
					value = selected.val() ? selected.text() : "";
                var input = this.input = $("<input>")
					.insertAfter(select)
					.val(value)
					.autocomplete({
					    delay: 0,
					    minLength: 0,
					    source: function (request, response) {
					        var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
					        response(select.children("option").map(function () {
					            var text = $(this).text();
					            if (this.value && (!request.term || matcher.test(text)))
					                return {
					                    label: text.replace(
											new RegExp(
												"(?![^&;]+;)(?!<[^<>]*)(" +
												$.ui.autocomplete.escapeRegex(request.term) +
												")(?![^<>]*>)(?![^&;]+;)", "gi"
											), "<strong>$1</strong>"),
					                    value: text,
					                    option: this
					                };
					        }));
					    },
					    select: function (event, ui) {
					        ui.item.option.selected = true;
					        self._trigger("selected", event, {
					            item: ui.item.option
					        });
					    },
					    change: function (event, ui) {
					        if (!ui.item) {
					            var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex($(this).val()) + "$", "i"),
									valid = false;
					            select.children("option").each(function () {
					                if ($(this).text().match(matcher)) {
					                    this.selected = valid = true;
					                    return false;
					                }
					            });
					            if (!valid) {
					                // remove invalid value, as it didn't match anything
					                $(this).val("");
					                select.val("");
					                input.data("autocomplete").term = "";
					                return false;
					            }
					        }
					    }
					})
					.addClass("ui-widget ui-widget-content ui-corner-left");

                input.data("autocomplete")._renderItem = function (ul, item) {
                    return $("<li></li>")
						.data("item.autocomplete", item)
						.append("<a>" + item.label + "</a>")
						.appendTo(ul);
                };

                this.button = $("<a>&nbsp;</a>")
					.attr("tabIndex", -1)
					.attr("title", "Show All Items")
					.insertAfter(input)
					.button({
					    icons: {
					        primary: "ui-icon-triangle-1-s"
					    },
					    text: false
					})
					.removeClass("ui-corner-all")
					.addClass("ui-corner-right ui-button-icon")
					.click(function () {
					    // close if already visible
					    if (input.autocomplete("widget").is(":visible")) {
					        input.autocomplete("close");
					        return;
					    }

					    // pass empty string as value to search for, displaying all results
					    input.autocomplete("search", "");
					    input.focus();
					});
            },

            destroy: function () {
                this.input.remove();
                this.button.remove();
                this.element.show();
                $.Widget.prototype.destroy.call(this);
            }
        });
    })(jQuery);

    $(function () {
        $("#ctl02_historictracking1_drdDevices").combobox();
    });
    $(function () {
        $("#ctl02_historictracking1_drdDevices2").combobox();
    });
</script>
<%--Button Jquery style--%>
<script type="text/javascript">
    $(function () {
        $("button, input:submit, a", ".ui-Controller-button").button();
        $("button", ".ui-Controller-button").click(function () { return false; });
    });

</script>
<%-- Tab Jquery--%>
<script type="text/javascript">
    $(function () {
        $("#WidgetControler").tabs();
    });
</script>
<%-- Dialog --%>
<script type="text/javascript">
    $(function () {
        $("#ProfileDialog").dialog({
            autoOpen: false,
            height: 500,
            width: 450,
            modal: true,
            close: function () {
                allFields.val("").removeClass("ui-state-error");
            }
        });
        $("#hypProfile")
			.click(function () {
			    $("#ProfileDialog").dialog("open");
			});
    });
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="WidgetControler" class="ui-controller ui-corner-all">
    <ul>
        <li><a href="#HistoryTracking">[History Tracking]</a></li>
        <li><a href="#TrackingOnline">[Tracking Online]</a></li>
        <li><a id="hypProfile">
            <img alt="" src="../../Themes/_default/Images/account_icon.png" /></a></li>
        <li><a id="hypHide">
            <img alt="" src="../../Themes/_default/Images/delete_icon.png" /></a></li>
    </ul>
    <div id="HistoryTracking" class="ui-controller-maincontent">
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                [Choice Device]</div>
            <div class="ui-controller-component">
                <asp:DropDownList ID="drdDevices" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                [Choice Time Start]</div>
            <div class="ui-controller-component">
                <asp:TextBox ID="tbxStartTime" runat="server" class="text ui-corner-all" Enabled="false"></asp:TextBox>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                [Choice Time Stop]</div>
            <div class="ui-controller-component">
                <asp:TextBox ID="tbxStopTime" runat="server" class="text ui-corner-all" Enabled="false"></asp:TextBox>
            </div>
            <div style="clear">
            </div>
        </div>
        <div class="ui-Controller-button">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnShowMarkers" runat="server" Text="[Show Data]" OnClick="btnShowMarkers_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="TrackingOnline" class="ui-controller-maincontent">
        <div class="ui-controller-line">
            <div class="ui-controller-label">
                [Choice Device]</div>
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
            <asp:Button ID="Button2" runat="server" Text="[Tracking]" />
        </div>
    </div>
</div>
<div id="ProfileDialog" title="[View Profile]">
    <uc1:profile ID="profile1" runat="server" />
</div>
<div class="ui-controller-showPanel">
    <a id="hypShow" class="ui-state-default ui-corner-all" style="cursor: pointer">
        <img alt="" src="../../Themes/_default/Images/map_icon.png" />
    </a>
</div>
