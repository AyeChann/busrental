<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="busrental.welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div style="margin:300px 0 185px 300px;">
<p style="font-size:38px;">Welcome!</p>
<asp:LinkButton ID="lbdriver" runat="server" Text="Driver Registration" 
        onclick="lbdriver_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="lbbus" runat="server" Text="Bus Registration" 
        onclick="lbbus_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbbustype" runat="server" Text="Bus Type Registration" 
        onclick="lbbustype_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="lblbooking" runat="server" Text="Booking Report" 
        onclick="lblbooking_Click"></asp:LinkButton>
</div>
</asp:Content>
