<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profile.ascx.cs" Inherits="WebsiteGPS.Controls.Accounts.profile" %>
<link href="../Themes/_default/Styles/profile.css" rel="stylesheet" type="text/css" />
<div>
    <div class="pf-rw">
        <div class="pf-cl-lf">[FullName]</div>
        <div class="pf-cl-rg">
            <asp:Label ID="lbl_Fullname" runat="server" Text="[Fullname]"></asp:Label></div>   
    </div>
    <div class="pf-rw">
        <div class="pf-cl-lf">[Mobile]</div>
        <div class="pf-cl-rg">
            <asp:Label ID="lbl_Mobile" runat="server" Text="[0000000]"></asp:Label></div>
        
    </div>
    <div class="pf-rw">
        <div class="pf-cl-lf">[Email]</div>
        <div class="pf-cl-rg">
            <asp:Label ID="lbl_Email" runat="server" Text="[abc@gmail.com]"></asp:Label></div>
    </div>
    <div class="pf-rw-changepass">
        <div >[ChangePassword]</div>
        <div class="pf-cl-lf">[New Password]</div>
        <div class="pf-cl-rg">
            <asp:TextBox ID="txt_NewPassword" runat="server"></asp:TextBox></div>
        <div class="pf-cl-lf">[Config password]</div>
        <div class="pf-cl-rg">
            <asp:TextBox ID="txt_NewPassConfig" runat="server"></asp:TextBox></div>
        <div>
            <asp:Button ID="btn_ChangePass" runat="server" Text="[ChangePass]" /></div>
    </div>
    <div class="pf-rw">
        <div class="pf-cl-lf">[Company]</div>
        <div class="pf-cl-rg">
            <asp:Label ID="lbl_CompanyName" runat="server" Text="[CompanyName]"></asp:Label></div>
        
    </div>
    <div class="pf-rw">
        <div class="pf-cl-lf">[Phone]</div>
        <div class="pf-cl-rg">
            <asp:Label ID="lbl_CompanyPhone" runat="server" Text="[00000000]"></asp:Label></div>
    </div>
</div>