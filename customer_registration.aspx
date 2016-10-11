<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customer_registration.aspx.cs" Inherits="busrental.customer_registration" %>
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
        <asp:Label ID="lblemail" Text="Email" runat="server"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox><br />
        </td></tr>
        <tr><td>
        <asp:Label ID="lblphno" Text="Phone No" runat="server"></asp:Label>
        <asp:TextBox ID="txtphno" runat="server"></asp:TextBox><br />
        </td></tr>
        <tr><td>
        <asp:Label ID="lbladdress" Text="Address" runat="server"></asp:Label>
        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox><br />
        </td></tr>
        <tr><td>
        <asp:Label ID="lblpassword" Text="Password" runat="server"></asp:Label>
        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox><br /></td></tr>
    <tr><td>
    <asp:Button ID="btnregister" Text="Register" runat="server" 
            onclick="btnregister_Click"  />
    <asp:Button ID="Cancel" Text="Cancel" runat="server" onclick="Cancel_Click" /></td></tr>
    <asp:Label ID="lblinfo" runat="server"></asp:Label>
    </table>
</div>
</asp:Content>
