﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accountmanager.ascx.cs"
    Inherits="WebsiteGPS.Controls.Manager.accountmanager" %>
<%@ Register Src="../Accounts/createaccount.ascx" TagName="createaccount" TagPrefix="uc1" %>
<%@ Register src="../footer.ascx" tagname="footer" tagprefix="uc2" %>
<%--StyleSheet inport--%>
<link href="../../Scripts/css/smoothness/jquery-ui-1.8.7.custom.css" rel="stylesheet" type="text/css" />
<link href="../../Themes/_default/Styles/accountsmanager.css" rel="stylesheet" type="text/css" />
<link href="../../Themes/_default/ReportStyle/Style.css" rel="stylesheet" type="text/css" />
<%-- Library Jquery inport--%>
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
            modal: true
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
<%-- style for admin login--%>
<link href="../Themes/_default/AccountManagerStyle/style.css" rel="stylesheet" type="text/css" />
<%--<link rel="stylesheet" type="text/css" href="../Themes/_default/AdminTemplate/style.css" />--%>
<%--<script src="../Themes/_default/AdminTemplate/jquery.jclock-1.2.0.js.txt" type="text/javascript"></script>--%>
<link rel="stylesheet" type="text/css" media="all" href="../Themes/_default/AccountManagerStyle/niceforms-default.css" />
<script type="text/javascript">
    $(function ($) {
        $('.jclock').jclock();
    });
</script>
<div id="main_container"><form runat="server" id="accountmanagerForm">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<div class="header">
    <div class="logo"><img src="../Themes/_default/Images/logo.png" alt="" title=""/></a></div>
    
    <div class="right_header">
        <asp:Label ID="lblWelcome" runat="server" Text="[Welcome Admin]"></asp:Label>, <a href="www.dinhvigps.net">Visit site</a> | <a href="#" class="messages">(3) Messages</a> | <a href="#" class="logout"><asp:Label ID="lblLogout" runat="server" Text="[Logout]"></asp:Label></a></div>
    <div class="jclock"></div>
    </div>
    
    <div class="main_content">
        <div class="menu">
            <ul>
                <li><a class="current" href="index.html"><asp:Label ID="lblAdminHome" runat="server"
                Text="[Admin Home]"></asp:Label></a></li>
            </ul>
        </div>            
    <div class="center_content">  
    <div class="right_content">
    <h2>Products Categories Settings</h2>             
        <div class="cm-tool-header">
             <a id="A1" runat="server"
                    onclick="Button1_Click" class="ui-button ui-widget ui-state-default cm-button-search ui-corner-right ui-button-icon">
                    <asp:Label ID="lblSearch" runat="server" Text="[Search]"></asp:Label></a>
            <input id="search" type="text" class="ui-widget ui-widget-content ui-corner-left cm-textbox-search" />
            <div class="clear"></div>
        </div>    

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(function () {
                        $("button, input:submit, a", ".demo").button();
                        $("input:submit", ".table_delete").click(function () { $("#delete-confirm").dialog("open"); });
                        $("#delete-confirm").dialog({
                            autoOpen: false,
                            resizable: false,
                            height: 300,
                            width: 350,
                            modal: true,
                            buttons: {
                                "Delete": function () {
                                    $.ajax({
                                        type: "POST",
                                        url: "accountmanager.ascx/dtgrid_DeleteCommand",
                                        data: "{}",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function (msg) { }
                                    });
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
    <div>
        <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
    </div>              
    <table id="rounded-corner" summary="2007 Major IT Companies' Profit">
        <thead>
    	    <tr>
        	    <th scope="col" class="rounded-company"></th>
                <th scope="col" class="table_username"><asp:Label ID="lblName" runat="server" Text="[Name]"></asp:Label></th>
                <th scope="col" class="table_fullname"><asp:Label ID="lblFullName" runat="server" Text="[Fullname]"></asp:Label></th>
                <th scope="col" class="table_email"><asp:Label ID="lblEmail" runat="server" Text="[email]"></asp:Label></th>
                <th scope="col" class="table_status"><asp:Label ID="lblStatus" runat="server" Text="[status]"></asp:Label></th>
                <th scope="col" class="table_delete"><asp:Label ID="lblDelete" runat="server" Text="[delete]"></asp:Label></th>
            </tr>
        </thead>
    </table>
    <asp:DataGrid CssClass="datagrid" ID="dtgrid" Width="825px" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" Style="text-align: center" PagerStyle-Mode="NumericPages"
                        PageSize="5" CellPadding="4" ForeColor="#333333" 
                    GridLines="Horizontal" OnPageIndexChanged="dtgrid_PageIndexChanged"
                        OnDeleteCommand="dtgrid_DeleteCommand" 
                        BorderColor="White" ShowHeader="False">
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
            <asp:BoundColumn Visible="false" DataField="Username">
                <HeaderStyle Width="25px" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Tên Đăng Nhập" ItemStyle-CssClass="table_username">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnTitle" CommandName="Edit">
		                <%# DataBinder.Eval(Container, "DataItem.Username")%>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="Họ Tên" DataField="FullName" ItemStyle-CssClass="table_fullname">
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Email" DataField="Email" ItemStyle-CssClass="table_email">
            </asp:BoundColumn>
            <%--<asp:BoundColumn HeaderText="Trang Thái" DataField="Status" ItemStyle-CssClass="table_status">
            </asp:BoundColumn>--%>
            <asp:TemplateColumn HeaderText="Trang Thái">
                            <ItemTemplate>
                                <asp:Image runat="server" ItemStyle-CssClass="table_email" src='<%# "../../Themes/_default/Images/" + 
                       DataBinder.Eval(Container.DataItem,"StatusImage")%>' ID="Status" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
            <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" Text="Delete" ItemStyle-CssClass="table_delete">
            </asp:ButtonColumn>
        </Columns>
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:DataGrid>

	<a id="hypAddUser" class="bt_green">
        <span class="bt_green_lft"></span>
            <strong><asp:Label ID="lblAddnew" runat="server" Text="[Add New]"></asp:Label></strong></asp:Label>
        <span class="bt_green_r"></span></a>
<%--     <a href="#" class="bt_blue"><span class="bt_blue_lft"></span><strong>View all items from category</strong><span class="bt_blue_r"></span></a>
     <a href="#" class="bt_red"><span class="bt_red_lft"></span><strong>Delete items</strong><span class="bt_red_r"></span></a> 
 --%>    
            </ContentTemplate>
        </asp:UpdatePanel>
     
<%--        <div class="pagination">
        <span class="disabled"><< prev</span><span class="current">1</span><a href="">2</a><a href="">3</a><a href="">4</a><a href="">5</a>…<a href="">10</a><a href="">11</a><a href="">12</a>...<a href="">100</a><a href="">101</a><a href="">next >></a>
        </div> --%>
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
            <asp:Label ID="lblDeleteNotification" runat="server" Text="[These items will be permanently deleted and cannot be recovered. Are you sure?]"></asp:Label></p>
    </div>




<%--     <h2>Warning Box examples</h2>
      
     <div class="warning_box">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut.
     </div>
     <div class="valid_box">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut.
     </div>
     <div class="error_box">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut.
     </div>  --%>
     </div><!-- end of right content-->
            
                    
  </div>   <!--end of center content -->               
                    
                    
    
    
    <div class="clear"></div>
    </div> <!--end of main content-->
	
    
    <uc2:footer ID="footer1" runat="server" />

    </form>
</div>		



