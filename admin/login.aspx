<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="busrental.admin.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="customer">
<table>
    <%--<tr><td>
        <asp:Label Text="Booking No" runat="server" ID="bookingno"></asp:Label>
        <asp:TextBox runat="server" ID="txtbooking"></asp:TextBox><br /></td></tr>--%>

        <tr><td>
        <asp:Label ID="lbluser" Text="User Name" runat="server"></asp:Label>
        <asp:TextBox ID="txtname" runat="server"></asp:TextBox><br /></td></tr>
        
        
       
        <tr><td>
        <asp:Label ID="lblpassword" Text="Password" runat="server"></asp:Label>
        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox><br /></td></tr>
    <tr><td>
    <asp:Button ID="btnregister" Text="Log In" runat="server" 
            onclick="btnregister_Click"   />
    <asp:Button ID="Cancel" Text="Cancel" runat="server" onclick="Cancel_Click"  /></td></tr>
    <asp:Label ID="lblinfo" runat="server"></asp:Label>
    </table>
</div>

</asp:Content>
