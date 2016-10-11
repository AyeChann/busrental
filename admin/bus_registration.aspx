<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="bus_registration.aspx.cs" Inherits="busrental.admin.bus_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bustype">
    <table>    
        <tr><td>
        <asp:Label ID="lblBusName" Text="BusName" runat="server"></asp:Label>
        <asp:TextBox ID="txtBusName" runat="server"></asp:TextBox><br /></td></tr>    
      
        <tr><td>
        <asp:Label ID="lblBusTypeName" Text="BusTypeName" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlBusTypeName" runat="server" CssClass="combo">
            </asp:DropDownList>
        </td></tr>
         <tr><td>
        <asp:Label ID="Label1" Text="Amount" runat="server"></asp:Label>
           <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox><br />
           
        </td></tr>

         <tr><td>
    <asp:Button ID="btnregister" Text="Register" runat="server" 
                 onclick="btnregister_Click" />
    <asp:Button ID="Cancel" Text="Cancel" runat="server" onclick="Cancel_Click" />
    <asp:Button ID="Delete" Text="Delete" runat="server" onclick="Delete_Click" />
    </td></tr>
    <asp:Label ID="lblinfo" runat="server"></asp:Label>
    </table>
        <asp:GridView ID="dgvbus" DataKeyNames="BusNo,BusName,BusTypeNo" runat="server" AutoGenerateColumns="false"
            CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" ShowFooter="true" HeaderStyle-Font-Bold="true"
            HeaderStyle-ForeColor="White" onselectedindexchanged="dgvbus_SelectedIndexChanged"
            OnRowCommand="dgvbus_RowCommand" >
            <Columns>
             <asp:BoundField DataField="BusNo" HeaderText="BusNo" />
            <asp:BoundField DataField="BusName" HeaderText="BusName" />
            <asp:BoundField DataField="BusTypeName" HeaderText="BusTypeName" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />          
            <asp:BoundField DataField="BusTypeNo" HeaderText="BusTypeNo" Visible="False" />
                <asp:CommandField ShowSelectButton="True" />
           
           
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
