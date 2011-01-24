//<%--Date Time Jquery--%>
    $(document).ready(function () {
        $(function () {
            $.datepicker.setDefaults($.datepicker.regional[""]); //set Default isnot important

            $("#ctl03_controller1_tbxStartTime").datepicker({
                showOn: "button",
                buttonImage: "../Themes/_default/Images/calendar_icon.png",
                buttonImageOnly: true,
                showAnim: "slide"
            });
            //set location for time picker
            $("#ctl03_controller1_tbxStartTime").datepicker("option",
				$.datepicker.regional["vi"]);
            $("#ctl03_controller1_tbxStopTime").datepicker({
                showOn: "button",
                buttonImage: "../Themes/_default/Images/calendar_icon.png",
                buttonImageOnly: true,
                showAnim: "slide"
            });
            //set location for time picker
            $("#ctl03_controller1_tbxStopTime").datepicker("option",
				$.datepicker.regional["vi"]);
        });
    });

//<%--Effect for Controller--%>
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

//<%--DropDownList Jquery--%>
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
        $("#ctl03_controller1_drdDevices").combobox();
    });
    $(function () {
        $("#ctl03_controller1_drdDevices2").combobox();
    });

//<%--Button Jquery style--%>

    $(function () {
        $("button, input:submit, a", ".ui-Controller-button").button();
        $("button", ".ui-Controller-button").click(function () { return false; });
    });


//<%-- Tab Jquery--%>

    $(function () {
        $("#WidgetControler").tabs();
    });

//<%-- Dialog --%>

    $(function () {
        $("#ProfileDialog").dialog({
            autoOpen: false,
            height: 500,
            width: 500,
            modal: true,
            stack: false,
            zIndex: 2
        });
        $("#hypProfile")
			.click(function () {
			    $("#ProfileDialog").dialog("open");
			});
    });
