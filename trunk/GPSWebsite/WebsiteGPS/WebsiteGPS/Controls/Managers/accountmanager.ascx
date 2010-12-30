﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accountmanager.ascx.cs"
    Inherits="WebsiteGPS.Controls.Manager.accountmanager" %>
<%@ Register Src="../Accounts/createaccount.ascx" TagName="createaccount" TagPrefix="uc1" %>
<%--StyleSheet inport--%>
<link rel="stylesheet" href="../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" />
<link href="../Themes/_default/Styles/accountsmanager.css" rel="stylesheet" type="text/css" />
<%-- Library Jquery inport--%>
<script src="../Scripts/jquery-1.4.4.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery-ui-1.8.7.custom.min.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-vi.js" type="text/javascript"></script>
<script src="../Scripts/librarys/jquery.ui.datepicker-en-GB.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        //AddUser Dialog
        $("#add-user-dialog").dialog({
            autoOpen: false,
            resizable: false,
            height: 500,
            width: 650,
            modal: true,
            close: function () {
                allFields.val("").removeClass("ui-state-error");
            }
        });
        $("#add-user-dialog").parent().appendTo(jQuery("form:first")); //Move form of dialog become the first Form(Dua Form cua New Account len xu ly dau)
        //add Listener open dialog new AddUser
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
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="cm-tool-header">
        <a id="hypAddUser" class="cm-a" style="float: left">
            <img alt="" src="../../Themes/_default/Images/user_add.png" /></a> <a runat="server"
                onclick="Button1_Click" class="ui-button ui-widget ui-state-default cm-button-search ui-corner-right ui-button-icon">
                [Search]</a>
        <input id="search" type="text" class="ui-widget ui-widget-content ui-corner-left cm-textbox-search" />
        <div class="clear">
        </div>
    </div>
    <div>
        <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
    </div>
    <div id="users" class="ui-widget ui-widget-content cm-table">
       
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(function () {
                        $("button, input:submit, a", ".demo").button();
                        $("input:submit", ".gicungduoc").click(function () { $("#delete-confirm").dialog("open"); });
                        //Delete config
                        //                    $("#hypDelete").click(function () {
                        //                        $("#delete-confirm").dialog("open");
                        //                    });
                        $("#delete-confirm").dialog({
                            autoOpen: false,
                            resizable: false,
                            height: 300,
                            width: 350,
                            modal: true,
                            buttons: {
                                "Delete": function () {
//                                    $.ajax({
//                                          type: "POST",
//                                          url: "Default.aspx/GetDate",
//                                          data: "{}",
//                                          contentType: "application/json; charset=utf-8",
//                                          dataType: "json",
//                                          success: function(msg) {
//                                            // Replace the div's content with the page method's return.
//                                            $("#Result").text(msg.d);
                                },
                                Cancel: function () {
                                    $(this).dialog("close");
                                }
                            }
                        });
                        $("#delete-confirm").parent().appendTo(jQuery("form:first")); //Move form of dialog become the first Form(Dua Form cua delete len xu ly dau)
                    }

                     );
                </script>
                <div class="ui-widget-header cm-table-rw" style="width: 925px">
                    <div class="cm-table-cl" style="width: 150px">
                        [Name]</div>
                    <div class="cm-table-cl cm-table-ncl" style="width: 250px;">
                        [FullName]</div>
                    <div class="cm-table-cl cm-table-ncl" style="width: 300px;">
                        [Email]</div>
                    <div class="cm-table-cl cm-table-ncl" style="width: 100px;">
                        [Status]</div>
                    <div class="cm-table-cl cm-table-ncl" style="width: 100px;">
                        [Delete]</div>
                </div>
                <div class="gicungduoc">
                    <asp:DataGrid CssClass="datagrid" ID="dtgrid" Width="925px" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" Style="text-align: center" PagerStyle-Mode="NumericPages"
                        PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" OnPageIndexChanged="dtgrid_PageIndexChanged"
                        OnDeleteCommand="dtgrid_DeleteCommand" ShowHeader="False" 
                        BorderColor="White">
                        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <PagerStyle BackColor="Silver" ForeColor="#333333" HorizontalAlign="Center" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                        <HeaderStyle CssClass="header" BackColor="#999966" Font-Bold="True" 
                            ForeColor="White" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" />
                        <FooterStyle CssClass="footer" BackColor="#999966" Font-Bold="True" 
                            ForeColor="White" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" />
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:BoundColumn Visible="false" DataField="Username"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Tên Đăng Nhập">
                                <HeaderStyle Width="150px" ></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnTitle" CommandName="Edit">
						    <%# DataBinder.Eval(Container, "DataItem.Username")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Họ Tên" DataField="FullName">
                                <HeaderStyle Width="250px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Email" DataField="Email">
                                <HeaderStyle Width="300px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Trang Thái" DataField="Status">
                                <HeaderStyle Width="100px" />
                            </asp:BoundColumn>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" Text="Delete">
                                <HeaderStyle Width="100px" />
                            </asp:ButtonColumn>
                        </Columns>
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    </asp:DataGrid>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="add-user-dialog" title="[Create New User]">
        <%--    Dua Ajax vao xu ly form--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--      dua ra user control de de edit--%>
                <%-- xu ly loi button bang cach them dong vao dong code o vi tri Ln46 Col9,Da lam tuong tu voi dong Ln34 col9 --%>
                <uc1:createaccount ID="createaccount1" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="delete-confirm" title="[Delete item?]" class="cm-dialog-config">
        <p>
            [These items will be permanently deleted and cannot be recovered. Are you sure?]</p>
    </div>
    </form>
</div>
