<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="booking.aspx.cs" Inherits="busrental.booking" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="booking">
        <table>
            <%--<tr><td>
        <asp:Label Text="Booking No" runat="server" ID="bookingno"></asp:Label>
        <asp:TextBox runat="server" ID="txtbooking"></asp:TextBox><br /></td></tr>--%>
            <tr>
                <td>
                    <asp:Label ID="customername" Text="Customer Name" runat="server"></asp:Label>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="bustypename" Text="Bus Type Name" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlbustype" runat="server" 
                        OnSelectedIndexChanged= "ddlbustype_SelectedIndexChanged" AutoPostBack="True">                       
                </asp:DropDownList><br />
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblfromdate" Text="From Date" runat="server"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <%--<asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>--%>
                    <%--<asp:CompareValidator ID="DateValidator" runat="server" Operator="DataTypeCheck"
        Type="Date" ControlToValidate="txtfrom" ErrorMessage="dd/mm/yyyy" />--%>
                    <br />
                </td>
                <td>
                    <div style="margin: -15px 0 0 0;">
                        <asp:Label ID="lbltodate" Text="To Date" runat="server"></asp:Label><br />
                        <asp:Calendar ID="Calendar2" runat="server" 
                            onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblno" Text="No of Days" runat="server"></asp:Label>
                    <asp:TextBox ID="txtno" runat="server" ontextchanged="txtno_TextChanged"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="trip" Text="Trip Name" runat="server"></asp:Label>
                    <asp:TextBox ID="txttrip" runat="server" ontextchanged="txttrip_TextChanged"></asp:TextBox><br />
                </td>
            </tr>
        <%--    <tr>
                <td>
                    <asp:Label ID="amount" Text="Amount" runat="server"></asp:Label>
                    <asp:TextBox ID="txtamount" runat="server" 
                       ></asp:TextBox><br />
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="lbltotal" Text="Total Amount" runat="server"></asp:Label>
                    <asp:TextBox ID="txttotal" runat="server" ReadOnly="true"></asp:TextBox><br />
                </td>
            </tr>

            
            <tr>
                <td>
                    <asp:Label ID="lbldate" runat="server" Text="Payment Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbank" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblaccount" runat="server" Text="Account No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtaccount" runat="server"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td>
                    <asp:Button ID="Book" Text="Book" runat="server" OnClick="Book_Click" />
                    <asp:Button ID="Cancel" Text="Cancel" runat="server" OnClick="Cancel_Click" />
                    <asp:Button ID="btnreport" runat="server" Text="Booking Report" 
                        onclick="btnreport_Click" />
                </td>
                
            </tr>
               
        </table>
        <asp:HiddenField ID="start" runat="server" />
        <asp:HiddenField ID="end" runat="server" />
      <div style="margin:0 0 0 40px;">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

            <rsweb:ReportViewer ID="rptbooking" runat="server" 
                ExportContentDisposition="AlwaysAttachment" Width="750px" >
            </rsweb:ReportViewer>
    </div>
    </div>



   

</asp:Content>
