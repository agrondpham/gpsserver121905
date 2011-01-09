<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createaccount.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.createaccount" %>
<script type="text/javascript" src="../Scripts/jquery.validate.vn.js"></script>
<%--set validation--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#accountmanagerForm").validate();
        onsubmit: false;
    });
    $("#ctl02_createaccount1_btnCommit").click(function (evt) {
        // Validate the form and retain the result.
        var isValid = $("#accountmanagerForm").valid();

        // If the form didn't validate, prevent the
        //  form submission.
        if (!isValid)
            evt.preventDefault();
    });
    $("#ctl02_createaccount1_btnAddNew").click(function (evt) {
        // Validate the form and retain the result.
        var isValid = $("#accountmanagerForm").valid();

        // If the form didn't validate, prevent the
        //  form submission.
        if (!isValid)
            evt.preventDefault();
    });
    
</script>
<div>     
    <div class="valid_box">
        <asp:Label runat="server" ID="lblErr" ForeColor="red"></asp:Label>
     </div>
</div>
<div class="newaccount_table">
    <div class="newaccount_lf">
        <asp:Label runat="server" Text="[UserName]" ID="lblUsername"></asp:Label></div>
    <div class="newaccount_rg">
        <asp:TextBox ID="tbxUserName" runat="server" CssClass="text ui-widget-content ui-corner-all new-account-input required"></asp:TextBox>
    </div>
<%--    <div><img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>--%>
    <div class="newaccount_lf">
        <asp:Label runat="server" Text="[Password]" ID="lblPassword"></asp:Label></div>
    <div class="newaccount_rg">
        <asp:TextBox runat="server" ID="tbxPassword" CssClass="text ui-widget-content ui-corner-all new-account-input required"></asp:TextBox></div>
<%--    <div><img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>--%>
    <div class="newaccount_lf">
        <asp:Label runat="server" Text="[Email]" ID="lblEmail"></asp:Label></div>
    <div class="newaccount_rg">
        <asp:TextBox runat="server" ID="tbxEmail" CssClass="text ui-widget-content ui-corner-all new-account-input required email"></asp:TextBox></div>
<%--    <div><img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>--%>
    <div class="newaccount_lf">
        <asp:Label runat="server" Text="[Full Name]" ID="lblFullName"></asp:Label></div>
    <div class="newaccount_rg">
        <asp:TextBox runat="server" ID="tbxFullName" CssClass="text ui-widget-content ui-corner-all new-account-input required"></asp:TextBox></div>
<%--    <div><img alt="" class="style1" src="../../Themes/_default/Images/notifi16px.png" /></div>--%>
<div class="rw-control">
    <div class="newaccount_lf">
        <asp:Button runat="server" Text="[Commit]" ID="btnCommit" OnClick="btnCommit_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
        </asp:Button>
    </div>
    <div class="newaccount_rg">
        <asp:Button runat="server" Text="[Add New]" ID="btnAddNew" OnClick="btnAddNew_Click" CssClass="ui-button ui-widget ui-state-default ui-corner-all button">
        </asp:Button>
    </div>
</div>
</div>

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
    <div class="uploadProcess"><img alt="" class="uploadProcess_image" src="../../Themes/_default/Images/ajax_loadingBarRed.gif" /></div>
</ProgressTemplate>
</asp:UpdateProgress>