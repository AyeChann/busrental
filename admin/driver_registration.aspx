<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="driver_registration.aspx.cs" Inherits="busrental.admin.driver_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="driver">
        <%--<table>
            <%--<tr><td>
        <asp:Label Text="Booking No" runat="server" ID="bookingno"></asp:Label>
        <asp:TextBox runat="server" ID="txtbooking"></asp:TextBox><br /></td></tr>
            <tr>
                <td>
                    <asp:Label ID="lbluser" Text="Driver Name" runat="server"></asp:Label>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblphone" Text="Phone" runat="server"></asp:Label>
                    <asp:TextBox ID="txtphone" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbladdress" Text="Address" runat="server"></asp:Label>
                    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnregister" Text="Register" runat="server" OnClick="btnregister_Click" />
                    <asp:Button ID="Cancel" Text="Cancel" runat="server" OnClick="Cancel_Click" />
                </td>
            </tr>
            <asp:Label ID="lblinfo" runat="server"></asp:Label>
        </table>--%>
        <asp:GridView ID="gvDetails" DataKeyNames="DriverNo,Name" runat="server" AutoGenerateColumns="false"
            CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" ShowFooter="true" HeaderStyle-Font-Bold="true"
            HeaderStyle-ForeColor="White" OnRowCancelingEdit="gvDetails_RowCancelingEdit"
            OnRowDeleting="gvDetails_RowDeleting" OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating"
            OnRowCommand="gvDetails_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="i/update.png"
                            ToolTip="Update" Height="20px" Width="20px" />
                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/admin/i/cancel.png"
                            ToolTip="Cancel" Height="20px" Width="20px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="i/edit.png"
                            ToolTip="Edit" Height="20px" Width="20px" />
                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                            ImageUrl="i/delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="i/new.png"
                            CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" runat="server" Text='<%#Eval("Name") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftrname" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtftrname"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtphone" runat="server" Text='<%#Eval("Phone") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblphone" runat="server" Text='<%#Eval("Phone") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftrphone" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtftrphone"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtaddress" runat="server" Text='<%#Eval("Address") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbladdress" runat="server" Text='<%#Eval("Address") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftraddress" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ControlToValidate="txtftraddress"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
