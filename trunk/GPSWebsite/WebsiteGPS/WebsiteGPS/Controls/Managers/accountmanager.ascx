<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accountmanager.ascx.cs" Inherits="WebsiteGPS.Controls.Manager.accountmanager" %>
<%--StyleSheet inport--%>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css"/>
<link href="../Themes/_default/Styles/accountsmanager.css" rel="stylesheet" type="text/css" />
<%-- Library Jquery inport--%>
<script src="../Scripts/jquery-1.4.4.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery-ui-1.8.7.custom.min.js"type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-vi.js"type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-en-GB.js"type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        //Delete config
        $("#hypDelete").click(function () {
                $("#delete-confirm").dialog("open");
			});
        $("#delete-confirm").dialog({
	        autoOpen: false,
            resizable: false,
            height: 300,
            width: 350,
	        modal: true,
	        buttons: {
	            "Delete": function () {
	                $(this).dialog("close");
	            },
	            Cancel: function () {
	                $(this).dialog("close");
	            }
	        }
	    });
	    //AddUser Dialog

	    $("#add-user-dialog").dialog({
	        autoOpen: false,
	        height: 300,
	        width: 350,
	        modal: true,
	        close: function () {
	            allFields.val("").removeClass("ui-state-error");
	        }
	    });
	    $("#hypAddUser")
			.click(function () {
			    $("#add-user-dialog").dialog("open");
			});
	});
</script>
<script type="text/javascript">
//Search auto complete
	$.widget("custom.catcomplete", $.ui.autocomplete, {
	    _renderMenu: function (ul, items) {
	        var self = this,
			currentCategory = "";
	        $.each(items, function (index, item) {
	            if (item.category != currentCategory) {
	                ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
	                currentCategory = item.category;
	            }
	            self._renderItem(ul, item);
	        });
	    }
	});
	$(function () {
	    var data = [
		{ label: "anders", category: "" },
		{ label: "andreas", category: "" },
		{ label: "antal", category: "" },
		{ label: "annhhx10", category: "Products" },
		{ label: "annk K12", category: "Products" },
		{ label: "annttop C13", category: "Products" },
		{ label: "anders andersson", category: "People" },
		{ label: "andreas andersson", category: "People" },
		{ label: "andreas johnson", category: "People" }
	];
    //add search tool
	    $("#search").catcomplete({
	        delay: 0,
	        source: data
	    });
	});
</script>


<div>
    <div class="cm-tool-header">
        <a id="hypAddUser" class="cm-a" style="float:left"><img alt="" src="../../Themes/_default/Images/user_add.png" /></a>
        <a class="ui-button ui-widget ui-state-default cm-button-search ui-corner-right ui-button-icon">[Search]</a>
        <input id="search" type="text" class="ui-widget ui-widget-content ui-corner-left cm-textbox-search"/>        
        <div class="clear"></div>
    </div>
    <div></div>
    <div id="users" class="ui-widget ui-widget-content cm-table">
		<div class="ui-widget-header cm-table-rw">
			<div class="cm-table-cl" style="width:100px">[Name]</div>
			<div class="cm-table-cl cm-table-ncl" style="width:200px;">[Email]</div>
			<div class="cm-table-cl cm-table-ncl" style="width:100px;">[Password]</div>
            <div class="cm-table-cl cm-table-ncl" style="width:50px;">[Delete]</div>
            <div class="clear"></div>
		</div>
		<div class="cm-table-rw">
			<div style="width:100px;float:left">[John Doe]</div>
			<div class="cm-table-cl cm-table-ncl" style="width:200px;">[john.doe@example.com]</div>
			<div class="cm-table-cl cm-table-ncl" style="width:100px;">[johndoe1]</div>
            <div class="cm-table-cl cm-table-ncl" style="width:50px;">
                <a id="hypDelete" class="cm-a"><img alt="" src="../../Themes/_default/Images/trash_icon.png" /></a></div>
            <div class="clear"></div>
		</div>
	</div>
    <div id="add-user-dialog" title="[Create New User]">
    </div>
    <div id="delete-confirm" title="[Delete item?]" class="cm-dialog-config">
	    <p>[These items will be permanently deleted and cannot be recovered. Are you sure?]</p>
    </div>

</div>